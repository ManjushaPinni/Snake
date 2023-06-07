using Microsoft.AspNetCore.Mvc;
using Snake.Models;
using Snake.Services;

namespace Snake.Controllers
{
    [ApiController]
    [Route("LeaderBoard")]
    public class LeaderBoardController : ControllerBase
    {
        private readonly LeaderBoardRecords LeaderBoardData = new LeaderBoardRecords();

        private readonly ILogger<LeaderBoardController> _logger;
        private readonly ILeaderBoardService _leaderBoardService;

        public LeaderBoardController(ILogger<LeaderBoardController> logger, ILeaderBoardService leaderBoardService)
        {
            _logger = logger;
            _leaderBoardService = leaderBoardService;
        }

        [HttpGet("/GetRecords")]
        public IActionResult GetRecords() { return Ok(); }

        [HttpGet("/GetOrderedRecords")]
        public IActionResult GetOrderdRecords() { return Ok(); }


        [HttpPost("/AddScore")]
        public IActionResult AddScore(ref LeaderBoardRecords leaderBoardRecords, [FromBody] Record record) { return Ok(); }
    }
}