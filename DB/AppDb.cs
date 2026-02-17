using FotbollTournament.Model;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace FotbollTournament.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Game → HomeTeam relation
            modelBuilder.Entity<Game>()
                .HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // Game → AwayTeam relation
            modelBuilder.Entity<Game>()
                .HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // Tournament → Teams
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Tournament)
                .WithMany(tr => tr.Teams)
                .HasForeignKey(t => t.TournamentId);

            // Tournament → Games
            modelBuilder.Entity<Game>()
                .HasOne(g => g.Tournament)
                .WithMany(t => t.Games)
                .HasForeignKey(g => g.TournamentId);

            // -------------------------
            //       SEED DATA
            // -------------------------

            // Tournament
            modelBuilder.Entity<Tournament>().HasData(
                new Tournament
                {
                    TournamentId = 1,
                    Name = "Göteborg Cup 2025",
                    StartDate = new DateTime(2025, 6, 1),
                    EndDate = new DateTime(2025, 6, 30)
                }
            );

            // Teams
            modelBuilder.Entity<Team>().HasData(
                new Team { TeamId = 1, TeamName = "Göteborg FC", CoachName = "Anders Larsson", TournamentId = 1 },
                new Team { TeamId = 2, TeamName = "Hisingen United", CoachName = "Maria Svensson", TournamentId = 1 },
                new Team { TeamId = 3, TeamName = "Angered Stars", CoachName = "Omar Ali", TournamentId = 1 },
                new Team { TeamId = 4, TeamName = "Frölunda IF", CoachName = "Johan Berg", TournamentId = 1 }
            );

            // Players
            modelBuilder.Entity<Player>().HasData(
                // Göteborg FC
                new Player { PlayerId = 1, FirstName = "Adam", LastName = "Karlsson", Position = "Forward", TeamId = 1 },
                new Player { PlayerId = 2, FirstName = "Leo", LastName = "Nilsson", Position = "Midfielder", TeamId = 1 },

                // Hisingen United
                new Player { PlayerId = 3, FirstName = "Isak", LastName = "Johansson", Position = "Defender", TeamId = 2 },
                new Player { PlayerId = 4, FirstName = "Elias", LastName = "Persson", Position = "Goalkeeper", TeamId = 2 },

                // Angered Stars
                new Player { PlayerId = 5, FirstName = "Yusuf", LastName = "Ahmed", Position = "Forward", TeamId = 3 },
                new Player { PlayerId = 6, FirstName = "Bilal", LastName = "Hassan", Position = "Midfielder", TeamId = 3 },

                // Frölunda IF
                new Player { PlayerId = 7, FirstName = "Oscar", LastName = "Lindberg", Position = "Defender", TeamId = 4 },
                new Player { PlayerId = 8, FirstName = "Viktor", LastName = "Sjöberg", Position = "Forward", TeamId = 4 }
            );

            // Games
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    GameId = 1,
                    TournamentId = 1,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    GameDate = new DateTime(2025, 6, 5),
                    HomeScore = 2,
                    AwayScore = 1
                },
                new Game
                {
                    GameId = 2,
                    TournamentId = 1,
                    HomeTeamId = 3,
                    AwayTeamId = 4,
                    GameDate = new DateTime(2025, 6, 6),
                    HomeScore = 0,
                    AwayScore = 3
                }
            );
        }
    }
}
