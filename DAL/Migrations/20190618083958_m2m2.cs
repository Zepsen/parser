using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class m2m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonHave_Haves_HaveId",
                table: "PersonHave");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonHave_Persons_PersonId",
                table: "PersonHave");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterest_Interests_InterestId",
                table: "PersonInterest");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterest_Persons_PersonId",
                table: "PersonInterest");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguage_Languages_LanguageId",
                table: "PersonLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguage_Persons_PersonId",
                table: "PersonLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonWant_Persons_PersonId",
                table: "PersonWant");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonWant_Wants_WantId",
                table: "PersonWant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonWant",
                table: "PersonWant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonLanguage",
                table: "PersonLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInterest",
                table: "PersonInterest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonHave",
                table: "PersonHave");

            migrationBuilder.RenameTable(
                name: "PersonWant",
                newName: "PersonWants");

            migrationBuilder.RenameTable(
                name: "PersonLanguage",
                newName: "PersonLanguages");

            migrationBuilder.RenameTable(
                name: "PersonInterest",
                newName: "PersonInterests");

            migrationBuilder.RenameTable(
                name: "PersonHave",
                newName: "PersonHaves");

            migrationBuilder.RenameIndex(
                name: "IX_PersonWant_WantId",
                table: "PersonWants",
                newName: "IX_PersonWants_WantId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonLanguage_LanguageId",
                table: "PersonLanguages",
                newName: "IX_PersonLanguages_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonInterest_InterestId",
                table: "PersonInterests",
                newName: "IX_PersonInterests_InterestId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonHave_HaveId",
                table: "PersonHaves",
                newName: "IX_PersonHaves_HaveId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonWants",
                table: "PersonWants",
                columns: new[] { "PersonId", "WantId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonLanguages",
                table: "PersonLanguages",
                columns: new[] { "PersonId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInterests",
                table: "PersonInterests",
                columns: new[] { "PersonId", "InterestId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonHaves",
                table: "PersonHaves",
                columns: new[] { "PersonId", "HaveId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonHaves_Haves_HaveId",
                table: "PersonHaves",
                column: "HaveId",
                principalTable: "Haves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonHaves_Persons_PersonId",
                table: "PersonHaves",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterests_Interests_InterestId",
                table: "PersonInterests",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterests_Persons_PersonId",
                table: "PersonInterests",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguages_Languages_LanguageId",
                table: "PersonLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguages_Persons_PersonId",
                table: "PersonLanguages",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonWants_Persons_PersonId",
                table: "PersonWants",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonWants_Wants_WantId",
                table: "PersonWants",
                column: "WantId",
                principalTable: "Wants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonHaves_Haves_HaveId",
                table: "PersonHaves");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonHaves_Persons_PersonId",
                table: "PersonHaves");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterests_Interests_InterestId",
                table: "PersonInterests");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterests_Persons_PersonId",
                table: "PersonInterests");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguages_Languages_LanguageId",
                table: "PersonLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguages_Persons_PersonId",
                table: "PersonLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonWants_Persons_PersonId",
                table: "PersonWants");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonWants_Wants_WantId",
                table: "PersonWants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonWants",
                table: "PersonWants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonLanguages",
                table: "PersonLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInterests",
                table: "PersonInterests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonHaves",
                table: "PersonHaves");

            migrationBuilder.RenameTable(
                name: "PersonWants",
                newName: "PersonWant");

            migrationBuilder.RenameTable(
                name: "PersonLanguages",
                newName: "PersonLanguage");

            migrationBuilder.RenameTable(
                name: "PersonInterests",
                newName: "PersonInterest");

            migrationBuilder.RenameTable(
                name: "PersonHaves",
                newName: "PersonHave");

            migrationBuilder.RenameIndex(
                name: "IX_PersonWants_WantId",
                table: "PersonWant",
                newName: "IX_PersonWant_WantId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonLanguages_LanguageId",
                table: "PersonLanguage",
                newName: "IX_PersonLanguage_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonInterests_InterestId",
                table: "PersonInterest",
                newName: "IX_PersonInterest_InterestId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonHaves_HaveId",
                table: "PersonHave",
                newName: "IX_PersonHave_HaveId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonWant",
                table: "PersonWant",
                columns: new[] { "PersonId", "WantId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonLanguage",
                table: "PersonLanguage",
                columns: new[] { "PersonId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInterest",
                table: "PersonInterest",
                columns: new[] { "PersonId", "InterestId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonHave",
                table: "PersonHave",
                columns: new[] { "PersonId", "HaveId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonHave_Haves_HaveId",
                table: "PersonHave",
                column: "HaveId",
                principalTable: "Haves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonHave_Persons_PersonId",
                table: "PersonHave",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterest_Interests_InterestId",
                table: "PersonInterest",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterest_Persons_PersonId",
                table: "PersonInterest",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguage_Languages_LanguageId",
                table: "PersonLanguage",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguage_Persons_PersonId",
                table: "PersonLanguage",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonWant_Persons_PersonId",
                table: "PersonWant",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonWant_Wants_WantId",
                table: "PersonWant",
                column: "WantId",
                principalTable: "Wants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
