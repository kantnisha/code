using SchoolAdmission.Engine.DataModels;
using System.Collections.Generic;

namespace SchoolAdmission.Common.DataModels
{
    public class AdmissionData
    {
        public string StudentEmail { get; set; }
        public string CreditCard { get; set; }
        public string ExpirationDate { get; set; }
        public List<OptingSubjectData> OptingSubjectsData { get; set; }
    }
}
