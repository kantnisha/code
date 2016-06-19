using SchoolAdmission.Common.Contracts;
using SchoolAdmission.Common.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.Common.Modules
{
    public class SendNotificationEventArgs:EventArgs
    {
        public SendNotificationEventArgs(AdmissionData admissionData, bool paymentSuccess, IMailer mailer)
        {
            this.AdmissionData = admissionData;
            this.PaymentSuccess = paymentSuccess;
            this.Mailer = mailer;
        }

        public AdmissionData AdmissionData { get; set; }
        public bool PaymentSuccess { get; set; }
        public IMailer Mailer { get; set; }
    }
}
