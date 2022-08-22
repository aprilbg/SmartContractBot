using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_wd_bots.migrations_nft.hash
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "transaction_data",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CallHashFrom = table.Column<string>(type: "varchar(1024)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    table.PrimaryKey("PK_transaction_data", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transaction_data");
        }
    }
}
