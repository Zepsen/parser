using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class uprelates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_Persons_PersonId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_Persons_PersonId",
                table: "Work");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Work",
                table: "Work");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Education",
                table: "Education");

            migrationBuilder.RenameTable(
                name: "Work",
                newName: "Works");

            migrationBuilder.RenameTable(
                name: "Education",
                newName: "Educations");

            migrationBuilder.RenameIndex(
                name: "IX_Work_PersonId",
                table: "Works",
                newName: "IX_Works_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Education_PersonId",
                table: "Educations",
                newName: "IX_Educations_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Works",
                table: "Works",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Persons_PersonId",
                table: "Educations",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Persons_PersonId",
                table: "Works",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Persons_PersonId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Persons_PersonId",
                table: "Works");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Works",
                table: "Works");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

            migrationBuilder.RenameTable(
                name: "Works",
                newName: "Work");

            migrationBuilder.RenameTable(
                name: "Educations",
                newName: "Education");

            migrationBuilder.RenameIndex(
                name: "IX_Works_PersonId",
                table: "Work",
                newName: "IX_Work_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_PersonId",
                table: "Education",
                newName: "IX_Education_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Work",
                table: "Work",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Education",
                table: "Education",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_Persons_PersonId",
                table: "Education",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Persons_PersonId",
                table: "Work",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
