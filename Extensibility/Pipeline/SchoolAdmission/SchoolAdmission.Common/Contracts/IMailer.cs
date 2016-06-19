using SchoolAdmission.Common.DataModels;

namespace SchoolAdmission.Common.Contracts
{
    public interface IMailer
    {
        void SendInvoiceEmail(AdmissionData admissionData);
        void SendRejectionEmail(AdmissionData admissionData);
        string FromAddress { get; set; }
        string SmtpServer { get; set; }

    }
}
