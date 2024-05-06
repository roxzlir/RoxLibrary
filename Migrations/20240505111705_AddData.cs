using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoxLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.InsertData(
            table: "Books",
            columns: ["BookTitle", "BookAuthor", "BookGenre", "BookQuantity"],
            values: new object[,]
        {
            { "Programmering 101", "Leif Nyberg", "Learning", 10 },
            { "Allt om Databaser", "Reidar Nilsen", "Learning", 5 },
            { "Star Wars Episod 15", "George Lukas", "Sci-fi", 15 },
            { "The coffetable book", "Cosmo Kramer", "Designe", 15 },
            { "Cell 8", "Roslund Hellström", "Crime", 3 },
            { "Emil's bästa recept", "Emil Nordin", "Cooking", 4 },
            { "Star Wars Episod 16", "George Lukas", "Sci-fi", 12 },
            { "Rise of Ceasar", "Conn Igulden", "History", 10 },

        });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: ["CustomerName", "CustomerPhone", "CustomerEmail"],
                values: new object[,]
                {
                    {"Anders Hansson", "0731237784", "anders.hansson@gmail.com" },
                    {"Victor Ljunglöf","0704351156", "victor.ljunglof@gmail.com" },
                    {"Angelica Lindström", "0734223084", "angelica.lindstrom@gmail.com" },
                    {"Emelie Lidén", "0726702039", "emelie.lideeen@gmail.com" },
                    {"Linda Ericsson", "0706637701", "linda.ericsson@gmail.com" },
                    {"Petter Gustafsson", "0709943008", "petter.gustafsson@gmail.com" },
                    {"Jessica Nilsson", "0724448171", "jesssica.nilsson@gmail.com" },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
