namespace FotbollTournament.Domain.Entities;

public class Game
{
    public int GameId { get; set; }
    public DateTime KickOff { get; set; }
    public int HomeTeamId { get; set; }
    public Team HomeTeam { get; set; } = null!;
    public int AwayTeamId { get; set; }
    public Team AwayTeam { get; set; } = null!;
    public int HomeScore { get; set; }
    public int AwayScore { get; set; }
    public int TournamentId { get; set; }
    public Tournament Tournament { get; set; } = null!;
}
