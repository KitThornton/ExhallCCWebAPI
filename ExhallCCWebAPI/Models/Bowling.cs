namespace ExhallCCWebAPI.Models
{
    public class Bowling
    {
        public int BowlingId { get; set; }
        public int PlayerId { get; set; }
        public int Year { get; set; }
        public int Overs { get; set; }
        public int Maidens { get; set; }
        public int Runs { get; set; }
        public int Wickets { get; set; }
        public decimal Average { get; set; }
        public int FiveWicketHauls { get; set; }
        public int BestFigsRuns { get; set; }
        public int BestFigsWickets { get; set; }
    }
}