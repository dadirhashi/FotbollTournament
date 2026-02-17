using System.ComponentModel.DataAnnotations;
namespace FotbollTournament.DTOS
{
    public class GameDto
    {
         
        [Required(ErrorMessage ="Star Date required")]
        public DateTime GameDate { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }


        public string? HomeTeamName { get; set; }
        public string? AwayTeamName { get; set; }
    }
}
