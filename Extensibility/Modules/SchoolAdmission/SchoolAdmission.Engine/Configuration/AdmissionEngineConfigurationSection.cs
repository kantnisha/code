using System.Configuration;

namespace SchoolAdmission.Engine.Configuration
{
    public class AdmissionEngineConfigurationSection:ConfigurationSection
    {

        [ConfigurationProperty("mailer", IsRequired =true)]
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

        [ConfigurationProperty("paymentProcessor", IsRequired =true)]
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
    }

    public class ProvideTypeElement:ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name {
            get
            {
                return (string)base["name"];
            }
            set
            {
                base["name"] = value;
            }
        }

        [ConfigurationProperty("type", IsRequired =true, IsKey =true)]
        public string Type {
            get
            {
                return (string)base["type"];
            }
            set
            {
                base["type"] = value;
            }
        }
            
    }

    public class MailerElement: ProvideTypeElement
    {
        [ConfigurationProperty("fromAddress", IsRequired = true, IsKey = true)]
        public string FromAddress
        {
            get
            {
                return (string)base["fromAddress"];
            }
        }

        [ConfigurationProperty("smtpServer", IsRequired = true, IsKey = true)]
        public string SmtpServer
        {
            get
            {
                return (string)base["smtpServer"];
            }
            set
            {
                base["smtpServer"] = value;
            }
        }
    }

    public class PaymentProcessorElement: ProvideTypeElement
    {
    }
}
