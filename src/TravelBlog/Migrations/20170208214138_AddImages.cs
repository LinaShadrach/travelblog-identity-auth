using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelBlog.Migrations
{
    public partial class AddImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonImage",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationImage",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExperienceImage",
                table: "Experiences",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonImage",
                table: "People");

            migrationBuilder.DropColumn(
                name: "LocationImage",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ExperienceImage",
                table: "Experiences");
        }
    }
}
