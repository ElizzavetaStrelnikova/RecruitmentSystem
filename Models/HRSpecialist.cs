
using RecruitmentSystem.Interfaces;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace RecruitmentSystem.Models
{
    public abstract class HRSpecialist : IGeneral
    {
        private string _name;
        private int _id;
        public HRSpecialist(int id, string name)
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

        public abstract void AddVacancy();
        public abstract void CloseVacancy();
        public abstract void AddCandidant();
        public abstract void EvaluateCandidant();
    }
}
