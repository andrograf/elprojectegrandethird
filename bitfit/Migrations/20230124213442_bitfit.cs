using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using System.Resources;

#nullable disable

namespace bitfit.Migrations
{
    /// <inheritdoc />
    public partial class bitfit : Migration
    {
       
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sqlResName = typeof(bitfit).Namespace + ".20230124213442_bitfit.sql";
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
