using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinVitamin_Manager.Migrations
{
    public partial class last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Vk = table.Column<string>(nullable: true),
                    Metro = table.Column<int>(nullable: false),
                    HaveCar = table.Column<bool>(nullable: false),
                    DateOfBirdth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersRegion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsCompleted = table.Column<bool>(nullable: false),
                    PaymentStatus = table.Column<int>(nullable: false),
                    TypeOfPayment = table.Column<int>(nullable: false),
                    ProccessingStatus = table.Column<int>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    StartExecute = table.Column<DateTime>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerPhone = table.Column<string>(nullable: true),
                    CustomerEmail = table.Column<string>(nullable: true),
                    CustomerAdress = table.Column<string>(nullable: true),
                    RecipientFullName = table.Column<string>(nullable: true),
                    RecipientTelephone = table.Column<string>(nullable: true),
                    AdressDilivery = table.Column<string>(nullable: true),
                    SendVariant = table.Column<int>(nullable: false),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    TypeOfPacking = table.Column<int>(nullable: false),
                    SendingCost = table.Column<double>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersRegion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersSpb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsCompleted = table.Column<bool>(nullable: false),
                    PaymentStatus = table.Column<int>(nullable: false),
                    TypeOfPayment = table.Column<int>(nullable: false),
                    ProccessingStatus = table.Column<int>(nullable: false),
                    TypeOfDelivery = table.Column<int>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    StartExecute = table.Column<DateTime>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerPhone = table.Column<string>(nullable: true),
                    CustomerEmail = table.Column<string>(nullable: true),
                    CustomerAdress = table.Column<string>(nullable: true),
                    RecipientFullName = table.Column<string>(nullable: true),
                    RecipientTelephone = table.Column<string>(nullable: true),
                    MetroStation = table.Column<int>(nullable: false),
                    AdressDilivery = table.Column<string>(nullable: true),
                    DateDilivery = table.Column<DateTime>(nullable: false),
                    TimeDilivery = table.Column<string>(nullable: true),
                    DelivetyCost = table.Column<double>(nullable: false),
                    TypeOfOffice = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersSpb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Decsription = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    PurchasePrice = table.Column<double>(nullable: false),
                    ProviderType = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    CurrentBalance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceForCourers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WorkCourerId = table.Column<int>(nullable: true),
                    DataForInvoice = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceForCourers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceForCourers_Courers_WorkCourerId",
                        column: x => x.WorkCourerId,
                        principalTable: "Courers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderProdusts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    OldCount = table.Column<int>(nullable: false),
                    OrderRegionId = table.Column<int>(nullable: true),
                    OrderSpbId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProdusts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProdusts_OrdersRegion_OrderRegionId",
                        column: x => x.OrderRegionId,
                        principalTable: "OrdersRegion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderProdusts_OrdersSpb_OrderSpbId",
                        column: x => x.OrderSpbId,
                        principalTable: "OrdersSpb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderProdusts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PresenceOrderRegion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderRegionId = table.Column<int>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    ChangeTime = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresenceOrderRegion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresenceOrderRegion_OrdersRegion_OrderRegionId",
                        column: x => x.OrderRegionId,
                        principalTable: "OrdersRegion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PresenceOrderRegion_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PresenceOrderSpb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderSpbId = table.Column<int>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    ChangeTime = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresenceOrderSpb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresenceOrderSpb_OrdersSpb_OrderSpbId",
                        column: x => x.OrderSpbId,
                        principalTable: "OrdersSpb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PresenceOrderSpb_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourerTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderSpbId = table.Column<int>(nullable: false),
                    CourerId = table.Column<int>(nullable: false),
                    InvoiceForCourerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourerTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourerTasks_Courers_CourerId",
                        column: x => x.CourerId,
                        principalTable: "Courers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourerTasks_InvoiceForCourers_InvoiceForCourerId",
                        column: x => x.InvoiceForCourerId,
                        principalTable: "InvoiceForCourers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourerTasks_OrdersSpb_OrderSpbId",
                        column: x => x.OrderSpbId,
                        principalTable: "OrdersSpb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourerTasks_CourerId",
                table: "CourerTasks",
                column: "CourerId");

            migrationBuilder.CreateIndex(
                name: "IX_CourerTasks_InvoiceForCourerId",
                table: "CourerTasks",
                column: "InvoiceForCourerId");

            migrationBuilder.CreateIndex(
                name: "IX_CourerTasks_OrderSpbId",
                table: "CourerTasks",
                column: "OrderSpbId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceForCourers_WorkCourerId",
                table: "InvoiceForCourers",
                column: "WorkCourerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProdusts_OrderRegionId",
                table: "OrderProdusts",
                column: "OrderRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProdusts_OrderSpbId",
                table: "OrderProdusts",
                column: "OrderSpbId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProdusts_ProductId",
                table: "OrderProdusts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PresenceOrderRegion_OrderRegionId",
                table: "PresenceOrderRegion",
                column: "OrderRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_PresenceOrderRegion_ProductId",
                table: "PresenceOrderRegion",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PresenceOrderSpb_OrderSpbId",
                table: "PresenceOrderSpb",
                column: "OrderSpbId");

            migrationBuilder.CreateIndex(
                name: "IX_PresenceOrderSpb_ProductId",
                table: "PresenceOrderSpb",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "CourerTasks");

            migrationBuilder.DropTable(
                name: "OrderProdusts");

            migrationBuilder.DropTable(
                name: "PresenceOrderRegion");

            migrationBuilder.DropTable(
                name: "PresenceOrderSpb");

            migrationBuilder.DropTable(
                name: "InvoiceForCourers");

            migrationBuilder.DropTable(
                name: "OrdersRegion");

            migrationBuilder.DropTable(
                name: "OrdersSpb");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Courers");
        }
    }
}
