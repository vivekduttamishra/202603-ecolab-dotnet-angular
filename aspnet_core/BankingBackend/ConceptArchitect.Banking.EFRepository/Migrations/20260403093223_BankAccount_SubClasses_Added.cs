using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConceptArchitect.Banking.EFRepository.Migrations
{
    /// <inheritdoc />
    public partial class BankAccount_SubClasses_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Customers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                table: "Accounts",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "MinBalance",
                table: "Accounts",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OdLimit",
                table: "Accounts",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "MinBalance",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "OdLimit",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }
    }
}
