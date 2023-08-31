using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRental.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Rentals_RentId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "RentId",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Rentals_RentId",
                table: "Movies",
                column: "RentId",
                principalTable: "Rentals",
                principalColumn: "Id_Rent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Rentals_RentId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "RentId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Rentals_RentId",
                table: "Movies",
                column: "RentId",
                principalTable: "Rentals",
                principalColumn: "Id_Rent",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
