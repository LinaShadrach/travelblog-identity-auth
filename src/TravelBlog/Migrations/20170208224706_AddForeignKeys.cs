using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelBlog.Migrations
{
    public partial class AddForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExperienceId",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Experiences",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_ExperienceId",
                table: "People",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_People_LocationId",
                table: "People",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_LocationId",
                table: "Experiences",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Locations_LocationId",
                table: "Experiences",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Experiences_ExperienceId",
                table: "People",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "ExperienceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Locations_LocationId",
                table: "People",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Locations_LocationId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Experiences_ExperienceId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Locations_LocationId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_ExperienceId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_LocationId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_LocationId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "ExperienceId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Experiences");
        }
    }
}
