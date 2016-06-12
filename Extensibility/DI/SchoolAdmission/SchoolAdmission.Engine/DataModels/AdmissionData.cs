using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.Engine.DataModels
{
    public class AdmissionData
    {
        public string StudentEmail { get; set; }
        public string CreditCard { get; set; }
        public string ExpirationDate { get; set; }
        public List<OptingSubjectData> OptingSubjectsData { get; set; }
    }
}
