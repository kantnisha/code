using SchoolAdmission.Engine.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolAdmission.Common.Contracts;
using SchoolAdmission.Engine.Configuration;
using System.Configuration;
using SchoolAdmission.Common.Modules;

namespace SchoolAdmission.Engine.Factory
{
    public class ComponentFactory : IComponentFactory
    {
        private AdmissionEvents admissionEvent = null;
        private AdmissionEngineConfigurationSection config;
        public ComponentFactory()
        {
            config = ConfigurationManager.GetSection("admissionEngine") as AdmissionEngineConfigurationSection;

            admissionEvent = new AdmissionEvents();

            foreach(ModuleElement elm in config.Modules)
            {
                IAdmissionModule module = Activator.CreateInstance(Type.GetType(elm.Type)) as IAdmissionModule;
                module.Initialize(admissionEvent);
            }

        }
        public IMailer Mailer
        {
            get
            {
                var mailer = Activator.CreateInstance(Type.GetType(config.Mailer.Type)) as IMailer;
                mailer.FromAddress = config.Mailer.FromAddress;
                mailer.SmtpServer = config.Mailer.SmtpServer;
                return mailer;
            }
        }

        public IPaymentProcessor PaymentProcessor
        {
            get
            {
                return Activator.CreateInstance(Type.GetType(this.config.PaymentProcessor.Type)) as IPaymentProcessor;
            }
        }

        public AdmissionEvents GetEvents()
        {
            return admissionEvent;
        }
    }
}
