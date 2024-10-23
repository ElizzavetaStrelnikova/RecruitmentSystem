using RecruitmentSystem.Enums;
using RecruitmentSystem.Interfaces;

namespace RecruitmentSystem.Models
{
    public abstract class Candidate : IGeneral
    {
        private string _name;
        private int _id;
        public string Email { get; set; }
        public StatusType Status { get; set; }
        public Test? TestResult { get; set; }

        public Candidate(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int Id => _id;

        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}
