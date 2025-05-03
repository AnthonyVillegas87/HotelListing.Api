using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelListing.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2827a752-4220-4976-8a85-f258bf910a95", null, "User", "USER" },
                    { "670cef14-ba79-4cd9-8ef9-b23b28da86a5", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "United States", "USA" },
                    { 2, "United Kingdom", "UK" },
                    { 3, "France", "FR" },
                    { 4, "Germany", "DE" },
                    { 5, "Italy", "IT" },
                    { 6, "Spain", "ES" },
                    { 7, "Portugal", "PT" },
                    { 8, "Netherlands", "NL" },
                    { 9, "Sweden", "SE" },
                    { 10, "Australia", "AU" },
                    { 11, "Canada", "CA" },
                    { 12, "New Zealand", "NZ" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "1535 Broadway, New York", 1, "Marriott Times Square", 4.5 },
                    { 2, "Strand, London WC2R 0EU", 2, "The Savoy", 4.7999999999999998 },
                    { 3, "15 Place Vendôme, 75001 Paris", 3, "Ritz Paris", 4.9000000000000004 },
                    { 4, "Unter den Linden 77, 10117 Berlin", 4, "Hotel Adlon Kempinski", 4.7000000000000002 },
                    { 5, "Via del Babuino 9, Rome", 5, "Hotel de Russie", 4.5999999999999996 },
                    { 6, "Passeig de Gràcia 38-40, Barcelona", 6, "Mandarin Oriental Barcelona", 4.7999999999999998 },
                    { 7, "199 George St, Sydney NSW 2000", 10, "Four Seasons Sydney", 4.7000000000000002 },
                    { 8, "405 Spray Ave, Banff, AB", 11, "Fairmont Banff Springs", 4.7999999999999998 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2827a752-4220-4976-8a85-f258bf910a95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "670cef14-ba79-4cd9-8ef9-b23b28da86a5");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 11);
        }
    }
}
