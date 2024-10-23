using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Models;
using RecruitmentSystem.Services;

namespace RecruitmentSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecruitmentSystemController : ControllerBase
    {
        private readonly RecruitmentSystemService _recruitmentSystemService;
        private readonly ILogger<RecruitmentSystemController> _logger;

        public RecruitmentSystemController(RecruitmentSystemService recruitmentSystemService, ILogger<RecruitmentSystemController> logger)
        {
            _recruitmentSystemService = recruitmentSystemService;
            _logger = logger;
        }

        [HttpGet("candidates", Name = "GetCandidates")]
        [Route("/resumes?text={position}")]
        public async Task<IActionResult> GetCandidates([FromQuery] string position)
        {
            try
            {
                var candidates = await _recruitmentSystemService.GetCandidatesAsync(position);

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

        [HttpPost("vacancies", Name = "AddVacancy")]
        public async Task<IActionResult> AddVacancy([FromBody] Vacancy vacancy)
        {
            if (vacancy == null)
            {
                return BadRequest("Vacancy is null.");
            }

            try
            {
                await _recruitmentSystemService.AddVacancyAsync(vacancy);
                return CreatedAtAction(nameof(GetCandidates), new { id = vacancy.Id }, vacancy);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a vacancy.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpPut("vacancies/{id}", Name = "CloseVacancy")]
        public async Task<IActionResult> CloseVacancy(int id)
        {
            try
            {
                await _recruitmentSystemService.CloseVacancyAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while closing a vacancy.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
