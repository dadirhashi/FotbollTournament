using System.ComponentModel.DataAnnotations;
namespace FotbollTournament.DTOS
{
    public class PlayerDto
    {
        [Required (ErrorMessage = "First name is required")] 
        public string FirstName { get; set; }
        [Required (ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        public string Position { get; set; }
    }
}
