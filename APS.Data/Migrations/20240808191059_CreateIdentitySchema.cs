using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APS.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateIdentitySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    description = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    isAuthorized = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user__B9BE370F252B5F0B", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    account_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    balance = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0.00m),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__account__46A222CD8FCF3D16", x => x.account_id);
                    table.ForeignKey(
                        name: "FK__account__user_id__3E52440B",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "authorizations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    pages = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authorizations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Authorizations",
                        column: x => x.id,
                        principalTable: "user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    notification_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    message = table.Column<string>(type: "text", nullable: true),
                    is_read = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__notifica__E059842F1505EBC6", x => x.notification_id);
                    table.ForeignKey(
                        name: "FK__notificat__user___4316F928",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_user_id",
                table: "account",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_user_id",
                table: "notifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__user__AB6E6164370A04BB",
                table: "user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__user__F3DBC572BFEF5BB5",
                table: "user",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "authorizations");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
