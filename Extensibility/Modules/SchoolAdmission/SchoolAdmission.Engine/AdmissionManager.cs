using SchoolAdmission.Contracts;
using SchoolAdmission.Common.Contracts;
using SchoolAdmission.Engine.DataAccess;
using SchoolAdmission.Common.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SchoolAdmission.Engine.Configuration;
using SchoolAdmission.Engine.Contracts;
using SchoolAdmission.Common.Modules;

namespace SchoolAdmission.Engine
{
    public class AdmissionManager
    {
        ISchoolRepository _schoolRepository = null;
        IPaymentProcessor _paymentProcessor = null;
        IMailer _mailer = null;
        IComponentFactory componentFactory = null;
        AdmissionEvents admissionEvents = null;

        public AdmissionManager(ISchoolRepository schoolRepository, IComponentFactory factory)
        {
            this._schoolRepository = schoolRepository;

            componentFactory = factory;
            this._paymentProcessor = componentFactory.PaymentProcessor;
            this._mailer = componentFactory.Mailer;
            admissionEvents = componentFactory.GetEvents();
        }

        public void ProcessAdmission(AdmissionData admissionData)
        {
            var student = this._schoolRepository.GetStudentByEmail(admissionData.StudentEmail);

            if (student == null)
            {
                throw new ApplicationException(string.Format("No student found with email:{0}", admissionData.StudentEmail));
            }

            double fee = 0;
            foreach (var subject in admissionData.OptingSubjectsData)
            {
                if (admissionEvents.AdmissionDataProcessed != null)
                {
                    AdmissionDataProcessedEventArgs args = new AdmissionDataProcessedEventArgs(student, subject);
                    admissionEvents.AdmissionDataProcessed(args);
                    if (args.Cancel)
                    {
                        continue;
                    }
                }

                var seatAvailability = this._schoolRepository.SubjectAvailability.Where(s => s.Id == subject.SubjectId).FirstOrDefault().SeatsAvailable;
                this._schoolRepository.SubjectAvailability.Where(s => s.Id == subject.SubjectId).FirstOrDefault().SeatsAvailable = seatAvailability - 1;
                Console.WriteLine("Subject availability for subject {0} reduced by 1 for {1} months", subject.SubjectId, subject.NoOfMonths);
                Console.WriteLine(string.Format("Enrolled student {0} in subject {1} for {2} months", student.Name, subject.SubjectId, subject.NoOfMonths));

                fee += subject.TutionFeePerMonth * subject.NoOfMonths;
            }

            bool paymentSuccess = this._paymentProcessor.ProcessCreditCard(student.Name, admissionData.CreditCard, admissionData.ExpirationDate, fee);

            if (!paymentSuccess)
            {
                throw new ApplicationException(string.Format("Credit card processing failed"));
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
