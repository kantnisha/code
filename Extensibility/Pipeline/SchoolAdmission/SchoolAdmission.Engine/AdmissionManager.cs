using SchoolAdmission.Common.Contracts;
using SchoolAdmission.Common.DataModels;
using SchoolAdmission.Common.Entities;
using SchoolAdmission.Common.Modules;
using SchoolAdmission.Engine.Contracts;

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
            Student student = null;

            if (admissionEvents.ValidateStudent != null)
            {
                var validateStudentEventArgs = new ValidateStudentEventArgs(this._schoolRepository, admissionData);
                admissionEvents.ValidateStudent(validateStudentEventArgs);
                student = validateStudentEventArgs.Student;
            }

            double fee = 0;
            if(admissionEvents.AdjustAvailability!=null)
            {
                var availabilityEventArgs = new AdjustSubjectAvailabilityEventArgs(this._schoolRepository, student, admissionData, admissionEvents);
                admissionEvents.AdjustAvailability(availabilityEventArgs);
                fee = availabilityEventArgs.Fee;
            }

            bool paymentSuccess=false;
            if (admissionEvents.ProcessBilling != null)
            {
                var billingEventArgs = new ProcessBillingEventArgs(admissionData, this._schoolRepository, student, fee, this._paymentProcessor);
                admissionEvents.ProcessBilling(billingEventArgs);
            }

            if (admissionEvents.SendNotification != null)
            {
                var notificationEventArgs = new SendNotificationEventArgs(admissionData, paymentSuccess, this._mailer);
                admissionEvents.SendNotification(notificationEventArgs);
            }
        }
    }
}
