using Microsoft.AspNetCore.Routing.Matching;
using RecruitmentSystem.Enums;
using RecruitmentSystem.Interfaces;

namespace RecruitmentSystem.Models
{
    public class Candidate : IGeneral
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public StatusType Status { get; set; }
        public Test? TestResult { get; set; }
        public int HRSpecialistId { get; set; }

        public bool IsSuccessful { get; set; }

        public int VacancyId { get; set; }

        public Candidate(int id, string name)
        {
            Id = id;
            Name = name;
            Status = StatusType.InReview; 
        }

        public void UpdateStatus(StatusType newStatus)
        {
            Status = newStatus;
        }

        public override string ToString()
        {
            return $"{Name} ({Id}) - Status: {Status}";
        }

        public void MarkSuccessful(Vacancy vacancy)
        {
            if (VacancyId == vacancy.Id)
            {
                IsSuccessful = true;
            }
            else
            {
                Console.WriteLine("Ошибка: Кандидат не подал заявку на эту вакансию.");
            }
        }

        public bool HasPassed(Vacancy vacancy)
        {
            return IsSuccessful && VacancyId == vacancy.Id;
        }
    }
}
