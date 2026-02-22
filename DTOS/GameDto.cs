using System.ComponentModel.DataAnnotations;
namespace FotbollTournament.DTOS
{
    public class GameDto
    {
        public DateTime GameDate { get; set; }

        [Required(ErrorMessage = "TournamentId required")]
        public int TournamentId { get; set; }
        [Required (ErrorMessage = "Game Id is required")]
        public int GameId { get; set; } 
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }

        public string? HomeTeamName { get; set; }
        public string? AwayTeamName { get; set; }

    }
}
