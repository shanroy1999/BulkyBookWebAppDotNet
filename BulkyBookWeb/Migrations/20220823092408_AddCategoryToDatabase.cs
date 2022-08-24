using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBookWeb.Migrations
{
    public partial class AddCategoryToDatabase : Migration
    {
        // Defines what needs to happen inside the migration
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                // Create Table with name 'Categories' as defined in ApplicationDbContext in Data folder
                name: "Categories",
                // columns inside the 'Categories' table
                columns: table => new
                {
                    // Id column of type integer, nullable false and Identity column(due to 'Key' annotation)
                    // auto incrementing by 1
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),

                    // Name column -> nullable is false due to 'Required' annotation
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    // DisplayOrder -> nullable is false as it is an integer
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),

                    // CreatedDateTime -> type is datetime2
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },

                // Adding a primary key with name 'PK_Categories' on the 'Id' column
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });
        }

        // Rollback mechanism if something not working
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
