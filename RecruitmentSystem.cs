using Microsoft.AspNetCore.Routing.Matching;
using RecruitmentSystem.Enums;
using RecruitmentSystem.Models;

namespace RecruitmentSystem
{
    public class RecruitmentSystem
    {
         private List<Vacancy> vacancies = new List<Vacancy>();
         private List<Candidate> candidates = new List<Candidate>();
         private List<HRSpecialist> hrSpecialists = new List<HRSpecialist>();

         public void AddVacancy(Vacancy vacancy)
         {
             if (vacancy == null)
             {
                 Console.WriteLine("Ошибка: Вакансия не может быть null.");
                 return;
             }

             vacancies.Add(vacancy);
             Console.WriteLine($"Вакансия '{vacancy.Description}' добавлена.");
         }

        public void CloseVacancy(int vacancyId)
        {
            var vacancy = vacancies.FirstOrDefault(v => v.Id == vacancyId);
            if (vacancy != null && !vacancy.IsClosed)
            {
                if (AllCandidatesPassed(vacancy))
                {
                    vacancy.Close(); 
                    Console.WriteLine($"Вакансия '{vacancy.Description}' закрыта.");
                    CalculateKPI();
                }
                else
                {
                    Console.WriteLine("Ошибка: Не все кандидаты прошли отбор. Вакансия не может быть закрыта.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: Вакансия не найдена или уже закрыта.");
            }
        }
        public List<Candidate> GetCandidates(string position = null)
        {
            return string.IsNullOrEmpty(position)
                ? candidates
                : candidates.Where(c => c.Position.Contains(position, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        private bool AllCandidatesPassed(Vacancy vacancy)
        {
            var candidatesInReview = candidates.Where(c => c.Status == StatusType.InReview && c.Position == vacancy.Description);
            return !candidatesInReview.Any();
        }
        private void CalculateKPI()
        {
            foreach (var hr in hrSpecialists)
            {
                var candidatesForHr = candidates.Where(c => c.HRSpecialistId == hr.Id && c.Status == StatusType.HasPassedProbation);

                hr.IncrementKPI(candidatesForHr.Count());
            }
        }
    }
}
