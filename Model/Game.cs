namespace FotbollTournament.Model
{
    public class Game
    {
        public int GameId { get; set; } = 0;

        public DateTime GameDate { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        // Foreign keys
        public int TournamentId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }

        // Navigation
        public Tournament Tournament { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
    }
}
