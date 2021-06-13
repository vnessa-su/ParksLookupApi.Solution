using Microsoft.EntityFrameworkCore.Migrations;

namespace ParksLookupApi.Migrations
{
    public partial class AddSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Parks meant to preserve, unimpaired, natural and cultural resources for enjoyment, education, and inspiration of this and future generations.", "National Park" },
                    { 2, "Parks meant to sustain the health, diversity, and productivity of the Nation’s forests and grasslands to meet the needs of many purposes — timber, recreation, grazing, wildlife, fish and more.", "National Forest" },
                    { 3, "Park meant to preserve enhanced recreational opportunities in places with significant natural and scenic resources.", "National Recreation Area" },
                    { 4, "Parks established by a state to preserve a location on account of its natural beauty, historic interest, or recreational potential.", "State Park" },
                    { 5, "Parks in cities and other incorporated places to offer recreation and green space to residents of, and visitors to, the municipality.", "Urban Park" }
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Address", "CategoryId", "City", "Latitude", "Longitude", "Name", "State" },
                values: new object[,]
                {
                    { 1, "9035 Village Drive", 1, "Yosemite Valley", 37.7481m, -119.585043m, "Yosemite National Park", "CA" },
                    { 2, "191W Atlantic Ave", 3, "Boston", 42.3601m, -71.052016m, "Boston Harbor Islands", "MA" },
                    { 3, "71 White Mountain Drive", 2, "Campton", 43.813494m, -71.670031m, "White Mountain National Forest", "NH" },
                    { 4, "39000 State Route 706 E", 1, "Ashford", 46.740971951204436m, -121.9183777100494m, "Mount Rainier National Park", "WA" },
                    { 5, "Cape Arago State Park", 4, "Coos Bay", 43.30631746486028m, -124.39905271425728m, "Cape Arago State Park", "OR" },
                    { 6, "1320 Monroe Dr NE", 5, "Atlanta", 33.788359813469214m, -84.37293713315903m, "Piedmont Park", "GA" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 6);
        }
    }
}
