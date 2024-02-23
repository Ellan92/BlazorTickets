using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorTicketsApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsResolved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responses_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketTags",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTags", x => new { x.TicketId, x.TagId });
                    table.ForeignKey(
                        name: "FK_TicketTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketTags_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CSharp" },
                    { 2, "DotNet" },
                    { 3, "Blazor" },
                    { 4, "Java" },
                    { 5, "JavaScript" },
                    { 6, "Python" },
                    { 7, "HTML" },
                    { 8, "CSS" },
                    { 9, "SQL" },
                    { 10, "NoSQL" },
                    { 11, "Git" },
                    { 12, "Docker" },
                    { 13, "Kubernetes" },
                    { 14, "MachineLearning" },
                    { 15, "ArtificialIntelligence" },
                    { 16, "DataScience" },
                    { 17, "WebDevelopment" },
                    { 18, "MobileDevelopment" },
                    { 19, "GameDevelopment" },
                    { 20, "CloudComputing" },
                    { 21, "AWS" },
                    { 22, "BlazorTickets4Azure" },
                    { 23, "GCP" },
                    { 24, "DevOps" },
                    { 25, "CI_CD" },
                    { 26, "Agile" },
                    { 27, "Scrum" },
                    { 28, "Security" },
                    { 29, "Blockchain" },
                    { 30, "IoT" },
                    { 31, "AR_VR" },
                    { 32, "UI_UX" },
                    { 33, "Algorithms" },
                    { 34, "DataStructures" },
                    { 35, "DesignPatterns" },
                    { 36, "FunctionalProgramming" },
                    { 37, "ObjectOrientedProgramming" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Description", "IsResolved", "SubmittedBy", "Title" },
                values: new object[,]
                {
                    { 1, "Description for Ticket 1", false, "User1", "Ticket 1" },
                    { 2, "Description for Ticket 2", false, "User2", "Ticket 2" },
                    { 3, "Description for Ticket 3", false, "User3", "Ticket 3" }
                });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "Id", "Response", "SubmittedBy", "TicketId" },
                values: new object[,]
                {
                    { 1, "Response for Ticket 1", "User1", 1 },
                    { 2, "Response for Ticket 2", "User2", 2 },
                    { 3, "Response for Ticket 3", "User3", 3 }
                });

            migrationBuilder.InsertData(
                table: "TicketTags",
                columns: new[] { "TagId", "TicketId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_TicketId",
                table: "Responses",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTags_TagId",
                table: "TicketTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "TicketTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
