using SchoolAdmission.Engine.Contracts;
using SchoolAdmission.Engine.DataModels;
using System;

namespace SchoolAdmission.Engine
{
    public class Mailer:IMailer
    {
        public void SendInvoiceEmail(AdmissionData admissionData)
        {
            Console.WriteLine(string.Format("Following is your invoice for the order, sent to {0} ", admissionData.StudentEmail));
        }

        public void SendRejectionEmail(AdmissionData admissionData)
        {
            Console.WriteLine(string.Format("I am sorry {0}. your order could not be processed", admissionData.StudentEmail));
        }
    }
}
