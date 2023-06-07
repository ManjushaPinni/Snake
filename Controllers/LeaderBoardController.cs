using Microsoft.AspNetCore.Mvc;
using Snake.Services;

namespace Snake.Controllers
{
    [ApiController]
    [Route("LeaderBoard")]
    public class LeaderBoardController : ControllerBase
    {
        private readonly ILogger<LeaderBoardController> _logger;
        private readonly ILeaderBoardService _leaderBoardService;

        public LeaderBoardController(ILogger<LeaderBoardController> logger, ILeaderBoardService leaderBoardService)
        {
            _logger = logger;
            _leaderBoardService = leaderBoardService;
        }

        [HttpGet("/GetScores")]
        public IActionResult GetScores() { return Ok(); }

        [HttpGet("/GetOrderedScores")]
        public IActionResult GetOrderdScores() { return Ok(); }


        [HttpPost("/AddScore")]
        public IActionResult AddScore() { return Ok(); }
    }
}