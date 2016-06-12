using Microsoft.Practices.Unity;
using SchoolAdmission.Contracts;
using SchoolAdmission.Engine;
using SchoolAdmission.Engine.Contracts;
using SchoolAdmission.Engine.DataAccess;
using SchoolAdmission.Engine.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.Client
{
    class Program
    {
        public static void Main()
        {
            UnityContainer diContainer = new UnityContainer();
            diContainer.RegisterType<ISchoolRepository, SchoolRepository>()
                .RegisterType<IMailer, Mailer>()
                .RegisterType<IPaymentProcessor, PaymentProcessor>();
            AdmissionData admissionData = new AdmissionData()
            {
                StudentEmail = "luv@gmail.com",
                CreditCard = "4622735220077467",
                ExpirationDate = "1220",
                OptingSubjectsData = new List<OptingSubjectData>()
                {
                        new OptingSubjectData() {SubjectId=1, NoOfMonths=5, TutionFeePerMonth=540 },
                        new OptingSubjectData() {SubjectId=2, NoOfMonths=4, TutionFeePerMonth=540 },
                        new OptingSubjectData() {SubjectId=3, NoOfMonths=6, TutionFeePerMonth=540 },
                        new OptingSubjectData() {SubjectId=4, NoOfMonths=8, TutionFeePerMonth=540 },
                }
            };

            AdmissionManager admissionManager = new AdmissionManager(diContainer.Resolve<ISchoolRepository>(),
                diContainer.Resolve<IPaymentProcessor>(), 
                diContainer.Resolve<IMailer>());
            admissionManager.ProcessAdmission(admissionData);
            Console.ReadLine();
        }
    }
}
