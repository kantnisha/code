using SchoolAdmission.Common.Contracts;
using SchoolAdmission.Common.DataModels;
using SchoolAdmission.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.Common.Modules
{
    public class ValidateStudentEventArgs:EventArgs
    {
        public ValidateStudentEventArgs(ISchoolRepository schoolRepository, AdmissionData admissionData)
        {
            this.SchoolRepository = schoolRepository;
            this.AdmissionData = admissionData;
        }

        public ISchoolRepository SchoolRepository { get; set; }
        public Student Student { get; set; }
        public AdmissionData AdmissionData { get; set; }

    }
}
