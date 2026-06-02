using System.ComponentModel.DataAnnotations;
namespace FotbollTournament.DTOS
{
    public class TeamDto
    {
        public int TeamId { get; set; }
       [Required (ErrorMessage = "Team name is required")]
        public string TeamName { get; set; }
        [Required (ErrorMessage ="TournamentId requird")]
        public int TournamentId { get; set; }
        [Required(ErrorMessage = "Coach name is required")]
        public string CoachName { get; set; }

        
    }
}
