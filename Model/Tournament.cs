namespace FotbollTournament.Model
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Navigation properties
        public ICollection<Team> Teams { get; set; } = new List<Team>();
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
