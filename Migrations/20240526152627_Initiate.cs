using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MushroomPocket.Migrations
{
    /// <inheritdoc />
    public partial class Initiate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MushroomCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Hp = table.Column<int>(type: "INTEGER", nullable: false),
                    Exp = table.Column<int>(type: "INTEGER", nullable: false),
                    Skill = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MushroomCharacters", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MushroomCharacters");
        }
    }
}
