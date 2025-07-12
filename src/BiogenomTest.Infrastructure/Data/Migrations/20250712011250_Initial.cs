using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BiogenomTest.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nutrients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    Norm = table.Column<double>(type: "double precision", nullable: true),
                    NormMin = table.Column<double>(type: "double precision", nullable: true),
                    NormMax = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutrients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplementBenefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplementBenefits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyIntakes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NutrientId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyIntakes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyIntakes_Nutrients_NutrientId",
                        column: x => x.NutrientId,
                        principalTable: "Nutrients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplementProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    TargetedNutrientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplementProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplementProducts_Nutrients_TargetedNutrientId",
                        column: x => x.TargetedNutrientId,
                        principalTable: "Nutrients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IntakeProjections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DailyIntakeId = table.Column<int>(type: "integer", nullable: false),
                    FromSet = table.Column<double>(type: "double precision", nullable: false),
                    FromFood = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntakeProjections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntakeProjections_DailyIntakes_DailyIntakeId",
                        column: x => x.DailyIntakeId,
                        principalTable: "DailyIntakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyIntakes_NutrientId",
                table: "DailyIntakes",
                column: "NutrientId");

            migrationBuilder.CreateIndex(
                name: "IX_IntakeProjections_DailyIntakeId",
                table: "IntakeProjections",
                column: "DailyIntakeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplementProducts_TargetedNutrientId",
                table: "SupplementProducts",
                column: "TargetedNutrientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntakeProjections");

            migrationBuilder.DropTable(
                name: "SupplementBenefits");

            migrationBuilder.DropTable(
                name: "SupplementProducts");

            migrationBuilder.DropTable(
                name: "DailyIntakes");

            migrationBuilder.DropTable(
                name: "Nutrients");
        }
    }
}
