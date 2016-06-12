using SchoolAdmission.Contracts;
using SchoolAdmission.Engine.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SchoolAdmission.Engine.DataAccess
{
    public class SchoolRepository: ISchoolRepository
    {
        List<Student> students = null;
        List<Subject> subjects = null;
        List<SubjectAvailability> subjectAvailability = null;

        public SchoolRepository()
        {
            Initialize();
        }

        public List<Student> Students
        {
            get
            {
                return students;
            }
        }

        public List<Subject> Subjects
        {
            get
            {
                return subjects;
            }
        }

        public List<SubjectAvailability> SubjectAvailability
        {
            get
            {
                return subjectAvailability;
            }
        }

        private void Initialize()
        {
            students = new List<Student>
            {
                new Student() {Id=1, EmailId="luv@gmail.com",Name="Luv Mishra" },
                new Student() {Id=2, EmailId="kush@gmail.com", Name="Kush Mishra" },
                new Student() {Id=3, EmailId="ankit@gmail.com", Name="Ankit Mishra" },
                new Student() {Id=4, EmailId="anurag@gmail.com", Name="Anurag Mishra" }
            };

            subjects = new List<Subject>()
            {
                new Subject() {Id=1, Name="English", Description="English literature" },
                new Subject() {Id=2, Name="History", Description="Indian history" },
                new Subject() {Id=3, Name="Maths", Description="Algebra and triginametry" },
                new Subject() {Id=4, Name="Geography", Description="Geo physical structure if earth" },
                new Subject() {Id=5, Name="Civics", Description="Indian constitution" },
                new Subject() {Id=6, Name="Physics", Description="Quantum physics" },
                new Subject() {Id=7, Name="Chemistry", Description="Organic and non-organic chemistry" }
            };

            subjectAvailability = new List<SubjectAvailability>()
            {
                new SubjectAvailability() {Id=1, SeatsAvailable=9 },
                new SubjectAvailability() {Id=2, SeatsAvailable=20 },
                new SubjectAvailability() {Id=3, SeatsAvailable=5 },
                new SubjectAvailability() {Id=4, SeatsAvailable=7 },
                new SubjectAvailability() {Id=5, SeatsAvailable=8 },
                new SubjectAvailability() {Id=6, SeatsAvailable=1 },
                new SubjectAvailability() {Id=7, SeatsAvailable=10 }
            };
        }

        public Student GetStudentByEmail(string email)
        {
            return this.Students.Where(s => s.EmailId == email).FirstOrDefault();
        }
    }
}
