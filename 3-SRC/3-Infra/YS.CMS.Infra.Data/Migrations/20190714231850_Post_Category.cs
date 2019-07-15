using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YS.CMS.Infra.Data.Migrations
{
    public partial class Post_Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<Guid>(nullable: false),
                    UpdateUser = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    PublishDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Author = table.Column<Guid>(nullable: false),
                    CreateUser = table.Column<Guid>(nullable: false),
                    UpdateUser = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    RecycleDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCategory",
                columns: table => new
                {
                    PostId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategory", x => new { x.PostId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PostCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCategory_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostCategory_CategoryId",
                table: "PostCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostCategory");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
