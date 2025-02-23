using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Books : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PopularityScore",
                table: "Books",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "YearsSincePublished",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PopularityScore",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "YearsSincePublished",
                table: "Books");
        }
    }
}
