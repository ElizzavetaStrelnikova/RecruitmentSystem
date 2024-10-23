using RecruitmentSystem.Models;
using System.Net.Http.Headers;

namespace RecruitmentSystem.Services
{
    public class RecruitmentSystemService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ILogger<RecruitmentSystemService> _logger;
        private readonly RecruitmentSystem _recruitmentSystem;

        public RecruitmentSystemService(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            ILogger<RecruitmentSystemService> logger,
            RecruitmentSystem recruitmentSystem)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _logger = logger;
            _recruitmentSystem = recruitmentSystem;
        }

        public async Task AddVacancyAsync(Vacancy vacancy)
        {
            await Task.Run(() => _recruitmentSystem.AddVacancy(vacancy));
            _logger.LogInformation($"Vacancy '{vacancy.Name}' added.");
        }

        public async Task CloseVacancyAsync(int vacancyId)
        {
            await Task.Run(() => _recruitmentSystem.CloseVacancy(vacancyId));
            _logger.LogInformation($"Vacancy with ID '{vacancyId}' closed.");
        }

        public async Task<List<Candidate>> GetCandidatesAsync(string position = null)
        {
            return await Task.Run(() => _recruitmentSystem.GetCandidates(position));
        }
    }
}
