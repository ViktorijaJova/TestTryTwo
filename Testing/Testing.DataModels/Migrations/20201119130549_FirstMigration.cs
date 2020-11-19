using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Testing.DataModels.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 12, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    StudentNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentNumber);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Credits = table.Column<int>(nullable: false),
                    Semestar = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Subjects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentNumber", "EmailAddress", "FullName", "Id", "PhoneNumber" },
                values: new object[] { 1, "viktorijajovanovska@gmail.com", "Viktorija Jovanovska", 0, "+38970123456" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Name", "Credits", "Semestar", "StudentId" },
                values: new object[,]
                {
                    { "History", 3, 2, 1 },
                    { "Chemistry", 2, 2, 1 },
                    { "English", 2, 2, 1 },
                    { "French", 2, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_StudentId",
                table: "Subjects",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
