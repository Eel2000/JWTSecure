using Microsoft.EntityFrameworkCore.Migrations;

namespace JWTSecure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JWT_USER",
                columns: table => new
                {
                    USER_ID = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    USER_NAME = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    USER_EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    USER_PASSWORD = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JWT_USER", x => x.USER_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JWT_USER");
        }
    }
}
