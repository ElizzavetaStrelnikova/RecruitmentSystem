using RecruitmentSystem.Models;
using System.Text.Json;
using Xunit;

namespace RecruitmentSystem.RecruitmentSystemTests
{
    public class RecruitmentSystemTests
    {
        private readonly RecruitmentSystem recruitmentSystem;

        public RecruitmentSystemTests()
        {
            recruitmentSystem = new RecruitmentSystem();
            LoadTestData();
        }

        private void LoadTestData()
        {
            var jsonData = File.ReadAllText("Vacancies.json");
            var testData = JsonSerializer.Deserialize<TestData>(jsonData);

            if (testData?.Vacancies == null)
            {
                throw new InvalidOperationException("No vacancies found in the test data.");
            }

            foreach (var vacancyData in testData.Vacancies)
            {
                var vacancy = new Vacancy(vacancyData.Id, vacancyData.Description)
                {
                    IsClosed = vacancyData.IsClosed
                };
                recruitmentSystem.AddVacancy(vacancy);
            }
        }

        [Fact]
        public void CloseVacancy_ShouldCalculateKPI_WhenAllCandidatesPassed()
        {
            var vacancyId = 1;

            var candidates = recruitmentSystem.GetCandidates(vacancyId);
            foreach (var candidate in candidates)
            {
                recruitmentSystem.MarkCandidateSuccessful(vacancyId, candidate.Id);
            }

            recruitmentSystem.CloseVacancy(vacancyId);

            var hrSpecialist = recruitmentSystem.GetHRSpecialist(1);
            double expectedKpi = 1.0;
            Assert.Equal(expectedKpi, hrSpecialist.KPI);
        }
    }
}

