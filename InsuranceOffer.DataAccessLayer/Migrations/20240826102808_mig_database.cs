using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceOffer.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assurances",
                columns: table => new
                {
                    AssuranceCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assurances", x => x.AssuranceCode);
                });

            migrationBuilder.CreateTable(
                name: "Insureds",
                columns: table => new
                {
                    InsuredID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insureds", x => x.InsuredID);
                });

            migrationBuilder.CreateTable(
                name: "VerificationCodes",
                columns: table => new
                {
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationCodes", x => x.PhoneNumber);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    PolicyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuredID = table.Column<int>(type: "int", nullable: false),
                    InsurerID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Offer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.PolicyID);
                    table.ForeignKey(
                        name: "FK_Policies_Insureds_InsuredID",
                        column: x => x.InsuredID,
                        principalTable: "Insureds",
                        principalColumn: "InsuredID");
                    table.ForeignKey(
                        name: "FK_Policies_Insureds_InsurerID",
                        column: x => x.InsurerID,
                        principalTable: "Insureds",
                        principalColumn: "InsuredID");
                });

            migrationBuilder.CreateTable(
                name: "Pays",
                columns: table => new
                {
                    PayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyID = table.Column<int>(type: "int", nullable: false),
                    InsuredID = table.Column<int>(type: "int", nullable: false),
                    KartNo = table.Column<long>(type: "bigint", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CVC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pays", x => x.PayID);
                    table.ForeignKey(
                        name: "FK_Pays_Insureds_InsuredID",
                        column: x => x.InsuredID,
                        principalTable: "Insureds",
                        principalColumn: "InsuredID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pays_Policies_PolicyID",
                        column: x => x.PolicyID,
                        principalTable: "Policies",
                        principalColumn: "PolicyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoliceAssurances",
                columns: table => new
                {
                    PoliceAssuranceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyID = table.Column<int>(type: "int", nullable: false),
                    AssuranceCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bedel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bonus = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceAssurances", x => x.PoliceAssuranceID);
                    table.ForeignKey(
                        name: "FK_PoliceAssurances_Assurances_AssuranceCode",
                        column: x => x.AssuranceCode,
                        principalTable: "Assurances",
                        principalColumn: "AssuranceCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoliceAssurances_Policies_PolicyID",
                        column: x => x.PolicyID,
                        principalTable: "Policies",
                        principalColumn: "PolicyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pays_InsuredID",
                table: "Pays",
                column: "InsuredID");

            migrationBuilder.CreateIndex(
                name: "IX_Pays_PolicyID",
                table: "Pays",
                column: "PolicyID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoliceAssurances_AssuranceCode",
                table: "PoliceAssurances",
                column: "AssuranceCode");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceAssurances_PolicyID",
                table: "PoliceAssurances",
                column: "PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_InsuredID",
                table: "Policies",
                column: "InsuredID");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_InsurerID",
                table: "Policies",
                column: "InsurerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pays");

            migrationBuilder.DropTable(
                name: "PoliceAssurances");

            migrationBuilder.DropTable(
                name: "VerificationCodes");

            migrationBuilder.DropTable(
                name: "Assurances");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "Insureds");
        }
    }
}
