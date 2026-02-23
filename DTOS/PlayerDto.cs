using System.ComponentModel.DataAnnotations;
namespace FotbollTournament.DTOS
{
    public class PlayerDto
    {
        [Required (ErrorMessage ="Team id is required")]
        public int TeamId { get; set; } 
        public int PlayerId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        public string Position { get; set; }
    }
}
