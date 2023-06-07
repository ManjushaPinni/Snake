namespace Snake.Models
{
    public class LeaderBoardRecords
    {
        public List<Record> ScoresList {  get; set; }
    }
    public class Record
    {
        public string UserName { get; set; }

        public double Score { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
