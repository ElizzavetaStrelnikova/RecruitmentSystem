using RecruitmentSystem.Enums;
using RecruitmentSystem.Models;

namespace RecruitmentSystem
{
    public class RecruitmentSystem
    {
        private List<Vacancy> vacancies = new List<Vacancy>();
        private List<Candidate> candidates = new List<Candidate>();

        public void AddVacancy(Vacancy vacancy)
        {
            vacancies.Add(vacancy);
            Console.WriteLine($"�������� '{vacancy.Name}' ���������.");
        }

        public void CloseVacancy(int vacancyId)
        {
            var vacancy = vacancies.Find(v => v.Id == vacancyId);
            if (vacancy != null && !vacancy.IsClosed)
            {
                vacancy.IsClosed = true;
                Console.WriteLine($"�������� '{vacancy.Name}' �������.");
            }
            else
            {
                Console.WriteLine("�������� �� ������� ��� ��� �������.");
            }
        }

        public List<Vacancy> GetVacancies(string position = null, string skill = null)
        {
            var vacanciesQuery = vacancies.AsQueryable();

            if (!string.IsNullOrEmpty(position))
            {
                vacanciesQuery = vacanciesQuery.Where(v => v.Name.Contains(position, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(skill))
            {
                vacanciesQuery = vacanciesQuery.Where(v => v.Description.Contains(skill, StringComparison.OrdinalIgnoreCase));
            }

            return vacanciesQuery.Where(v => !v.IsClosed).ToList();
        }

        public List<Candidate> GetCandidates(string position = null)
        {
            return candidates.Where(v => v.Position.Contains(position, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
