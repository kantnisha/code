using SchoolAdmission.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.Contracts
{
    public interface ISchoolRepository
    {
        List<Student> Students { get; }
        List<Subject> Subjects { get; }
        List<SubjectAvailability> SubjectAvailability { get; }
        Student GetStudentByEmail(string email);
    }
}
