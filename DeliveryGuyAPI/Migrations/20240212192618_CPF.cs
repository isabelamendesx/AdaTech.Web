using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryGuyAPI.Migrations
{
    /// <inheritdoc />
    public partial class CPF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "DeliveryGuys",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "DeliveryGuys");
        }
    }
}
