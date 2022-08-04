using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_wd_bots.migrations_ETH.hash
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ETH_Transaction_Logs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    transactionHash = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    blockHash = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    blockNumber = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    logIndex = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    transactionIndex = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETH_Transaction_Logs", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HARD_Transaction_Logs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    transactionHash = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    blockHash = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    blockNumber = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    logIndex = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    transactionIndex = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HARD_Transaction_Logs", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RAM_Transaction_Logs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    transactionHash = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    blockHash = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    blockNumber = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    logIndex = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    transactionIndex = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAM_Transaction_Logs", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SOFT_Transaction_Logs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    transactionHash = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    blockHash = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    blockNumber = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    logIndex = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    transactionIndex = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOFT_Transaction_Logs", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SSD_Transaction_Logs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    transactionHash = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    blockHash = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    blockNumber = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    logIndex = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    transactionIndex = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSD_Transaction_Logs", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ETH_Transaction_Logs");

            migrationBuilder.DropTable(
                name: "HARD_Transaction_Logs");

            migrationBuilder.DropTable(
                name: "RAM_Transaction_Logs");

            migrationBuilder.DropTable(
                name: "SOFT_Transaction_Logs");

            migrationBuilder.DropTable(
                name: "SSD_Transaction_Logs");
        }
    }
}
