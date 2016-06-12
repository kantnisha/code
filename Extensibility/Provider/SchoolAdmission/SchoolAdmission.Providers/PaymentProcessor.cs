using SchoolAdmission.Common.Contracts;
using System;

namespace SchoolAdmission.Providers
{
    public class PaymentProcessor:IPaymentProcessor
    {
        public bool ProcessCreditCard(string studentName, string creditCardNo, string expiryDate, double amount)
        {
            Console.WriteLine(string.Format("Credit card processed successfully. Amount ${0} deducted", amount));

            return true;
        }
    }
}
