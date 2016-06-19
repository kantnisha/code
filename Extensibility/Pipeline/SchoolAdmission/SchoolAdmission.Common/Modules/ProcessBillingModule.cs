using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.Common.Modules
{
    public class ProcessBillingModule : IAdmissionModule
    {
        public void Initialize(AdmissionEvents events)
        {
            events.ProcessBilling += OnBillingProcessed;
        }

        private void OnBillingProcessed(ProcessBillingEventArgs e)
        {
            bool paymentSuccess = e.PaymentProcessor.ProcessCreditCard(e.Student.Name, e.AdmissionData.CreditCard, e.AdmissionData.ExpirationDate, e.Fee);

            e.PaymentSuccess = paymentSuccess;
            if (!paymentSuccess)
            {
                throw new ApplicationException(string.Format("Credit card processing failed"));
            }
        }
    }
}
