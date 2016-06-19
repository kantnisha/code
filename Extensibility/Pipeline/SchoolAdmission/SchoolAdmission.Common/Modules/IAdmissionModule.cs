using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.Common.Modules
{
    public interface IAdmissionModule
    {
        void Initialize(AdmissionEvents events);
    }
}
