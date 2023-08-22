using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerBase.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CustomerBase");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "CustomerBase",
                columns: table => new
                {
                    idcustomer = table.Column<int>(name: "id_customer", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(name: "full_name", type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.idcustomer);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "CustomerBase",
                columns: table => new
                {
                    idaddress = table.Column<int>(name: "id_address", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    addresstype = table.Column<byte>(name: "address_type", type: "tinyint", nullable: false),
                    localization = table.Column<string>(type: "varchar(100)", nullable: false),
                    district = table.Column<string>(type: "varchar(70)", nullable: false),
                    city = table.Column<string>(type: "varchar(70)", nullable: false),
                    state = table.Column<string>(type: "varchar(50)", nullable: false),
                    number = table.Column<string>(type: "varchar(15)", nullable: false),
                    zipcode = table.Column<string>(name: "zip_code", type: "varchar(20)", nullable: false),
                    complement = table.Column<string>(type: "varchar(100)", nullable: true),
                    country = table.Column<string>(type: "varchar(70)", nullable: false),
                    customerid = table.Column<int>(name: "customer_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.idaddress);
                    table.ForeignKey(
                        name: "FK_Address_Customer_customer_id",
                        column: x => x.customerid,
                        principalSchema: "CustomerBase",
                        principalTable: "Customer",
                        principalColumn: "id_customer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddress",
                schema: "CustomerBase",
                columns: table => new
                {
                    idemailAddress = table.Column<int>(name: "id_emailAddress", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emailtype = table.Column<byte>(name: "email_type", type: "tinyint", nullable: false),
                    email = table.Column<string>(type: "varchar(150)", nullable: false),
                    customerid = table.Column<int>(name: "customer_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddress", x => x.idemailAddress);
                    table.ForeignKey(
                        name: "FK_EmailAddress_Customer_customer_id",
                        column: x => x.customerid,
                        principalSchema: "CustomerBase",
                        principalTable: "Customer",
                        principalColumn: "id_customer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telephone",
                schema: "CustomerBase",
                columns: table => new
                {
                    idtelephone = table.Column<int>(name: "id_telephone", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    telephonetype = table.Column<byte>(name: "telephone_type", type: "tinyint", nullable: false),
                    ddi = table.Column<string>(type: "varchar(6)", nullable: false),
                    ddd = table.Column<string>(type: "varchar(3)", nullable: true),
                    phonenumber = table.Column<string>(name: "phone_number", type: "varchar(11)", nullable: false),
                    customerid = table.Column<int>(name: "customer_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telephone", x => x.idtelephone);
                    table.ForeignKey(
                        name: "FK_Telephone_Customer_customer_id",
                        column: x => x.customerid,
                        principalSchema: "CustomerBase",
                        principalTable: "Customer",
                        principalColumn: "id_customer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_customer_id",
                schema: "CustomerBase",
                table: "Address",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddress_customer_id",
                schema: "CustomerBase",
                table: "EmailAddress",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Telephone_customer_id",
                schema: "CustomerBase",
                table: "Telephone",
                column: "customer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address",
                schema: "CustomerBase");

            migrationBuilder.DropTable(
                name: "EmailAddress",
                schema: "CustomerBase");

            migrationBuilder.DropTable(
                name: "Telephone",
                schema: "CustomerBase");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "CustomerBase");
        }
    }
}
