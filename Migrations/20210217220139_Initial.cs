using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookStore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookModels",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookAuthorFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookAuthorMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookAuthorLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookPublisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookClassification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookModels", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookModels");
        }
    }
}
