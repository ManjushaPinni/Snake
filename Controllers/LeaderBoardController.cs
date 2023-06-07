using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Snake.Models;
using Snake.Services;

namespace Snake.Controllers
{
    [ApiController]
    [Route("LeaderBoard")]
    public class LeaderBoardController : ControllerBase
    {
        private LeaderBoardRecords leaderBoardRecords = new LeaderBoardRecords();

        private readonly ILogger<LeaderBoardController> _logger;
        private readonly ILeaderBoardService _leaderBoardService;

        public LeaderBoardController(ILogger<LeaderBoardController> logger, ILeaderBoardService leaderBoardService)
        {
            _logger = logger;
            _leaderBoardService = leaderBoardService;
        }

        [HttpGet("/GetRecords")]
        public IActionResult GetRecords() 
        { 
            return Ok(JsonConvert.SerializeObject(leaderBoardRecords)); 
        }

        [HttpGet("/GetOrderedRecords")]
        public IActionResult GetOrderdRecords() 
        {
            LeaderBoardRecords sortedLeaderBoardRecords = _leaderBoardService.GetOrderedRecords(ref leaderBoardRecords) ;
            return Ok(JsonConvert.SerializeObject(sortedLeaderBoardRecords));
        }

        [HttpPost("/AddScore")]
        public IActionResult AddScore(ref LeaderBoardRecords leaderBoardRecords, [FromBody] Record record)
        {
            int recordRank = _leaderBoardService.AddRecord(ref leaderBoardRecords, record);
            return Ok(JsonConvert.SerializeObject(recordRank));
        }
    }
}