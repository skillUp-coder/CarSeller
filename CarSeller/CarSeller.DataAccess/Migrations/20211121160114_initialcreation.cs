using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSeller.DataAccess.Migrations
{
    public partial class initialcreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_CarsStoredProcedures_CarsStoredProcedureId",
                table: "Purchases");

            migrationBuilder.DropTable(
                name: "CarsStoredProcedures");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_CarsStoredProcedureId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "CarsStoredProcedureId",
                table: "Purchases");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarsStoredProcedureId",
                table: "Purchases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarsStoredProcedures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsStoredProcedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarsStoredProcedures_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CarsStoredProcedureId",
                table: "Purchases",
                column: "CarsStoredProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_CarsStoredProcedures_SellerId",
                table: "CarsStoredProcedures",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_CarsStoredProcedures_CarsStoredProcedureId",
                table: "Purchases",
                column: "CarsStoredProcedureId",
                principalTable: "CarsStoredProcedures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
