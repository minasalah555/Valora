using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Valora.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryId", "CreatedAt", "CreatedBy", "Description", "ImgUrl", "IsDeleted", "Name", "Price", "StockQuantity", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 21, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Muted horizon oil work.", "https://picsum.photos/seed/oil3/600/400?grayscale", false, "Monochrome Horizon", 460, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 22, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Grayscale forest scene.", "https://picsum.photos/seed/oil4/600/400?grayscale", false, "Silent Forest", 480, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 23, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "City at dusk.", "https://picsum.photos/seed/oil5/600/400?grayscale", false, "Urban Twilight", 530, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 24, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Monochrome sea waves.", "https://picsum.photos/seed/oil6/600/400?grayscale", false, "Ocean Study", 500, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 25, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Oil portrait minimal.", "https://picsum.photos/seed/oil7/600/400?grayscale", false, "Portrait Shade", 650, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 26, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Layered mountain forms.", "https://picsum.photos/seed/oil8/600/400?grayscale", false, "Mountain Veil", 560, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 27, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Soft harbor study.", "https://picsum.photos/seed/oil9/600/400?grayscale", false, "Fog Harbor", 470, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 28, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Minimal path landscape.", "https://picsum.photos/seed/oil10/600/400?grayscale", false, "Rural Path", 445, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 29, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Geometric grayscale acrylic.", "https://picsum.photos/seed/acrylic3/600/400?grayscale", false, "Acrylic Geometry", 400, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 30, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Dynamic brush strokes.", "https://picsum.photos/seed/acrylic4/600/400?grayscale", false, "Acrylic Motion", 410, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 31, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Layered abstract study.", "https://picsum.photos/seed/acrylic5/600/400?grayscale", false, "Acrylic Layers", 395, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 32, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Urban grid concept.", "https://picsum.photos/seed/acrylic6/600/400?grayscale", false, "Acrylic City Grid", 430, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 33, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Fluid grayscale forms.", "https://picsum.photos/seed/acrylic7/600/400?grayscale", false, "Acrylic Flow", 415, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 34, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Echoing shapes.", "https://picsum.photos/seed/acrylic8/600/400?grayscale", false, "Acrylic Echo", 390, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 35, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "High contrast study.", "https://picsum.photos/seed/acrylic9/600/400?grayscale", false, "Acrylic Contrast", 420, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 36, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Minimal field scene.", "https://picsum.photos/seed/acrylic10/600/400?grayscale", false, "Acrylic Field", 405, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 37, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Subtle gradient wash.", "https://picsum.photos/seed/water3/600/400?grayscale", false, "Water Shade", 255, 12, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 38, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Soft bloom effect.", "https://picsum.photos/seed/water4/600/400?grayscale", false, "Water Bloom", 250, 14, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 39, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Fading distant line.", "https://picsum.photos/seed/water5/600/400?grayscale", false, "Water Horizon", 245, 11, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 40, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Botanical impression.", "https://picsum.photos/seed/water6/600/400?grayscale", false, "Water Garden", 235, 13, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 41, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Misty atmosphere.", "https://picsum.photos/seed/water7/600/400?grayscale", false, "Water Mist", 265, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 42, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Flowing water forms.", "https://picsum.photos/seed/water8/600/400?grayscale", false, "Water Flow", 258, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 43, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Technical wash study.", "https://picsum.photos/seed/water9/600/400?grayscale", false, "Water Study", 240, 15, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 44, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Drifting shapes.", "https://picsum.photos/seed/water10/600/400?grayscale", false, "Water Drift", 252, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 45, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Gesture sketch series.", "https://picsum.photos/seed/sketch3/600/400?grayscale", false, "Figure Study II", 130, 18, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 46, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Minimal line portrait.", "https://picsum.photos/seed/sketch4/600/400?grayscale", false, "Portrait Line", 150, 12, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 47, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Facade draft sketch.", "https://picsum.photos/seed/sketch5/600/400?grayscale", false, "Architecture Draft", 145, 13, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 48, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Detailed hand drawing.", "https://picsum.photos/seed/sketch6/600/400?grayscale", false, "Hand Study", 125, 20, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 49, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Street quick sketch.", "https://picsum.photos/seed/sketch7/600/400?grayscale", false, "Urban Sketch", 135, 16, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 50, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Objects rough outline.", "https://picsum.photos/seed/sketch8/600/400?grayscale", false, "Still Life Draft", 115, 22, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 51, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Wildlife motion sketch.", "https://picsum.photos/seed/sketch9/600/400?grayscale", false, "Animal Study", 118, 19, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 52, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Faces expression set.", "https://picsum.photos/seed/sketch10/600/400?grayscale", false, "Expression Series", 155, 14, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 53, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Grid-based composition.", "https://picsum.photos/seed/print3/600/400?grayscale", false, "Print Grid", 70, 60, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 54, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Waveform abstraction.", "https://picsum.photos/seed/print4/600/400?grayscale", false, "Print Wave", 68, 55, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 55, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Orbital pattern.", "https://picsum.photos/seed/print5/600/400?grayscale", false, "Print Orbit", 72, 58, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 56, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Mesh lattice form.", "https://picsum.photos/seed/print6/600/400?grayscale", false, "Print Mesh", 66, 65, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 57, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Pulse line series.", "https://picsum.photos/seed/print7/600/400?grayscale", false, "Print Pulse", 69, 62, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 58, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Ultra-minimal design.", "https://picsum.photos/seed/print8/600/400?grayscale", false, "Print Minimal", 75, 54, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 59, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Concentric ring set.", "https://picsum.photos/seed/print9/600/400?grayscale", false, "Print Rings", 71, 57, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 60, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Axis line concept.", "https://picsum.photos/seed/print10/600/400?grayscale", false, "Print Axis", 67, 59, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 61, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Spiral carved oak.", "https://picsum.photos/seed/wood3/600/400?grayscale", false, "Oak Spiral", 740, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 62, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Curved pine shape.", "https://picsum.photos/seed/wood4/600/400?grayscale", false, "Pine Curve", 710, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 63, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Abstract walnut block.", "https://picsum.photos/seed/wood5/600/400?grayscale", false, "Walnut Form", 760, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 64, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Stacked birch shapes.", "https://picsum.photos/seed/wood6/600/400?grayscale", false, "Birch Totem", 790, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 65, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Polished elm slice.", "https://picsum.photos/seed/wood7/600/400?grayscale", false, "Elm Slice", 705, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 66, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Experimental maple form.", "https://picsum.photos/seed/wood8/600/400?grayscale", false, "Maple Study", 725, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 67, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Twisted cedar piece.", "https://picsum.photos/seed/wood9/600/400?grayscale", false, "Cedar Twist", 750, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 68, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Vertical ash pillar.", "https://picsum.photos/seed/wood10/600/400?grayscale", false, "Ash Pillar", 820, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 69, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Axis themed granite.", "https://picsum.photos/seed/stone3/600/400?grayscale", false, "Granite Axis", 1150, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 70, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Folded marble form.", "https://picsum.photos/seed/stone4/600/400?grayscale", false, "Marble Fold", 1520, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 71, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Stacked basalt pieces.", "https://picsum.photos/seed/stone5/600/400?grayscale", false, "Basalt Stack", 1080, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 72, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Arced limestone study.", "https://picsum.photos/seed/stone6/600/400?grayscale", false, "Limestone Arc", 1040, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 73, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Minimal marble column.", "https://picsum.photos/seed/stone7/600/400?grayscale", false, "Marble Column", 1490, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 74, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Flat slate surface.", "https://picsum.photos/seed/stone8/600/400?grayscale", false, "Slate Plane", 990, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 75, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Curved onyx piece.", "https://picsum.photos/seed/stone9/600/400?grayscale", false, "Onyx Curve", 1300, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 76, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Core texture study.", "https://picsum.photos/seed/stone10/600/400?grayscale", false, "Travertine Core", 1010, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 77, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Circular steel form.", "https://picsum.photos/seed/metal3/600/400?grayscale", false, "Steel Ring", 920, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 78, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Folded aluminum plate.", "https://picsum.photos/seed/metal4/600/400?grayscale", false, "Aluminum Fold", 870, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 79, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Cast bronze form.", "https://picsum.photos/seed/metal5/600/400?grayscale", false, "Bronze Cast", 1050, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 80, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Curved copper piece.", "https://picsum.photos/seed/metal6/600/400?grayscale", false, "Copper Curve", 910, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 81, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Mesh titanium structure.", "https://picsum.photos/seed/metal7/600/400?grayscale", false, "Titanium Mesh", 1150, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 82, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Spine-like iron work.", "https://picsum.photos/seed/metal8/600/400?grayscale", false, "Iron Spine", 890, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 83, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Woven steel rods.", "https://picsum.photos/seed/metal9/600/400?grayscale", false, "Steel Weave", 960, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 84, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Axis themed metal.", "https://picsum.photos/seed/metal10/600/400?grayscale", false, "Metal Axis", 980, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 85, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Matte shallow bowl.", "https://picsum.photos/seed/ceramic3/600/400?grayscale", false, "Ceramic Bowl", 190, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 86, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Textured wall relief.", "https://picsum.photos/seed/ceramic4/600/400?grayscale", false, "Clay Relief", 230, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 87, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Minimal plate form.", "https://picsum.photos/seed/ceramic5/600/400?grayscale", false, "Stoneware Plate", 175, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 88, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Tapered vessel.", "https://picsum.photos/seed/ceramic6/600/400?grayscale", false, "Clay Vessel", 200, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 89, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Thin walled cup.", "https://picsum.photos/seed/ceramic7/600/400?grayscale", false, "Porcelain Cup", 160, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 90, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Smooth cylinder form.", "https://picsum.photos/seed/ceramic8/600/400?grayscale", false, "Clay Cylinder", 185, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 91, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Rustic jar shape.", "https://picsum.photos/seed/ceramic9/600/400?grayscale", false, "Earthen Jar", 210, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 92, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Spherical matte form.", "https://picsum.photos/seed/ceramic10/600/400?grayscale", false, "Ceramic Globe", 195, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 93, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Tiny abstract block.", "https://picsum.photos/seed/mini3/600/400?grayscale", false, "Mini Abstract", 105, 30, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 94, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Small portrait frame.", "https://picsum.photos/seed/mini4/600/400?grayscale", false, "Mini Portrait", 115, 26, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 95, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Tiny grayscale landscape.", "https://picsum.photos/seed/mini5/600/400?grayscale", false, "Mini Landscape II", 100, 28, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 96, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Metal miniature form.", "https://picsum.photos/seed/mini6/600/400?grayscale", false, "Mini Metal", 125, 22, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 97, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Tiny ceramic piece.", "https://picsum.photos/seed/mini7/600/400?grayscale", false, "Mini Ceramic", 98, 24, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 98, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Small wood carving.", "https://picsum.photos/seed/mini8/600/400?grayscale", false, "Mini Wood", 112, 21, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 99, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Carved stone miniature.", "https://picsum.photos/seed/mini9/600/400?grayscale", false, "Mini Stone", 118, 19, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 100, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Minimal micro form.", "https://picsum.photos/seed/mini10/600/400?grayscale", false, "Mini Form", 102, 27, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 100);
        }
    }
}
