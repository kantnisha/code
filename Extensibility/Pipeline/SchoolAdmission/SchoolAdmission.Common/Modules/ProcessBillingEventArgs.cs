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
    public class ProcessBillingEventArgs:EventArgs
    {
        public ProcessBillingEventArgs(AdmissionData admissionData, ISchoolRepository schoolRepo, Student student, double fee, IPaymentProcessor paymentProcessor)
        {
            this.SchoolRepository = schoolRepo;
            this.AdmissionData = admissionData;
            this.Student = student;
            this.Fee = fee;
            this.PaymentProcessor = paymentProcessor;
        }

        public AdmissionData AdmissionData { get; set; }
        public ISchoolRepository SchoolRepository { get; set; }
        public Student Student { get; set; }
        public IPaymentProcessor PaymentProcessor { get; set; }
        public double Fee { get; set; }
        public bool PaymentSuccess { get; set; }
    }
}
