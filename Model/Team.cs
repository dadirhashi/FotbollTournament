using System.Numerics;

namespace FotbollTournament.Model
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public string CoachName { get; set; } = string.Empty;

        // Foreign key
        public int TournamentId { get; set; }

        // Navigation properties
        public Tournament Tournament { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();

        // Games where this team is home or away
        public ICollection<Game> HomeGames { get; set; } = new List<Game>();
        public ICollection<Game> AwayGames { get; set; } = new List<Game>();
    }
}
