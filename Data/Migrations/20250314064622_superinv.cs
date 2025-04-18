using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUP_INV1._0.Data.Migrations
{
    /// <inheritdoc />
    public partial class superinv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PREPAREDRECORD",
                columns: table => new
                {
                    RecID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    RecName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    RecSoldAmountQuantity = table.Column<double>(type: "float", nullable: false),
                    RecDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecSt_InPrice = table.Column<double>(type: "float", nullable: false),
                    RecSt_OutPrice = table.Column<double>(type: "float", nullable: false),
                    RecDateSold = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecSupplierEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PREPAREDRECORD", x => x.RecID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PREPAREDRECORD");
        }
    }
}
