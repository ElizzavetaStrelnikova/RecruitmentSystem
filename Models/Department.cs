
using RecruitmentSystem.Interfaces;

namespace RecruitmentSystem.Models
{
    public class Department : IGeneral
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public HRSpecialist HRSpecialist { get; private set; }

        protected Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AssignSpecialist(HRSpecialist specialist)
        {
            HRSpecialist = specialist;
        }
    }
}
