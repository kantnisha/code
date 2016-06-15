using SchoolAdmission.Common.Contracts;
using SchoolAdmission.Common.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.Engine.Contracts
{
    public interface IComponentFactory
    {
        IPaymentProcessor PaymentProcessor { get; }
        IMailer Mailer { get; }
        AdmissionEvents GetEvents();
    }
}
