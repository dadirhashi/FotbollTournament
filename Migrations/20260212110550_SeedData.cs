using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FotbollTournament.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "TournamentId", "EndDate", "Name", "StartDate" },
                values: new object[] { 1, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Göteborg Cup 2025", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "CoachName", "Name", "TournamentId" },
                values: new object[,]
                {
                    { 1, "Anders Larsson", "Göteborg FC", 1 },
                    { 2, "Maria Svensson", "Hisingen United", 1 },
                    { 3, "Omar Ali", "Angered Stars", 1 },
                    { 4, "Johan Berg", "Frölunda IF", 1 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "AwayScore", "AwayTeamId", "GameDate", "HomeScore", "HomeTeamId", "TournamentId" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 2, 3, 4, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "FirstName", "LastName", "Position", "TeamId" },
                values: new object[,]
                {
                    { 1, "Adam", "Karlsson", "Forward", 1 },
                    { 2, "Leo", "Nilsson", "Midfielder", 1 },
                    { 3, "Isak", "Johansson", "Defender", 2 },
                    { 4, "Elias", "Persson", "Goalkeeper", 2 },
                    { 5, "Yusuf", "Ahmed", "Forward", 3 },
                    { 6, "Bilal", "Hassan", "Midfielder", 3 },
                    { 7, "Oscar", "Lindberg", "Defender", 4 },
                    { 8, "Viktor", "Sjöberg", "Forward", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1);
        }
    }
}
