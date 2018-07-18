using Microsoft.EntityFrameworkCore.Migrations;

namespace CoderUlWPFApplication.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ImagePath = table.Column<string>(maxLength: 655, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ImageName = table.Column<string>(maxLength: 655, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Message = table.Column<string>(maxLength: 655, nullable: false),
                    NotificationTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_NotificationTypes_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "NotificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationLocation",
                columns: table => new
                {
                    NotificationId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationLocation", x => new { x.LocationId, x.NotificationId });
                    table.ForeignKey(
                        name: "FK_NotificationLocation_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationLocation_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "NotificationTypes",
                columns: new[] { "Id", "ImageName", "Name" },
                values: new object[] { 1, "Alert_type_water_leak.png", "Протечка воды" });

            migrationBuilder.InsertData(
                table: "NotificationTypes",
                columns: new[] { "Id", "ImageName", "Name" },
                values: new object[] { 2, "Alert_type_temperature.png", "Температура" });

            migrationBuilder.InsertData(
                table: "NotificationTypes",
                columns: new[] { "Id", "ImageName", "Name" },
                values: new object[] { 3, "Alert_type_fire.png", "Пожарная сигнализация" });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Message", "NotificationTypeId" },
                values: new object[] { 1, "Тестовое напоминание 1", 1 });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Message", "NotificationTypeId" },
                values: new object[] { 2, "Тестовое напоминание 2", 1 });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Message", "NotificationTypeId" },
                values: new object[] { 3, "Тестовое напоминание 3", 2 });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Message", "NotificationTypeId" },
                values: new object[] { 4, "Тестовое напоминание 4", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationLocation_NotificationId",
                table: "NotificationLocation",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_NotificationTypeId",
                table: "Notifications",
                column: "NotificationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationLocation");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationTypes");
        }
    }
}
