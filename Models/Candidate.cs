using Microsoft.AspNetCore.Routing.Matching;
using RecruitmentSystem.Enums;
using RecruitmentSystem.Interfaces;

namespace RecruitmentSystem.Models
{
    public abstract class Candidate : IGeneral
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public StatusType Status { get; set; }
        public Test? TestResult { get; set; }
        public int HRSpecialistId { get; set; }

        public Candidate(int id, string name)
        {
            Id = id;
            Name = name;
            Status = StatusType.InReview; 
        }

        public void UpdateStatus(StatusType newStatus)
        {
            Status = newStatus;
        }

        public override string ToString()
        {
            return $"{Name} ({Id}) - Status: {Status}";
        }
    }
}
