using SchoolAdmission.Common.Entities;
using System.Collections.Generic;

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
