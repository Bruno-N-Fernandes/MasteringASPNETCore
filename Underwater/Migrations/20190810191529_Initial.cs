﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Underwater.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aquariums",
                columns: table => new
                {
                    AquariumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Open = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aquariums", x => x.AquariumId);
                });

            migrationBuilder.CreateTable(
                name: "Fishes",
                columns: table => new
                {
                    FishId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ScientificName = table.Column<string>(nullable: false),
                    CommonName = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true),
                    PhotoFile = table.Column<byte[]>(nullable: true),
                    ImageMimeType = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    AquariumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fishes", x => x.FishId);
                    table.ForeignKey(
                        name: "FK_Fishes_Aquariums_AquariumId",
                        column: x => x.AquariumId,
                        principalTable: "Aquariums",
                        principalColumn: "AquariumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Aquariums",
                columns: new[] { "AquariumId", "Address", "Name", "Number", "Open" },
                values: new object[] { 1, "4121  Broadway Street", "Fish Aquarium", -337, true });

            migrationBuilder.InsertData(
                table: "Aquariums",
                columns: new[] { "AquariumId", "Address", "Name", "Number", "Open" },
                values: new object[] { 2, "3219  Central Avenue", "Ocean Aquarium", -1298, false });

            migrationBuilder.InsertData(
                table: "Aquariums",
                columns: new[] { "AquariumId", "Address", "Name", "Number", "Open" },
                values: new object[] { 3, "128  Stewart Street", "Best Aquarium", -6695, true });

            migrationBuilder.InsertData(
                table: "Fishes",
                columns: new[] { "FishId", "AquariumId", "CommonName", "ImageMimeType", "ImageName", "ImageURL", "Name", "PhotoFile", "ScientificName" },
                values: new object[] { 1, 1, null, "image/jpeg", "goldfish.jpg", null, "Goldfish", null, "Carassius auratus" });

            migrationBuilder.InsertData(
                table: "Fishes",
                columns: new[] { "FishId", "AquariumId", "CommonName", "ImageMimeType", "ImageName", "ImageURL", "Name", "PhotoFile", "ScientificName" },
                values: new object[] { 2, 1, null, "image/jpeg", "starfish.jpg", null, "Starfish", null, "Asteroidea" });

            migrationBuilder.InsertData(
                table: "Fishes",
                columns: new[] { "FishId", "AquariumId", "CommonName", "ImageMimeType", "ImageName", "ImageURL", "Name", "PhotoFile", "ScientificName" },
                values: new object[] { 3, 1, null, "image/jpeg", "clownfish.jpg", null, "Clownfish", null, "Amphiprion ocellaris" });

            migrationBuilder.CreateIndex(
                name: "IX_Fishes_AquariumId",
                table: "Fishes",
                column: "AquariumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fishes");

            migrationBuilder.DropTable(
                name: "Aquariums");
        }
    }
}
