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
                 Console.WriteLine("������: �������� �� ����� ���� null.");
                 return;
             }

             vacancies.Add(vacancy);
             Console.WriteLine($"�������� '{vacancy.Description}' ���������.");
         }

        public void CloseVacancy(int vacancyId)
        {
            var vacancy = vacancies.FirstOrDefault(v => v.Id == vacancyId);
            if (vacancy != null && !vacancy.IsClosed)
            {
                if (AllCandidatesPassed(vacancy))
                {
                    vacancy.Close(); 
                    Console.WriteLine($"�������� '{vacancy.Description}' �������.");
                    CalculateKPI();
                }
                else
                {
                    Console.WriteLine("������: �� ��� ��������� ������ �����. �������� �� ����� ���� �������.");
                }
            }
            else
            {
                Console.WriteLine("������: �������� �� ������� ��� ��� �������.");
            }
        }

        public List<Candidate> GetCandidates(int vacancyId)
        {
            return candidates.Where(c => c.VacancyId == vacancyId).ToList();
        }

        public HRSpecialist GetHRSpecialist(int specialistId)
        {
            return hrSpecialists.FirstOrDefault(hr => hr.Id == specialistId);
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

        public void MarkCandidateSuccessful(int candidateId, int vacancyId)
        {
            var vacancy = vacancies.FirstOrDefault(v => v.Id == vacancyId);
            var candidate = candidates.FirstOrDefault(c => c.Id == candidateId);

            if (vacancy == null)
            {
                Console.WriteLine("������: �������� �� �������.");
                return;
            }

            if (candidate == null)
            {
                Console.WriteLine("������: �������� �� ������.");
                return;
            }

            if (vacancy.IsClosed)
            {
                Console.WriteLine("������: �������� ��� �������.");
                return;
            }

            candidate.MarkSuccessful(vacancy);
            Console.WriteLine($"�������� '{candidate.Name}' ��� ������� ��� �������� ��� �������� '{vacancy.Description}'.");
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
