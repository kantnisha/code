using System.Configuration;

namespace SchoolAdmission.Engine.Configuration
{
    public class AdmissionEngineConfigurationSection : ConfigurationSection
    {

        [ConfigurationProperty("mailer", IsRequired = true)]
        public MailerElement Mailer
        {
            get
            {
                return (MailerElement)base["mailer"];
            }
            set
            {
                base["mailer"] = value;
            }
        }

        [ConfigurationProperty("paymentProcessor", IsRequired = true)]
        public PaymentProcessorElement PaymentProcessor
        {
            get
            {
                return (PaymentProcessorElement)base["paymentProcessor"];
            }
            set
            {
                base["paymentProcessor"] = value;
            }
        }

        [ConfigurationProperty("modules", IsRequired =true)]
        public ModuleElementCollection Modules
        {
            get
            {
                return (ModuleElementCollection)base["modules"];
            }
            set
            {
                base["modules"] = value;
            }
        }
    }
}
