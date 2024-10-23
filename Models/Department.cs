
using RecruitmentSystem.Interfaces;

namespace RecruitmentSystem.Models
{
    public abstract class Department : IGeneral
    {
        private string _name;
        private int _id;
        public Department(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int Id
        {
            get => _id;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public HRSpecialist Specialist { get; set; }
    }
}
