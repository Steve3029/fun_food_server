using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FunFoodServer.Repositories.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FunFood");

            migrationBuilder.CreateTable(
                name: "USER",
                schema: "FunFood",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    PhotoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USER_PROFILE",
                schema: "FunFood",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    GooglePlus = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Youtube = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_PROFILE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_PROFILE_USER_UserId",
                        column: x => x.UserId,
                        principalSchema: "FunFood",
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Index_Email",
                schema: "FunFood",
                table: "USER",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_USER_PROFILE_UserId",
                schema: "FunFood",
                table: "USER_PROFILE",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USER_PROFILE",
                schema: "FunFood");

            migrationBuilder.DropTable(
                name: "USER",
                schema: "FunFood");
        }
    }
}
