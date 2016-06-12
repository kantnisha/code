using SchoolAdmission.Common.Contracts;
using SchoolAdmission.Common.DataModels;
using System;

namespace SchoolAdmission.Engine
{
    public class Mailer:IMailer
    {
        public string FromAddress { get; set;}
        public string SmtpServer { get; set; }
        
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
