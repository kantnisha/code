namespace SchoolAdmission.Common.Modules
{
    public class SendNotificationModule : IAdmissionModule
    {
        public void Initialize(AdmissionEvents events)
        {
            events.SendNotification += OnSendNotification;
        }

        private void OnSendNotification(SendNotificationEventArgs e)
        {
            if (e.PaymentSuccess)
            {
               e.Mailer.SendInvoiceEmail(e.AdmissionData);
            }
            else
            {
                e.Mailer.SendRejectionEmail(e.AdmissionData);
            }
        }
    }
}
