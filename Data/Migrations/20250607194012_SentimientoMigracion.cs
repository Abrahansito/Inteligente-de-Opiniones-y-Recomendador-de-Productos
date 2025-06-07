using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC4PROGRAMACION.Data.Migrations
{
    /// <inheritdoc />
    public partial class SentimientoMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sentimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Mensaje = table.Column<string>(type: "TEXT", nullable: false),
                    Prediction = table.Column<string>(type: "TEXT", nullable: true),
                    Score = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentimiento", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sentimiento");
        }
    }
}
