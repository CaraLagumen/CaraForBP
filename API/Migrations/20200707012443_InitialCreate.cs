using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    PMId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardOwnerName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CardOwnerStreet = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CardOwnerZip = table.Column<string>(type: "varchar(10)", nullable: false),
                    CardNumber = table.Column<string>(type: "varchar(16)", nullable: false),
                    ExpirationDate = table.Column<string>(type: "varchar(5)", nullable: false),
                    CVV = table.Column<string>(type: "varchar(4)", nullable: false),
                    TransactionAmount = table.Column<string>(type: "varchar(50)", nullable: false),
                    ProcessorResponse = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    RequestedAmount = table.Column<string>(type: "varchar(50)", nullable: true),
                    ProcessedAmount = table.Column<string>(type: "varchar(50)", nullable: true),
                    Type = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.PMId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentDetails");
        }
    }
}
