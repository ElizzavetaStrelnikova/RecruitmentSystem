
using RecruitmentSystem.Enums;
using RecruitmentSystem.Interfaces;

namespace RecruitmentSystem.Models
{
    public abstract class Vacancy : IGeneral
    {
        public int Id { get; }
        public string Description { get; set; }
        public bool IsClosed { get; private set; }
        public Department Department { get; set; }
        public List<Candidate> Candidates { get; private set; } = new List<Candidate>();
        public Vacancy(int id, string description)
        {
            Id = id;
            Description = description;
            IsClosed = false;
        }
        public bool MarkCandidateSuccessful(int candidateId)
        {
            var candidate = Candidates.FirstOrDefault(c => c.Id == candidateId);
            if (candidate == null)
            {
                throw new KeyNotFoundException($"Кандидат с ID {candidateId} не найден.");
            }

            if (candidate.Status == StatusType.HasPassedProbation)
            {
                throw new InvalidOperationException($"Кандидат с ID {candidateId} уже прошёл испытательный срок.");
            }

            candidate.UpdateStatus(StatusType.HasPassedProbation);

            if (Candidates.All(c => c.Status == StatusType.HasPassedProbation))
            {
                IsClosed = true;
            }

            return true;
        }

        public void Close()
        {
            IsClosed = true; 
        }
    }
}
