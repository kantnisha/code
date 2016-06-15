using System.Configuration;

namespace SchoolAdmission.Engine.Configuration
{
    public class MailerElement : ProvideTypeElement
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
}
