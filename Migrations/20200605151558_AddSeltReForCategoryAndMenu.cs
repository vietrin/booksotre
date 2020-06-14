using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace BookStore.Migrations
{
    public partial class AddSeltReForCategoryAndMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_Parentid",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryBook_Category",
                table: "Categorybook");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Category_TempId",
                table: "Category");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Category_TempId1",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "TempId1",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Categorybook",
                newName: "categorybook");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "categorybook",
                newName: "categoryId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "categorybook",
                newName: "bookId");

            migrationBuilder.AlterColumn<int>(
                name: "categoryId",
                table: "categorybook",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "bookId",
                table: "categorybook",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Parentid",
                table: "category",
                type: "int(11)",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "category",
                type: "int(11)",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "category",
                unicode: false,
                maxLength: 200,
                nullable: true,
                defaultValueSql: "'NULL'");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "categorybook",
                columns: new[] { "bookId", "categoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                table: "category",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "FK_CategoryBook_Category",
                table: "categorybook",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_category_Parentid",
                table: "category",
                column: "Parentid");

            migrationBuilder.AddForeignKey(
                name: "FK_category_category_Parentid",
                table: "category",
                column: "Parentid",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryBook_Category",
                table: "categorybook",
                column: "categoryId",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_category_Parentid",
                table: "category");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryBook_Category",
                table: "categorybook");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "categorybook");

            migrationBuilder.DropIndex(
                name: "FK_CategoryBook_Category",
                table: "categorybook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                table: "category");

            migrationBuilder.DropIndex(
                name: "IX_category_Parentid",
                table: "category");

            migrationBuilder.DropColumn(
                name: "id",
                table: "category");

            migrationBuilder.DropColumn(
                name: "title",
                table: "category");

            migrationBuilder.RenameTable(
                name: "categorybook",
                newName: "Categorybook");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Categorybook",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "bookId",
                table: "Categorybook",
                newName: "BookId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Categorybook",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Categorybook",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");

            migrationBuilder.AlterColumn<int>(
                name: "Parentid",
                table: "Category",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempId",
                table: "Category",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempId1",
                table: "Category",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Category_TempId",
                table: "Category",
                column: "TempId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Category_TempId1",
                table: "Category",
                column: "TempId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_Parentid",
                table: "Category",
                column: "Parentid",
                principalTable: "Category",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryBook_Category",
                table: "Categorybook",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "TempId1",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
