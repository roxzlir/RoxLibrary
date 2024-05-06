using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoxLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddDataBorrows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Borrows",
                columns: new[] { "BorrowDate", "BorrowReturnDate", "BorrowStatus", "FkCustomerId", "FkBookId" },
                values: new object[,]
                {
                    { "2024-05-01", null, 0, 2, 4 },
                    { "2024-04-29", null, 0, 2, 1 },
                    { "2024-05-04", null, 0, 4, 6 },
                    { "2024-05-02", null, 0, 3, 1 },
                    { "2024-04-16", null, 0, 3, 2 },
                    { "2024-03-01", "2024-03-20", 1, 2, 4 },
                    { "2024-04-20", null, 0, 6, 8 },
                    { "2024-02-13", "2024-02-28", 1, 6, 7 },
                    { "2024-04-29", null, 0, 5, 1 },
                    { "2024-05-03", null, 0, 5, 2 },
                    { "2024-05-06", null, 0, 7, 3 },
                });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
