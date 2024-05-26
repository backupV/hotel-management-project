using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customer_id = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    contact_number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    credit_card = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    id_proof = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    deleted_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__customer__CD65CB85EA241678", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "room_type",
                columns: table => new
                {
                    room_type_id = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    room_type_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    bed_amount = table.Column<int>(type: "int", nullable: false),
                    room_price = table.Column<decimal>(type: "money", nullable: false),
                    room_type_desc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    room_type_img = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    deleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    deleted_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__room_typ__42395E8460623310", x => x.room_type_id);
                });

            migrationBuilder.CreateTable(
                name: "service",
                columns: table => new
                {
                    service_id = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    service_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    service_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    service_price = table.Column<decimal>(type: "money", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    deleted_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__service__3E0DB8AFF2C18B61", x => x.service_id);
                });

            migrationBuilder.CreateTable(
                name: "staff",
                columns: table => new
                {
                    staff_id = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    position = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    contact_number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    birthday = table.Column<DateTime>(type: "date", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    salary = table.Column<decimal>(type: "money", nullable: true),
                    deleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    deleted_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__staff__1963DD9CFB396E3F", x => x.staff_id);
                });

            migrationBuilder.CreateTable(
                name: "room",
                columns: table => new
                {
                    room_id = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    room_number = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    notes = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    room_type_id = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    deleted_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__room__19675A8A401BF51A", x => x.room_id);
                    table.ForeignKey(
                        name: "r_room_type_id_fk",
                        column: x => x.room_type_id,
                        principalTable: "room_type",
                        principalColumn: "room_type_id");
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    profile_picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    staff_id = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__account__F3DBC573C3AB2CB1", x => x.username);
                    table.ForeignKey(
                        name: "acc_staff_id_fk",
                        column: x => x.staff_id,
                        principalTable: "staff",
                        principalColumn: "staff_id");
                });

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    invoice_id = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    customer_id = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    staff_id = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    invoice_date = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    total_amount = table.Column<decimal>(type: "money", nullable: true),
                    payment_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    deleted_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__invoice__F58DFD4983235F70", x => x.invoice_id);
                    table.ForeignKey(
                        name: "in_customer_id_fk",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "customer_id");
                    table.ForeignKey(
                        name: "in_staff_id_fk",
                        column: x => x.staff_id,
                        principalTable: "staff",
                        principalColumn: "staff_id");
                });

            migrationBuilder.CreateTable(
                name: "booking",
                columns: table => new
                {
                    booking_id = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    invoice_id = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    room_id = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    guest_quantity = table.Column<int>(type: "int", nullable: false),
                    check_in_date = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    check_out_date = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    total_amount = table.Column<decimal>(type: "money", nullable: true),
                    deleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    deleted_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__booking__5DE3A5B13FD7C644", x => x.booking_id);
                    table.ForeignKey(
                        name: "b_invoice_id_fk",
                        column: x => x.invoice_id,
                        principalTable: "invoice",
                        principalColumn: "invoice_id");
                    table.ForeignKey(
                        name: "b_room_id_fk",
                        column: x => x.room_id,
                        principalTable: "room",
                        principalColumn: "room_id");
                });

            migrationBuilder.CreateTable(
                name: "service_use",
                columns: table => new
                {
                    invoice_id = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    service_id = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    service_quantity = table.Column<int>(type: "int", nullable: true),
                    total_amount = table.Column<decimal>(type: "money", nullable: true),
                    deleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    deleted_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("su_booking_service_pk", x => new { x.invoice_id, x.service_id });
                    table.ForeignKey(
                        name: "su_invoice_id_fk",
                        column: x => x.invoice_id,
                        principalTable: "invoice",
                        principalColumn: "invoice_id");
                    table.ForeignKey(
                        name: "su_service_id_fk",
                        column: x => x.service_id,
                        principalTable: "service",
                        principalColumn: "service_id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__account__1963DD9DC28BDAE4",
                table: "account",
                column: "staff_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_booking_invoice_id",
                table: "booking",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_booking_room_id",
                table: "booking",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "UQ__customer__A1D1BF21831D3536",
                table: "customer",
                column: "contact_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__customer__AB6E61640EAC5AAA",
                table: "customer",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__customer__C0CC90664A4CED78",
                table: "customer",
                column: "credit_card",
                unique: true,
                filter: "[credit_card] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__customer__DFB75B10A382F22D",
                table: "customer",
                column: "id_proof",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_invoice_customer_id",
                table: "invoice",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_staff_id",
                table: "invoice",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_room_room_type_id",
                table: "room",
                column: "room_type_id");

            migrationBuilder.CreateIndex(
                name: "UQ__room_typ__511E79A8737E6009",
                table: "room_type",
                column: "room_type_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__service__4A8EDF399222ED33",
                table: "service",
                column: "service_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_service_use_service_id",
                table: "service_use",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "UQ__staff__A1D1BF21B9E63F8F",
                table: "staff",
                column: "contact_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__staff__AB6E6164B8072C71",
                table: "staff",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "booking");

            migrationBuilder.DropTable(
                name: "service_use");

            migrationBuilder.DropTable(
                name: "room");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "service");

            migrationBuilder.DropTable(
                name: "room_type");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "staff");
        }
    }
}
