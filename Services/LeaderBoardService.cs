using Snake.Models;

namespace Snake.Services
{
    public interface ILeaderBoardService
    {
        List<LeaderBoard> GetScores();
        List<LeaderBoard> GetOrderedScores();
    }

    public class LeaderBoardService : ILeaderBoardService
    {
        public List<LeaderBoard> GetScores() { return new List<LeaderBoard>(); }

        public List<LeaderBoard> GetOrderedScores() { return new List<LeaderBoard>(); }

        public void AddScore() {  }
    }
}
