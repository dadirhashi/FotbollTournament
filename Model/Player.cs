namespace FotbollTournament.Model
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;

        // Foreign key
        public int TeamId { get; set; }

        // Navigation
        public Team Team { get; set; }
    }
}
