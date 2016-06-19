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
    public class AdjustSubjectAvailabilityEventArgs:EventArgs
    {
        public AdjustSubjectAvailabilityEventArgs(ISchoolRepository schoolRepository, Student student, AdmissionData admissionData, AdmissionEvents admissionEvents)
        {
            this.SchoolRepository = schoolRepository;
            this.Student = student;
            this.AdmissionEvents = admissionEvents;
            this.AdmissionData = admissionData;
        }

        public ISchoolRepository SchoolRepository { get; set; }
        public Student Student { get; set; }
        public AdmissionData AdmissionData { get; set; }
        public AdmissionEvents AdmissionEvents { get; set; }
        public double Fee { get; set; }
    }
}
