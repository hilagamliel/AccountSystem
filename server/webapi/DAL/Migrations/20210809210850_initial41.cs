using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initial41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvestmentPolicyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentPolicyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personals",
                columns: table => new
                {
                    Tz = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personals", x => x.Tz);
                });

            migrationBuilder.CreateTable(
                name: "PersonalTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagementFee = table.Column<int>(type: "int", nullable: false),
                    BankNumber = table.Column<int>(type: "int", nullable: false),
                    BankAccountNumber = table.Column<int>(type: "int", nullable: false),
                    InvestmentPolicyTypesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_InvestmentPolicyTypes_InvestmentPolicyTypesId",
                        column: x => x.InvestmentPolicyTypesId,
                        principalTable: "InvestmentPolicyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    PersonalTz = table.Column<string>(type: "nvarchar(9)", nullable: true),
                    PersonalTypesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalInAccounts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalInAccounts_Personals_PersonalTz",
                        column: x => x.PersonalTz,
                        principalTable: "Personals",
                        principalColumn: "Tz",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalInAccounts_PersonalTypes_PersonalTypesId",
                        column: x => x.PersonalTypesId,
                        principalTable: "PersonalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_InvestmentPolicyTypesId",
                table: "Accounts",
                column: "InvestmentPolicyTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInAccounts_AccountId",
                table: "PersonalInAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInAccounts_PersonalTypesId",
                table: "PersonalInAccounts",
                column: "PersonalTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInAccounts_PersonalTz",
                table: "PersonalInAccounts",
                column: "PersonalTz");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalInAccounts");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Personals");

            migrationBuilder.DropTable(
                name: "PersonalTypes");

            migrationBuilder.DropTable(
                name: "InvestmentPolicyTypes");
        }
    }
}
