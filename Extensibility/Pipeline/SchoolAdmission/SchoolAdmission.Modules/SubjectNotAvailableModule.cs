using SchoolAdmission.Common.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.Modules
{
    public class SubjectNotAvailableModule : IAdmissionModule
    {
        public void Initialize(AdmissionEvents events)
        {
            events.AdmissionDataProcessed += OnAdmissionDataProcessed;
        }

        private void OnAdmissionDataProcessed(AdmissionDataProcessedEventArgs e)
        {
            if(e.AdmissionData.SubjectId == 2)
            {
                e.Cancel = true;
            }
        }
    }
}
