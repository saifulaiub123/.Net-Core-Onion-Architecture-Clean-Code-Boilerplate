using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentGo.Infrastructure.Migrations
{
    public partial class addDBModel_Otp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Otps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MobileNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    VerificationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otps", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Otps_MobileNumber",
                table: "Otps",
                column: "MobileNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Otps");
        }
    }
}
