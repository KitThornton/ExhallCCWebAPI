using System.ComponentModel.DataAnnotations;

namespace ExhallCCWebAPI.Models
{
    public class Batting
    {
        [Key] public int BattingId { get; set; }
        public int PlayerId { get; set; }
        public int? Year { get; set; }
        public int Matches { get; set; }
        public int Innings { get; set; }
        public int NotOuts { get; set; }
        public decimal? Average { get; set; }
        public int Runs { get; set; }
        public int Fifties { get; set; }
        public int Hundreds { get; set; }
        public int HighScore { get; set; }
        public bool HighScoreNotOut { get; set; }
    }
}