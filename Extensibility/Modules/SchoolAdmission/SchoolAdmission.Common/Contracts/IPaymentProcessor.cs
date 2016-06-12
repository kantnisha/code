namespace SchoolAdmission.Common.Contracts
{
    public interface IPaymentProcessor
    {
        bool ProcessCreditCard(string studentName, string creditCardNo, string expiryDate, double amount);
    }
}
