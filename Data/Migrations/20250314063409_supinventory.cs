using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUP_INV1._0.Data.Migrations
{
    /// <inheritdoc />
    public partial class supinventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FarmProducts",
                columns: table => new
                {
                    FID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount_In_Kg = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maximum_Shelf_Life_Days = table.Column<int>(type: "int", nullable: false),
                    Stock_In_Price_Per_Kg = table.Column<double>(type: "float", nullable: false),
                    Stock_Out_Price_Per_Kg = table.Column<double>(type: "float", nullable: false),
                    Date_Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Supplier_Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmProducts", x => x.FID);
                });

            migrationBuilder.CreateTable(
                name: "FARMPRODUCTSPREPAREDRECORD",
                columns: table => new
                {
                    FPRecIDPREP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemIDPREP = table.Column<int>(type: "int", nullable: false),
                    FPRecNamePREP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FPRecSoldAmountPREP = table.Column<double>(type: "float", nullable: false),
                    FPRecDescriptionPREP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FPRecStockInPricePREP = table.Column<double>(type: "float", nullable: false),
                    FPRecStockOutPricePREP = table.Column<double>(type: "float", nullable: false),
                    FPRecDateSoldPREP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FPRecSupplierEmailPREP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FARMPRODUCTSPREPAREDRECORD", x => x.FPRecIDPREP);
                });

            migrationBuilder.CreateTable(
                name: "FARMPRODUCTSSALESRECORD",
                columns: table => new
                {
                    FPRecID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    FPRecName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FPRecSoldAmount = table.Column<double>(type: "float", nullable: false),
                    FPRecDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FPRecStockInPrice = table.Column<double>(type: "float", nullable: false),
                    FPRecStockOutPrice = table.Column<double>(type: "float", nullable: false),
                    FPRecDateSold = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FPRecSupplierEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FARMPRODUCTSSALESRECORD", x => x.FPRecID);
                });

            migrationBuilder.CreateTable(
                name: "Others",
                columns: table => new
                {
                    OID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expiry_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stock_In_Price_Per_Item = table.Column<double>(type: "float", nullable: false),
                    Stock_Out_Price_Per_Item = table.Column<double>(type: "float", nullable: false),
                    Date_Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Supplier_Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Others", x => x.OID);
                });

            migrationBuilder.CreateTable(
                name: "OTHERSPREPAREDRECORD",
                columns: table => new
                {
                    OTHRecIDPREP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemIDPREP = table.Column<int>(type: "int", nullable: false),
                    OTHRecNamePREP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTHRecSoldQuantityPREP = table.Column<double>(type: "float", nullable: false),
                    OTHRecDescriptionPREP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTHRecStockInPricePREP = table.Column<double>(type: "float", nullable: false),
                    OTHRecStockOutPricePREP = table.Column<double>(type: "float", nullable: false),
                    OTHRecDateSoldPREP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OTHRecSupplierEmailPREP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTHERSPREPAREDRECORD", x => x.OTHRecIDPREP);
                });

            migrationBuilder.CreateTable(
                name: "OTHERSSALESRECORD",
                columns: table => new
                {
                    OTHRecID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    OTHRecName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTHRecSoldQuantity = table.Column<double>(type: "float", nullable: false),
                    OTHRecDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTHRecStockInPrice = table.Column<double>(type: "float", nullable: false),
                    OTHRecStockOutPrice = table.Column<double>(type: "float", nullable: false),
                    OTHRecDateSold = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OTHRecSupplierEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTHERSSALESRECORD", x => x.OTHRecID);
                });

            migrationBuilder.CreateTable(
                name: "PACKEDFOODPREPAREDRECORD",
                columns: table => new
                {
                    PARecIDPREP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemIDPREP = table.Column<int>(type: "int", nullable: false),
                    PARecNamePREP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PARecSoldQuantityPREP = table.Column<double>(type: "float", nullable: false),
                    PARecDescriptionPREP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PARecStockInPricePREP = table.Column<double>(type: "float", nullable: false),
                    PARecStockOutPricePREP = table.Column<double>(type: "float", nullable: false),
                    PARecDateSoldPREP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PARecSupplierEmailPREP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACKEDFOODPREPAREDRECORD", x => x.PARecIDPREP);
                });

            migrationBuilder.CreateTable(
                name: "PackedFoods",
                columns: table => new
                {
                    PID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expiry_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stock_In_Price_Per_Item = table.Column<double>(type: "float", nullable: false),
                    Stock_Out_Price_Per_Item = table.Column<double>(type: "float", nullable: false),
                    Date_Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Supplier_Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackedFoods", x => x.PID);
                });

            migrationBuilder.CreateTable(
                name: "PACKEDFOODSSALESRECORD",
                columns: table => new
                {
                    PARecID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    PARecName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PARecSoldQuantity = table.Column<double>(type: "float", nullable: false),
                    PARecDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PARecStockInPrice = table.Column<double>(type: "float", nullable: false),
                    PARecStockOutPrice = table.Column<double>(type: "float", nullable: false),
                    PARecDateSold = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PARecSupplierEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACKEDFOODSSALESRECORD", x => x.PARecID);
                });

            migrationBuilder.CreateTable(
                name: "Pharmaceuticals",
                columns: table => new
                {
                    PHID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expiry_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stock_In_Price_Per_Item = table.Column<double>(type: "float", nullable: false),
                    Stock_Out_Price_Per_Item = table.Column<double>(type: "float", nullable: false),
                    Date_Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Supplier_Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmaceuticals", x => x.PHID);
                });

            migrationBuilder.CreateTable(
                name: "PHARMACEUTICALSPREPAREDRECORD",
                columns: table => new
                {
                    PHARecIDPREP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemIDPREP = table.Column<int>(type: "int", nullable: false),
                    PHARecNamePREP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PHARecSoldQuantityPREP = table.Column<double>(type: "float", nullable: false),
                    PHARecDescriptionPREP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PHARecStockInPricePREP = table.Column<double>(type: "float", nullable: false),
                    PHARecStockOutPricePREP = table.Column<double>(type: "float", nullable: false),
                    PHARecDateSoldPREP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PHARecSupplierEmailPREP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHARMACEUTICALSPREPAREDRECORD", x => x.PHARecIDPREP);
                });

            migrationBuilder.CreateTable(
                name: "PHARMACEUTICALSSALESRECORD",
                columns: table => new
                {
                    PHARecID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    PHARecName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PHARecSoldQuantity = table.Column<double>(type: "float", nullable: false),
                    PHARecDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PHARecStockInPrice = table.Column<double>(type: "float", nullable: false),
                    PHARecStockOutPrice = table.Column<double>(type: "float", nullable: false),
                    PHARecDateSold = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PHARecSupplierEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHARMACEUTICALSSALESRECORD", x => x.PHARecID);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    TID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock_In_Price_Per_Item = table.Column<double>(type: "float", nullable: false),
                    Stock_Out_Price_Per_Item = table.Column<double>(type: "float", nullable: false),
                    Date_Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Supplier_Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.TID);
                });

            migrationBuilder.CreateTable(
                name: "TOOLSPREPAREDRECORD",
                columns: table => new
                {
                    TOOLSRecIDPREP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemIDPREP = table.Column<int>(type: "int", nullable: false),
                    TOOLSRecNamePREP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TOOLSRecSoldQuantityPREP = table.Column<double>(type: "float", nullable: false),
                    TOOLSRecDescriptionPREP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TOOLSRecStockInPricePREP = table.Column<double>(type: "float", nullable: false),
                    TOOLSRecStockOutPricePREP = table.Column<double>(type: "float", nullable: false),
                    TOOLSRecDateSoldPREP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TOOLSRecSupplierEmailPREP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOOLSPREPAREDRECORD", x => x.TOOLSRecIDPREP);
                });

            migrationBuilder.CreateTable(
                name: "TOOLSSALESRECORD",
                columns: table => new
                {
                    TOOLSRecID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    TOOLSRecName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TOOLSRecSoldQuantity = table.Column<double>(type: "float", nullable: false),
                    TOOLSRecDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TOOLSRecStockInPrice = table.Column<double>(type: "float", nullable: false),
                    TOOLSRecStockOutPrice = table.Column<double>(type: "float", nullable: false),
                    TOOLSRecDateSold = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TOOLSRecSupplierEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOOLSSALESRECORD", x => x.TOOLSRecID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FarmProducts");

            migrationBuilder.DropTable(
                name: "FARMPRODUCTSPREPAREDRECORD");

            migrationBuilder.DropTable(
                name: "FARMPRODUCTSSALESRECORD");

            migrationBuilder.DropTable(
                name: "Others");

            migrationBuilder.DropTable(
                name: "OTHERSPREPAREDRECORD");

            migrationBuilder.DropTable(
                name: "OTHERSSALESRECORD");

            migrationBuilder.DropTable(
                name: "PACKEDFOODPREPAREDRECORD");

            migrationBuilder.DropTable(
                name: "PackedFoods");

            migrationBuilder.DropTable(
                name: "PACKEDFOODSSALESRECORD");

            migrationBuilder.DropTable(
                name: "Pharmaceuticals");

            migrationBuilder.DropTable(
                name: "PHARMACEUTICALSPREPAREDRECORD");

            migrationBuilder.DropTable(
                name: "PHARMACEUTICALSSALESRECORD");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "TOOLSPREPAREDRECORD");

            migrationBuilder.DropTable(
                name: "TOOLSSALESRECORD");
        }
    }
}
