using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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

            migrationBuilder.InsertData(
                table: "Nutrients",
                columns: new[] { "Id", "Name", "Norm", "NormMax", "NormMin", "Unit" },
                values: new object[,]
                {
                    { 1, "Vitamin D", 15.0, null, null, "mcg" },
                    { 2, "Vitamin C (ascorbic acid)", 100.0, null, null, "mg" },
                    { 3, "Water", null, 1900.0, 1800.0, "g" },
                    { 4, "Protein", 102.0, null, null, "g" }
                });

            migrationBuilder.InsertData(
                table: "SupplementBenefits",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Eliminate vitamin and mineral deficiency" },
                    { 2, "Improve the absorption of nutrients from food" },
                    { 3, "Compensate for an unbalanced diet" },
                    { 4, "Provide the body with vital elements" },
                    { 5, "Increase the functional reserves of the body" }
                });

            migrationBuilder.InsertData(
                table: "DailyIntakes",
                columns: new[] { "Id", "Amount", "NutrientId", "Status" },
                values: new object[,]
                {
                    { 1, 7.04, 1, 0 },
                    { 2, 42.390000000000001, 2, 0 },
                    { 3, 1547.0699999999999, 3, 0 },
                    { 4, 225.59999999999999, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "SupplementProducts",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "TargetedNutrientId" },
                values: new object[,]
                {
                    { 1, "Advanced formula with vitamin D3 and K2", "images/vitamin-d.jpg", "Vitamin D3 Complex", 1 },
                    { 2, "Sustained-release vitamin C with bioflavonoids", "images/vitamin-c.jpg", "Premium Vitamin C", 2 },
                    { 3, "Complete plant-based protein blend", "images/protein.jpg", "Protein Matrix", 4 }
                });

            migrationBuilder.InsertData(
                table: "IntakeProjections",
                columns: new[] { "Id", "DailyIntakeId", "FromFood", "FromSet" },
                values: new object[,]
                {
                    { 1, 1, 0.0, 50.0 },
                    { 2, 2, 40.0, 330.0 }
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
