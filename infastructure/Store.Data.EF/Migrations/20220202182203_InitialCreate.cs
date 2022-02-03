using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Data.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isbn = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CellPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DeliveryUniqueCode = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DeliveryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryPrice = table.Column<decimal>(type: "money", nullable: false),
                    DeliveryParameters = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentServiceName = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    PaymentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentParameters = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "Description", "Isbn", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Даниэль Куссвюрм", "Изучите язык ассемблера x64, сосредоточившись на обновлениях набора команд x86, наиболее актуальных для разработки прикладных программ.", "ISBN0201029090", 1900m, "ПРОФЕССИОНАЛЬНОЕ ПРОГРАММИРОВАНИЕ НА АССЕМБЛЕРЕ X64С РАСШИРЕНИЯМИ AVX, AVX2 И AVX-512" },
                    { 2, "Роберт Нистрем", "Самый большой вызов для программиста видеоигр - закончить игру. Громоздкий и запутанный код часто становится неразрешимой проблемой, которая тянет проект на дно и деморализует всю команду. Об этом, как никто другой, знает Роберт Нистрем, восемь лет проработавший в Electronic Arts.", "ISBN0321029090", 879m, "ПАТТЕРНЫ ПРОГРАММИРОВАНИЯ ИГР" },
                    { 3, "Дэвид Флэнаган", "егулярно ищете в интернете сведения по Java? Разработчикам приложений для Web 2.0 иногда приходится несладко, ведь их профессия – одна из самых передовых", "ISBN0451029090", 1004m, "JAVASCRIPT. ПОДРОБНОЕ РУКОВОДСТВО. 6-Е ИЗД" },
                    { 4, "Роберт Сикорд", "Мир работает на коде, написанном на C, но в большинстве учебных заведений программированию учат на Python или Java. Книга «Эффективный С для профессионалов» восполняет этот пробел и предлагает современный взгляд на C. ", "ISBN0561029090", 1039m, "ЭФФЕКТИВНЫЙ C. ПРОФЕССИОНАЛЬНОЕ ПРОГРАММИРОВАНИЕ" },
                    { 5, "Билл Любанович", "«Простой Python» познакомит вас с одним из самых популярных языков программирования. Книга идеально подойдет как начинающим, так и опытным программистам, желающим добавить Python к списку освоенных языков. ", "ISBN0661029090", 1139m, "ПРОСТОЙ PYTHON." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
