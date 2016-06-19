namespace SchoolAdmission.Common.Modules
{
    public class AdmissionEvents
    {
        public AdmissionModuleDelegate<AdmissionDataProcessedEventArgs> AdmissionDataProcessed { get; set; }
        public AdmissionModuleDelegate<ValidateStudentEventArgs> ValidateStudent { get; set; }
        public AdmissionModuleDelegate<AdjustSubjectAvailabilityEventArgs> AdjustAvailability { get; set; }
        public AdmissionModuleDelegate<ProcessBillingEventArgs> ProcessBilling { get; set; }
        public AdmissionModuleDelegate<SendNotificationEventArgs> SendNotification { get; set; }
    }
}
