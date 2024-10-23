
using RecruitmentSystem.Interfaces;

namespace RecruitmentSystem.Models
{
    public abstract class Vacancy : IGeneral
    {
        private string _name;
        private int _id;
        public Vacancy(int id, string name)
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
        public string Description { get; set; }
        public bool IsClosed { get; set; } 
        public Department Department { get; set; }

        public List<Candidate> Candidates { get; set; } = new List<Candidate>();
    }
}
