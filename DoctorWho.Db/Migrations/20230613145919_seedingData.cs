using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class seedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1, "Jane Austen" },
                    { 2, "Ernest Hemingway" },
                    { 3, "J.K. Rowling" },
                    { 4, "Charles Dickens" },
                    { 5, "Agatha Christie" }
                });

            migrationBuilder.InsertData(
                table: "Companions",
                columns: new[] { "CompanionId", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 1, "Rose Tyler", "Billie Piper" },
                    { 2, "Amy Pond", "Karen Gillan" },
                    { 3, "Clara Oswald", "Jenna Coleman" },
                    { 4, "Donna Noble", "Catherine Tate" },
                    { 5, "Martha Jones", "Freema Agyeman" },
                    { 6, "Rory Williams", "Arthur Darvill" },
                    { 7, "River Song", "Alex Kingston" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "BirthDate", "DoctorName", "DoctorNumber", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1908, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "William Hartnell", 1, new DateTime(1963, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1966, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1971, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Tennant", 10, new DateTime(2005, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1982, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matt Smith", 11, new DateTime(2010, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2013, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1958, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peter Capaldi", 12, new DateTime(2014, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1982, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jodie Whittaker", 13, new DateTime(2018, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "EnemyId", "EnemyDescription", "EnemyName" },
                values: new object[,]
                {
                    { 1, "Ruthless cyborg conquerors", "Daleks" },
                    { 2, "Cybernetic humanoids seeking perfection", "Cybermen" },
                    { 3, "The Doctor's Time Lord nemesis", "The Master" },
                    { 4, "Quantum-locked predatory beings", "Weeping Angels" },
                    { 5, "Memory-manipulating religious order", "The Silence" },
                    { 6, "Beings", "Clockwork androids" },
                    { 7, "A creature designed to extract information from the Doctor", "The Veil" },
                    { 8, "Specifically, Tzim-Sha, a warrior of the Stenza race", "Stenza" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "Notes", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(1963, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Historical Adventure", null, 1, "The Daleks" },
                    { 2, 2, 2, new DateTime(2006, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Sci-Fi Adventure", null, 2, "The Girl in the Fireplace" },
                    { 3, 3, 3, new DateTime(2010, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Drama, Mystery", null, 5, "Vincent and the Doctor" },
                    { 4, 4, 4, new DateTime(2015, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Sci-Fi Adventure", null, 9, "Heaven Sent" },
                    { 5, 5, 5, new DateTime(2018, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Adventure, Drama", null, 11, "The Woman Who Fell to Earth" },
                    { 6, 1, 1, new DateTime(1964, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Historical Adventure", null, 1, "The Reign of Terror" },
                    { 7, 2, 2, new DateTime(2007, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Sci-Fi Adventure", null, 3, "Blink" },
                    { 8, 3, 3, new DateTime(2012, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Sci-Fi Adventure", null, 7, "The Angels Take Manhattan" },
                    { 9, 4, 4, new DateTime(2014, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Sci-Fi Adventure", null, 8, "Dark Water" },
                    { 10, 5, 5, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Adventure, Drama", null, 12, "The Timeless Children" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
