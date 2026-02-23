using System.ComponentModel.DataAnnotations;

namespace FotbollTournament.DTOS
{
    public class TournamentDto
    {
        public int TournamentId { get; set; }

        [Required (ErrorMessage = "Tournament name is required")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Required (ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        public List<TeamDto>? Teams { get; set; }
       
    }
}
