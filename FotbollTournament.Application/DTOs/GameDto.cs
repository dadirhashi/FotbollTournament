using System.ComponentModel.DataAnnotations;
namespace FotbollTournament.Application.DTOs
{
    public class GameDto
    {
        public int GameId { get; set; }
        public DateTime KickOff { get; set; }
        public string HomeTeamName { get; set; } = string.Empty;
        public string AwayTeamName { get; set; } = string.Empty;
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
