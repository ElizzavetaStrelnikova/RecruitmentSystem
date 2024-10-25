
using RecruitmentSystem.Interfaces;

namespace RecruitmentSystem.Models
{
    public class HRSpecialist : IGeneral
    {
        public int Id { get; }
        public string Name { get; set; }
        public double KPI { get; private set; }
        protected HRSpecialist(int id, string name)
        {
            if (id < 0) throw new ArgumentException("Id не может быть отрицательным", nameof(id));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Имя не может быть пустым", nameof(name));

            Id = id;
            Name = name;
            KPI = 0.0; 
        }

        public void IncrementKPI(double value)
        {
            if (value < 0) throw new ArgumentException("Значение должно быть неотрицательным", nameof(value));
            KPI += value;
        }
        public void AddVacancy(Vacancy vacancy) { }
        public void CloseVacancy(int vacancyId) { }
    }
}
