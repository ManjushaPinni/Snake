using Snake.Models;

namespace Snake.Services
{
    public interface ILeaderBoardService
    {
        LeaderBoardRecords GetRecords();
        LeaderBoardRecords GetOrderedRecords();
        void AddRecord(ref LeaderBoardRecords leaderBoardRecords, Record record);
    }

    public class LeaderBoardService : ILeaderBoardService
    {
        public LeaderBoardRecords GetRecords() { return new LeaderBoardRecords(); }

        public LeaderBoardRecords GetOrderedRecords() { return new LeaderBoardRecords(); }

        public void AddRecord(ref LeaderBoardRecords leaderBoardRecords, Record record) { }
    }
}
