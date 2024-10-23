using RecruitmentSystem.Models;

namespace RecruitmentSystem
{
    public class RecruitmentSystem
    {
        private List<Vacancy> vacancies = new List<Vacancy>();

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
                Console.WriteLine("�������� �� �������.");
            }
        }
    }
}
