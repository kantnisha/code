using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.Common.Modules
{
    public class AdjustSubjectAvailabilityModule : IAdmissionModule
    {
        public void Initialize(AdmissionEvents events)
        {
            events.AdjustAvailability += OnAdjustAvailability;
            
        }

        private void OnAdjustAvailability(AdjustSubjectAvailabilityEventArgs e)
        {
            double fee = 0;
            foreach (var subject in e.AdmissionData.OptingSubjectsData)
            {
                if (e.AdmissionEvents.AdmissionDataProcessed != null)
                {
                    AdmissionDataProcessedEventArgs args = new AdmissionDataProcessedEventArgs(e.Student, subject);
                    e.AdmissionEvents.AdmissionDataProcessed(args);
                    if (args.Cancel)
                    {
                        continue;
                    }
                }
                
                var seatAvailability = e.SchoolRepository.SubjectAvailability.Where(s => s.Id == subject.SubjectId).FirstOrDefault().SeatsAvailable;
                e.SchoolRepository.SubjectAvailability.Where(s => s.Id == subject.SubjectId).FirstOrDefault().SeatsAvailable = seatAvailability - 1;
                Console.WriteLine("Subject availability for subject {0} reduced by 1 for {1} months", subject.SubjectId, subject.NoOfMonths);
                Console.WriteLine(string.Format("Enrolled student {0} in subject {1} for {2} months",e.Student.Name, subject.SubjectId, subject.NoOfMonths));

                fee += subject.TutionFeePerMonth * subject.NoOfMonths;
            }

            e.Fee = fee;
        }
    }
}
