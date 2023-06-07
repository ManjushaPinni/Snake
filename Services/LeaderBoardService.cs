using Snake.Models;

namespace Snake.Services
{
    public interface ILeaderBoardService
    {
        LeaderBoardRecords GetRecords();
        LeaderBoardRecords GetOrderedRecords(ref LeaderBoardRecords leaderBoardRecords);
        int AddRecord(ref LeaderBoardRecords leaderBoardRecords, Record record);
    }

    public class LeaderBoardService : ILeaderBoardService
    {
        public LeaderBoardRecords GetRecords() { return new LeaderBoardRecords(); }

        public LeaderBoardRecords GetOrderedRecords(ref LeaderBoardRecords leaderBoardRecords) 
        {
            LeaderBoardRecords sortedLeaderBoardRecords = new LeaderBoardRecords();
            sortedLeaderBoardRecords.RecordsList = leaderBoardRecords.RecordsList.OrderByDescending(o => o.Score).ToList();

            return sortedLeaderBoardRecords; 
        }

        public int AddRecord(ref LeaderBoardRecords leaderBoardRecords, Record record) 
        {
            string recordId = GetRecordIdByUserName(ref leaderBoardRecords, record);
            if (!string.IsNullOrEmpty(recordId))
                UpdateExistingRecord(ref leaderBoardRecords, record);
            else
                recordId = AddNewRecord(ref leaderBoardRecords, record);

            return GetRecordRank(ref leaderBoardRecords, recordId);
        }

        private string AddNewRecord(ref LeaderBoardRecords leaderBoardRecords, Record record)
        {
            Record newRecord = IntialiseRecord(record);
            leaderBoardRecords.RecordsList.Add(newRecord);

            return newRecord.Id;
        }

        private int UpdateExistingRecord(ref LeaderBoardRecords leaderBoardRecords, Record record)
        {
            Record existingRecord = leaderBoardRecords.RecordsList.FirstOrDefault(o => o.Id.Equals(record.Id));
            if (record.Score > existingRecord.Score)
            {
                leaderBoardRecords.RecordsList.FirstOrDefault(o => o.Id.Equals(record.Id)).Score = record.Score;
                leaderBoardRecords.RecordsList.FirstOrDefault(o => o.Id.Equals(record.Id)).TimeStamp = DateTime.Now;
            }

            return GetRecordRank(ref leaderBoardRecords, leaderBoardRecords.RecordsList.FirstOrDefault(o => o.Id.Equals(record.Id)).Id);
        }

        private string GetRecordIdByUserName(ref LeaderBoardRecords leaderBoardRecords, Record record)
        {
            return leaderBoardRecords.RecordsList.FirstOrDefault(o => o.UserName.Equals(record.UserName)).Id;
        }

        private int GetRecordRank(ref LeaderBoardRecords leaderBoardRecords, string recordId)
        {
            LeaderBoardRecords sortedLeaderBoardRecords = GetOrderedRecords(ref leaderBoardRecords);

            return (sortedLeaderBoardRecords.RecordsList.FindIndex(o => o.Id.Equals(recordId)) + 1);
        }

        private Record IntialiseRecord(Record record)
        {
            record.Id = "REC" + Guid.NewGuid().ToString();
            record.TimeStamp = DateTime.Now;
            return record;
        }
    }
}
