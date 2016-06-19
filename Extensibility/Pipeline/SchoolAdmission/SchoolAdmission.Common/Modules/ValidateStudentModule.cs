using SchoolAdmission.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.Common.Modules
{
    public class ValidateStudentModule : IAdmissionModule
    {
        public void Initialize(AdmissionEvents events)
        {
            events.ValidateStudent += OnStudentValidate;
        }

        private void OnStudentValidate(ValidateStudentEventArgs e)
        {
            Student student = e.SchoolRepository.GetStudentByEmail(e.AdmissionData.StudentEmail);
            if (student == null)
            {
                throw new ApplicationException(string.Format("No student found with email:{0}", e.AdmissionData.StudentEmail));
            }

            e.Student = student;
        }
    }
}
