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
        [Route("[controller]")]
        public IActionResult GetVacancies(string position = null, string skill = null)
        {
            try
            {
                var vacancies = _recruitmentSystem.GetVacancies(position, skill);

                if (vacancies == null || !vacancies.Any())
                {
                    _logger.LogWarning("No vacancies found for the specified criteria.");
                    return NotFound("No vacancies found.");
                }

                return Ok(vacancies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching vacancies.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("candidates", Name = "GetCandidates")]
        [Route("/resumes?text={position}")]
        public IActionResult GetCandidates()
        {
            try
            {
                var candidates = _recruitmentSystem.GetCandidates();

                if (candidates == null || !candidates.Any())
                {
                    _logger.LogWarning("No candidates found.");
                    return NotFound("No candidates found.");
                }

                return Ok(candidates);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching candidates.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
