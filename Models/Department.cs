
using RecruitmentSystem.Interfaces;

namespace RecruitmentSystem.Models
{
    public abstract class Department : IGeneral
    {
        public int Id { get; }
        public string Name { get; set; }
        public HRSpecialist Specialist { get; private set; }

        protected Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AssignSpecialist(HRSpecialist specialist)
        {
            Specialist = specialist;
        }
    }
}
