using Microsoft.EntityFrameworkCore.Migrations;

namespace Evt.Test.Data.Migrations
{
    public partial class AddValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Orders (ProductId, CustomerId, CreatedAt, UpdatedAt) VALUES (1, 1, '2019-10-01T19:45:01.5744325+00:00', '')");

            migrationBuilder.Sql("INSERT INTO Orders (ProductId, CustomerId, CreatedAt, UpdatedAt) VALUES (4, 2, '2019-10-01T19:45:01.5744325+00:00', '')");

            migrationBuilder.Sql("INSERT INTO Orders (ProductId, CustomerId, CreatedAt, UpdatedAt) VALUES (2, 4, '2019-10-01T19:45:01.5744325+00:00', '')");

            migrationBuilder.Sql("INSERT INTO Orders (ProductId, CustomerId, CreatedAt, UpdatedAt) VALUES (3, 3, '2019-10-01T19:45:01.5744325+00:00', '')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Orders");
        }
    }
}
