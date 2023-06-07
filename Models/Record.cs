﻿namespace Snake.Models
{
    public class LeaderBoardRecords
    {
        public List<Record> RecordsList {  get; set; }
    }
    public class Record
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public double Score { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
