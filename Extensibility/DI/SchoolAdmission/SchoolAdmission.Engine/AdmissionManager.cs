using SchoolAdmission.Contracts;
using SchoolAdmission.Engine.Contracts;
using SchoolAdmission.Engine.DataAccess;
using SchoolAdmission.Engine.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.Engine
{
    public class AdmissionManager
    {
        ISchoolRepository _schoolRepository = null;
        IPaymentProcessor _paymentProcessor = null;
        IMailer _mailer = null;

        public AdmissionManager(ISchoolRepository schoolRepository, IPaymentProcessor paymentProcessor, IMailer mailer)
        {
            this._schoolRepository = schoolRepository;
            this._paymentProcessor = paymentProcessor;
            this._mailer = mailer;
        }

        public void ProcessAdmission(AdmissionData admissionData)
        {
            var student = this._schoolRepository.GetStudentByEmail(admissionData.StudentEmail);

            if(student==null)
            {
                throw new ApplicationException(string.Format("No student found with email:{0}", admissionData.StudentEmail));
            }

            double fee = 0;
            foreach(var subject in admissionData.OptingSubjectsData)
            {
                fee += subject.TutionFeePerMonth * subject.NoOfMonths;
            }

            bool paymentSuccess = this._paymentProcessor.ProcessCreditCard(student.Name, admissionData.CreditCard, admissionData.ExpirationDate, fee);

            if (!paymentSuccess)
            {
                throw new ApplicationException(string.Format("Credit card processing failed"));
            }

            foreach (var subject in admissionData.OptingSubjectsData)
            {
                var seatAvailability = this._schoolRepository.SubjectAvailability.Where(s => s.Id == subject.SubjectId).FirstOrDefault().SeatsAvailable;
                this._schoolRepository.SubjectAvailability.Where(s => s.Id == subject.SubjectId).FirstOrDefault().SeatsAvailable = seatAvailability - 1;
                Console.WriteLine("Subject availability for subject {0} reduced by 1 for {1} months", subject.SubjectId, subject.NoOfMonths);
            }

            foreach (var subject in admissionData.OptingSubjectsData)
            {
                var seatAvailability = this._schoolRepository.SubjectAvailability.Where(s => s.Id == subject.SubjectId).FirstOrDefault().SeatsAvailable;
                this._schoolRepository.SubjectAvailability.Where(s => s.Id == subject.SubjectId).FirstOrDefault().SeatsAvailable = seatAvailability - 1;
                Console.WriteLine(string.Format("Enrolled student {0} in subject {1} for {2} months", student.Name, subject.SubjectId, subject.NoOfMonths));
            }

            if (paymentSuccess)
            {
                this._mailer.SendInvoiceEmail(admissionData);
            }
            else
            {
                this._mailer.SendRejectionEmail(admissionData);
            }
        }
    }
}
