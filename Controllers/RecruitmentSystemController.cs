using Microsoft.AspNetCore.Mvc;

namespace RecruitmentSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecruitmentSystemController : ControllerBase
    {
        private readonly ILogger<RecruitmentSystemController> _logger;

        public RecruitmentSystemController(ILogger<RecruitmentSystemController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCandidates")]
        public IEnumerable<RecruitmentSystem> Get()
        {
            
        }
    }
}
