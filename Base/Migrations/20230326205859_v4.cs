using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacilityType",
                schema: "dbo",
                table: "Facilities");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                schema: "dbo",
                table: "VisitResults",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacilityTypeId",
                schema: "dbo",
                table: "Facilities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FacilityTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    State = table.Column<int>(type: "int", nullable: true),
                    other = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModfiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModfiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_FacilityType", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_FacilityTypeId",
                schema: "dbo",
                table: "Facilities",
                column: "FacilityTypeId");

            migrationBuilder.AddForeignKey(
                name: "Fk_Facilities_FacilityType",
                schema: "dbo",
                table: "Facilities",
                column: "FacilityTypeId",
                principalSchema: "dbo",
                principalTable: "FacilityTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Fk_Facilities_FacilityType",
                schema: "dbo",
                table: "Facilities");

            migrationBuilder.DropTable(
                name: "FacilityTypes",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_FacilityTypeId",
                schema: "dbo",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Note",
                schema: "dbo",
                table: "VisitResults");

            migrationBuilder.DropColumn(
                name: "FacilityTypeId",
                schema: "dbo",
                table: "Facilities");

            migrationBuilder.AddColumn<string>(
                name: "FacilityType",
                schema: "dbo",
                table: "Facilities",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
