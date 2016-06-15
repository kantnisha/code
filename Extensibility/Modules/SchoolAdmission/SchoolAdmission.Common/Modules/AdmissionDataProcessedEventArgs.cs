using SchoolAdmission.Common.DataModels;
using SchoolAdmission.Common.Entities;
using SchoolAdmission.Engine.DataModels;
using System.ComponentModel;

namespace SchoolAdmission.Common.Modules
{
    public class AdmissionDataProcessedEventArgs : CancelEventArgs
    {
        public AdmissionDataProcessedEventArgs(Student student, OptingSubjectData admissionData)
        {
            this.Student = student;
            this.AdmissionData = admissionData;
            this.MessageText = string.Empty;

        }

        public Student Student { get; set; }
        public OptingSubjectData AdmissionData { get; set; }
        public string MessageText { get; set; }
    }
}
