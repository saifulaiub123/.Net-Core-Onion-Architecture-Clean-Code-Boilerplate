using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentGo.Infrastructure.Migrations
{
    public partial class updatetableApplicationLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Properties",
                table: "ApplicationLog",
                type: "xml",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "xml");

            migrationBuilder.AlterColumn<string>(
                name: "MessageTemplate",
                table: "ApplicationLog",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LogEvent",
                table: "ApplicationLog",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Exception",
                table: "ApplicationLog",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Properties",
                table: "ApplicationLog",
                type: "xml",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "xml",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MessageTemplate",
                table: "ApplicationLog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LogEvent",
                table: "ApplicationLog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Exception",
                table: "ApplicationLog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
