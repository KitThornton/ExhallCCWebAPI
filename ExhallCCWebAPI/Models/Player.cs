using System.ComponentModel.DataAnnotations;

namespace ExhallCCWebAPI.Models
{
    public class Player
    {
        [Key] public int Id { get; set; }
        
        public string Name { get; set; }
    }
}