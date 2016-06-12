using SchoolAdmission.Engine.DataModels;

namespace SchoolAdmission.Engine.Contracts
{
    public interface IMailer
    {
        void SendInvoiceEmail(AdmissionData admissionData);
        void SendRejectionEmail(AdmissionData admissionData);
    }
}
