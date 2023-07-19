using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Dapper.Migrations
{
    /// <inheritdoc />
    public partial class updateStudent1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "Students",
                newName: "studentName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "studentName",
                table: "Students",
                newName: "StudentName");
        }
    }
}
