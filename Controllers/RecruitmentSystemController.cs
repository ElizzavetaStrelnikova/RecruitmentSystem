using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecruitmentSystemController : ControllerBase
    {
        private readonly RecruitmentSystem _recruitmentSystem;
        private readonly ILogger<RecruitmentSystemController> _logger;

        public RecruitmentSystemController(RecruitmentSystem recruitmentSystem, ILogger<RecruitmentSystemController> logger)
        {
            _recruitmentSystem = recruitmentSystem;
            _logger = logger;
        }

        [HttpGet("vacancies", Name = "GetVacancies")]
        public IEnumerable<Vacancy> GetVacancies()
        {
            return _recruitmentSystem.GetVacancies();
        }
    }
}
