using SchoolAdmission.Engine.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.Engine
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
