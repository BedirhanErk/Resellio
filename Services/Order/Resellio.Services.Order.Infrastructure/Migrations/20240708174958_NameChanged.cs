using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resellio.Services.Order.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NameChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseName",
                schema: "ordering",
                table: "OrderItems",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                schema: "ordering",
                table: "OrderItems",
                newName: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                schema: "ordering",
                table: "OrderItems",
                newName: "CourseName");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "ordering",
                table: "OrderItems",
                newName: "CourseId");
        }
    }
}
