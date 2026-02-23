using System.ComponentModel.DataAnnotations;
namespace FotbollTournament.DTOS
{
    public class TeamDto
    {
       [Required (ErrorMessage = "Team name is required")]
        public string TeamName { get; set; }
        [Required (ErrorMessage = "Coach name is required")]
        public string CoachName { get; set; }

        public List<PlayerDto>? Players { get; set; }
    }
}
