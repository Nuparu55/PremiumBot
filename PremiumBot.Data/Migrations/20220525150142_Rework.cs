using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremiumBot.Data.Migrations
{
    public partial class Rework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TitleUser");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Users",
                newName: "StickersCount");

            migrationBuilder.RenameColumn(
                name: "Energy",
                table: "Users",
                newName: "ReplyCount");

            migrationBuilder.AddColumn<int>(
                name: "ContactsCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FilesCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GeopositionsCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImagesCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MessagesCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PoolsCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReactionsCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RedirectCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Rare",
                table: "Titles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Achievments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUniq = table.Column<bool>(type: "bit", nullable: false),
                    ImgPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AchievmentUser",
                columns: table => new
                {
                    AchievmentsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AchievmentUser", x => new { x.AchievmentsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AchievmentUser_Achievments_AchievmentsId",
                        column: x => x.AchievmentsId,
                        principalTable: "Achievments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AchievmentUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TitleId",
                table: "Users",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_AchievmentUser_UsersId",
                table: "AchievmentUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Titles_TitleId",
                table: "Users",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Titles_TitleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AchievmentUser");

            migrationBuilder.DropTable(
                name: "Achievments");

            migrationBuilder.DropIndex(
                name: "IX_Users_TitleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ContactsCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FilesCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GeopositionsCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImagesCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MessagesCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PoolsCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReactionsCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RedirectCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "StickersCount",
                table: "Users",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "ReplyCount",
                table: "Users",
                newName: "Energy");

            migrationBuilder.AlterColumn<string>(
                name: "Rare",
                table: "Titles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "TitleUser",
                columns: table => new
                {
                    TitlesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleUser", x => new { x.TitlesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TitleUser_Titles_TitlesId",
                        column: x => x.TitlesId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TitleUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TitleUser_UsersId",
                table: "TitleUser",
                column: "UsersId");
        }
    }
}
