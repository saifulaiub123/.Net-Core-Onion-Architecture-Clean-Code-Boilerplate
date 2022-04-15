using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentGo.Infrastructure.Migrations
{
    public partial class DbModel_Otp_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VerificationCode",
                table: "Otps",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredAt",
                table: "Otps",
                type: "datetime",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VerificationCode",
                table: "Otps",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredAt",
                table: "Otps",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldMaxLength: 250);
        }
    }
}
