using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryModel.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Isbn = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    Locked = table.Column<bool>(type: "bit", nullable: false),
                    TotalStock = table.Column<int>(type: "int", nullable: false),
                    CurrentStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    LibraryUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_LibraryUserId",
                        column: x => x.LibraryUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCheckouts",
                columns: table => new
                {
                    UserCheckoutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    LibraryUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCheckedOut = table.Column<DateTime>(type: "datetime2", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCheckouts", x => x.UserCheckoutId);
                    table.ForeignKey(
                        name: "FK_UserCheckouts_AspNetUsers_LibraryUserId",
                        column: x => x.LibraryUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCheckouts_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "CoverImage", "CurrentStock", "Description", "Isbn", "Locked", "PageCount", "Publisher", "Title", "TotalStock" },
                values: new object[,]
                {
                    { 1, "port", "2.jpeg", 1, "Dolorem nemo quos. Itaque nihil vitae hic est qui et neque quas. Eum libero voluptatem omnis eos. Ipsam voluptate qui hic voluptas repudiandae enim quo voluptatibus.", "345-5605-125-2425-3", false, 0, "driver", "Try to generate the XSS panel, maybe it will generate the open-source panel!", 1 },
                    { 2, "monitor", "2.jpeg", 1, "Quia officiis et quasi doloremque voluptas. Qui ipsa quis. Illo est dolorem ut dolorum et dolorum quae dolores et. Quasi qui dolore quasi voluptatibus dicta voluptas est. Vel laboriosam consequatur.", "302-3350-009-0097-0", false, 1, "matrix", "Try to hack the SAS panel, maybe it will hack the back-end panel!", 1 },
                    { 3, "monitor", "2.jpeg", 1, "Aliquid enim incidunt dignissimos dolores aut qui sed consectetur. Est ut maxime necessitatibus aut eveniet rerum. Sit praesentium architecto soluta tempora aliquam doloribus.", "139-2677-049-0795-2", false, 1, "feed", "If we navigate the circuit, we can get to the IB circuit through the cross-platform IB circuit!", 1 },
                    { 4, "interface", "3.jpeg", 1, "Alias repudiandae eos aliquid. Vel fuga eius ut et quae in aut. Velit autem voluptatem voluptatem officia impedit nihil.", "959-7335-638-3620-6", false, 1, "alarm", "Try to bypass the TCP program, maybe it will bypass the wireless program!", 1 },
                    { 5, "capacitor", "4.jpeg", 1, "Nihil molestiae nesciunt qui itaque quis. Quasi quia provident ut non. Pariatur non vel ut id cupiditate est quia.", "345-4325-950-7208-9", false, 1, "hard drive", "You can't compress the program without parsing the optical AI program!", 1 },
                    { 6, "circuit", "3.jpeg", 1, "Aliquam pariatur eum ipsam consequuntur sint perferendis iure nostrum illum. Omnis sint itaque blanditiis illum. Nam qui dolores omnis aperiam quis cum ad ipsam. Vel omnis sit quo earum explicabo nesciunt quibusdam.", "185-0115-614-4499-1", false, 1, "monitor", "If we input the program, we can get to the GB program through the haptic GB program!", 1 },
                    { 7, "feed", "4.jpeg", 1, "Quia quia saepe veniam illum amet rem quaerat. A et illum numquam illo. Quo sit quia pariatur et. Voluptatem voluptatem fuga cupiditate omnis dicta dolores. Eaque possimus id excepturi omnis a.", "802-0181-055-3637-2", false, 1, "circuit", "Use the online TCP sensor, then you can connect the online sensor!", 1 },
                    { 8, "card", "5.jpeg", 1, "Totam repellendus qui. Ut et ut quam id. Voluptatem harum iure dolorem. Iusto ad ipsam recusandae voluptatem voluptatem blanditiis et sunt non. Iste delectus aliquam unde incidunt quidem veritatis minus.", "115-8810-241-5141-8", false, 1, "bandwidth", "I'll generate the neural SMTP transmitter, that should transmitter the SMTP transmitter!", 1 },
                    { 9, "protocol", "3.jpeg", 1, "Sunt autem sit dicta similique. Voluptates quo reiciendis et est reprehenderit dolorum cupiditate quia non. Et veniam dolores modi modi officiis. Dolores qui rerum vitae cupiditate quibusdam rem. Odit harum et cumque fuga. Fugit harum nihil at optio ut.", "380-2618-111-7958-0", false, 1, "port", "quantifying the feed won't do anything, we need to override the cross-platform XML feed!", 1 },
                    { 10, "card", "4.jpeg", 1, "Veritatis vel rerum suscipit quis quia porro sequi molestias animi. Fuga non accusamus necessitatibus delectus dolorem adipisci corporis omnis molestiae. Distinctio in possimus officia est quaerat reiciendis esse explicabo. Voluptas iusto soluta. Nam omnis in modi est quidem unde.", "719-2876-696-3993-4", false, 0, "pixel", "You can't back up the microchip without backing up the optical PCI microchip!", 1 },
                    { 11, "sensor", "2.jpeg", 1, "Non ullam deleniti voluptate sapiente temporibus assumenda quaerat. Ut ad officia est. Sed repellat neque ut rem similique molestias aliquid impedit fugiat. Nemo sunt optio voluptatibus veniam officiis illum aperiam soluta et. Ad sint velit. Aperiam iste dicta pariatur sed in qui qui iure.", "093-3004-926-9304-8", false, 0, "card", "You can't copy the application without hacking the optical SMTP application!", 1 },
                    { 12, "interface", "5.jpeg", 1, "Neque sint impedit. Ut ipsa aspernatur quaerat non corrupti ea necessitatibus cum. In assumenda aut quam maxime quae recusandae qui. Repellat iure vel.", "857-5940-547-9335-5", false, 0, "microchip", "The GB port is down, back up the haptic port so we can back up the GB port!", 1 },
                    { 13, "monitor", "2.jpeg", 1, "Possimus consequatur impedit dignissimos voluptatem maiores numquam fugiat cupiditate voluptatum. Velit sit quas expedita earum ea dolor. Velit ullam laboriosam. Temporibus et est non reprehenderit qui quia rerum. Vel repellendus deleniti dolor voluptates necessitatibus nemo.", "736-6868-909-8874-4", false, 0, "program", "The SAS sensor is down, transmit the optical sensor so we can transmit the SAS sensor!", 1 },
                    { 14, "interface", "5.jpeg", 1, "Facilis assumenda voluptatem iure ea. Rerum consequatur placeat molestiae iste qui. Voluptate beatae placeat. Non impedit consequatur aperiam libero laborum facilis. Cumque hic sit est qui at ducimus.", "721-3839-110-4840-5", false, 0, "pixel", "hacking the bandwidth won't do anything, we need to generate the virtual EXE bandwidth!", 1 },
                    { 15, "circuit", "3.jpeg", 1, "Ab nam consequatur eaque laudantium. Atque quaerat molestiae odio enim illo sapiente. Ipsam voluptas velit ut. Nisi repellendus sed asperiores dignissimos autem.", "717-6713-728-4793-6", false, 0, "pixel", "We need to calculate the auxiliary SCSI application!", 1 },
                    { 16, "capacitor", "2.jpeg", 1, "Nisi esse sit. Accusantium ut recusandae magni dolor. Maxime facilis consequatur non pariatur voluptates et cum. Fuga iusto reprehenderit iusto magnam quos assumenda dolor molestias reiciendis.", "513-5949-564-7853-0", false, 1, "card", "I'll override the digital SDD system, that should system the SDD system!", 1 },
                    { 17, "bandwidth", "3.jpeg", 1, "Est et aliquid quaerat. Ut voluptatibus ut id neque sit nisi dicta soluta ipsam. Consectetur id ut autem repudiandae sint debitis dolorem facere. Dolore eum aliquam beatae et fugiat qui ipsa. Animi autem sint accusamus enim qui pariatur. Vel asperiores harum et fuga provident iusto autem.", "507-0731-095-9411-6", false, 1, "circuit", "We need to copy the mobile AI port!", 1 },
                    { 18, "protocol", "5.jpeg", 1, "Alias aut aspernatur aut est ratione laboriosam. Autem et officiis. Voluptatem ut saepe voluptates quis illum vero placeat molestias sed. Nihil qui voluptate hic qui voluptatum quia eum. Similique quo accusamus.", "915-2764-505-0035-8", false, 1, "alarm", "You can't index the capacitor without backing up the virtual IB capacitor!", 1 },
                    { 19, "feed", "3.jpeg", 1, "Voluptatem vitae voluptatem quaerat qui sit. Nihil ut cupiditate. Nam est numquam amet ad minus. Voluptatum molestiae nostrum. Temporibus ullam voluptas.", "292-2479-507-9314-6", false, 1, "array", "quantifying the hard drive won't do anything, we need to override the mobile THX hard drive!", 1 },
                    { 20, "bus", "2.jpeg", 1, "Nihil et delectus deserunt. Autem saepe qui placeat omnis aut. Et consequatur sed odit facilis qui nostrum autem.", "743-6495-141-7279-1", false, 0, "program", "The GB firewall is down, override the redundant firewall so we can override the GB firewall!", 1 },
                    { 21, "card", "5.jpeg", 1, "Tenetur ab nemo et illum nihil modi. Vero enim voluptate consequuntur omnis et mollitia. Debitis vitae et aut in excepturi omnis.", "698-4517-978-5956-2", false, 1, "circuit", "I'll calculate the auxiliary COM array, that should array the COM array!", 1 },
                    { 22, "hard drive", "3.jpeg", 1, "Reiciendis inventore ea molestiae nesciunt amet animi et omnis fuga. Necessitatibus minus veniam iusto. Et ratione architecto. Dicta debitis et illum inventore nobis nisi. Praesentium similique non. Iusto consequatur tenetur facilis facere voluptate officiis.", "907-5021-055-2223-9", false, 0, "card", "We need to back up the neural SMTP application!", 1 },
                    { 23, "circuit", "1.jpeg", 1, "Eveniet sit optio est aliquam sed nesciunt eligendi sunt. Vero tenetur delectus id veniam pariatur sequi est. Aut voluptatem eos totam excepturi aut id voluptate. Voluptatem laborum pariatur mollitia numquam nihil nesciunt expedita quia voluptatum. Error non quidem sed aut fuga eveniet veritatis asperiores et. Facilis reprehenderit molestiae ullam alias blanditiis voluptas.", "943-9624-999-4094-3", false, 1, "monitor", "I'll calculate the 1080p SAS circuit, that should circuit the SAS circuit!", 1 },
                    { 24, "sensor", "3.jpeg", 1, "Eaque aut deleniti eos. Consectetur laudantium reprehenderit. Quo ut in quia odio debitis non enim facilis. Autem et possimus facilis commodi.", "798-7160-748-1119-2", false, 0, "system", "The GB panel is down, copy the primary panel so we can copy the GB panel!", 1 },
                    { 25, "card", "3.jpeg", 1, "Et natus dolore a qui praesentium. Praesentium blanditiis error consequatur fugiat fugiat sit maiores consequatur placeat. Qui fugiat possimus ut omnis aut delectus provident consequatur eos. Consequatur dolores et ratione saepe eaque tempore quas. Quis nesciunt harum beatae quia vero non. Et sit quod.", "017-4837-762-6303-4", false, 0, "system", "We need to reboot the digital CSS program!", 1 },
                    { 26, "interface", "4.jpeg", 1, "Qui voluptatem ut voluptatem. Enim porro sunt expedita voluptates voluptatem quod. Ab dolorem perferendis accusamus. Praesentium dolor voluptate eos aperiam alias eaque architecto. Earum qui consequatur velit eos saepe rerum nisi deserunt laborum. Modi praesentium quam veritatis quis adipisci debitis possimus libero.", "172-5638-484-2837-1", false, 0, "card", "If we synthesize the circuit, we can get to the AI circuit through the bluetooth AI circuit!", 1 },
                    { 27, "capacitor", "2.jpeg", 1, "Aut ipsam voluptate earum distinctio sunt magni velit et qui. Quis sit minus maiores aspernatur qui itaque. Est sapiente aut quos. Eos architecto commodi est et excepturi eaque nesciunt soluta. Quos voluptates omnis id facere voluptas. Non sapiente qui odio libero aut ut qui omnis consequatur.", "418-7904-898-8283-2", false, 1, "microchip", "Use the multi-byte RSS pixel, then you can calculate the multi-byte pixel!", 1 },
                    { 28, "transmitter", "4.jpeg", 1, "Similique sit et ducimus excepturi sunt dolorem aut exercitationem vel. Hic velit sit dolor et est aperiam hic cupiditate voluptatum. Porro qui error. Adipisci perspiciatis aut quasi neque soluta fuga nulla consequatur. Corrupti non aliquam. Quas repellendus quia nam.", "609-5197-226-7548-6", false, 1, "protocol", "Try to generate the EXE program, maybe it will generate the optical program!", 1 },
                    { 29, "protocol", "1.jpeg", 1, "Nihil reprehenderit aut possimus id voluptatum. Id dignissimos autem sint reiciendis voluptas cumque eos sunt molestias. Odit itaque ad voluptatem occaecati. Rerum quia quia molestiae voluptatem itaque.", "680-9138-243-3751-8", false, 1, "program", "I'll program the mobile USB bus, that should bus the USB bus!", 1 },
                    { 30, "application", "5.jpeg", 1, "Enim ea eos sunt nihil. Labore sed cumque qui. Harum ea asperiores modi quisquam quia consequatur. Exercitationem sunt est est aut reiciendis. Doloremque et perspiciatis eius sit praesentium vero nulla. Maiores repudiandae possimus.", "859-5739-919-9818-5", false, 1, "hard drive", "Use the wireless THX array, then you can compress the wireless array!", 1 },
                    { 31, "bandwidth", "1.jpeg", 1, "Dolor iste nesciunt cupiditate ut facere autem et. Rerum autem molestiae laudantium veniam. Distinctio officia ducimus sint et delectus. Nam modi aut reprehenderit velit totam aut et.", "403-4132-404-2261-3", false, 1, "bus", "You can't override the bandwidth without navigating the neural COM bandwidth!", 1 },
                    { 32, "alarm", "2.jpeg", 1, "Labore velit voluptatem quae quibusdam atque quia. Consectetur culpa velit corrupti aut. Dolor facilis est animi sed. Labore illo ut veniam iste et fugiat fuga. Eos est reiciendis itaque quisquam natus. Mollitia adipisci dolorum laboriosam est.", "219-7748-015-4511-6", false, 0, "port", "Use the neural SMS bandwidth, then you can compress the neural bandwidth!", 1 },
                    { 33, "capacitor", "4.jpeg", 1, "Et ipsa impedit culpa est. Repudiandae deserunt deserunt aut. Quam dolores ut dignissimos fugiat eum. Aut et ut voluptas et voluptates autem ipsam deleniti.", "259-9556-760-5838-2", false, 0, "interface", "synthesizing the feed won't do anything, we need to copy the cross-platform XSS feed!", 1 },
                    { 34, "matrix", "5.jpeg", 1, "Eligendi sint quis est hic asperiores labore consequuntur. Est ut assumenda maiores labore dolor voluptas quo deleniti ut. Magni corporis quis vero et soluta est eius animi aliquid. Veniam quis veritatis dicta assumenda voluptas. Non quasi aspernatur quia et qui omnis. Odio magnam magni labore velit quia esse.", "753-5105-978-3339-2", false, 1, "protocol", "hacking the microchip won't do anything, we need to calculate the mobile PNG microchip!", 1 },
                    { 35, "sensor", "1.jpeg", 1, "Animi eaque ut qui esse perferendis. Ut perferendis sequi modi sunt nobis eum. Possimus occaecati rerum. Voluptas vel sequi quae deleniti praesentium fugiat omnis eveniet. Optio aut itaque exercitationem. Sed saepe aut dolorem nihil officiis modi consectetur.", "565-3215-656-8663-6", false, 0, "feed", "I'll input the primary USB transmitter, that should transmitter the USB transmitter!", 1 },
                    { 36, "application", "3.jpeg", 1, "Aspernatur sit tenetur. Molestiae et reprehenderit ut nihil blanditiis laborum hic necessitatibus laboriosam. Vel consequatur inventore.", "692-3949-895-7562-7", false, 1, "protocol", "We need to compress the back-end RAM capacitor!", 1 },
                    { 37, "microchip", "3.jpeg", 1, "Molestiae sapiente non quam voluptatem aperiam eligendi ipsa eum. Magnam assumenda nisi placeat. Similique doloribus ea. Reiciendis minus sit est aliquam. Enim occaecati inventore consequuntur rerum eveniet. Ut architecto facilis officia molestias assumenda.", "241-9252-936-3023-2", false, 0, "protocol", "compressing the firewall won't do anything, we need to synthesize the back-end RAM firewall!", 1 },
                    { 38, "program", "2.jpeg", 1, "Vel nostrum qui voluptatum repellendus nesciunt illum repudiandae. Omnis sit ut praesentium ratione ut tenetur assumenda. Deserunt placeat omnis asperiores asperiores excepturi ab aperiam.", "110-3242-829-7319-0", false, 1, "bus", "overriding the monitor won't do anything, we need to quantify the redundant JSON monitor!", 1 },
                    { 39, "card", "1.jpeg", 1, "Qui quia repudiandae aut aut ipsam sit et quis. Quis asperiores rem odit dolorem molestiae. Ab unde molestiae neque eos. Hic ut aut minima. Quae vel est porro iusto nihil dolorem non.", "568-5920-769-1651-2", false, 0, "capacitor", "Try to calculate the ADP bus, maybe it will calculate the redundant bus!", 1 },
                    { 40, "bandwidth", "5.jpeg", 1, "Ut veniam dolores iste quia inventore aut nisi. Sed dolorem corporis excepturi eveniet consequatur quis quasi. Praesentium fugiat in laborum sint vitae dolores et. Temporibus accusantium voluptatem praesentium dignissimos earum.", "068-8471-947-5252-8", false, 1, "system", "We need to index the primary SMTP interface!", 1 },
                    { 41, "alarm", "4.jpeg", 1, "Totam hic similique perferendis mollitia. Quidem doloribus quia atque. Officia necessitatibus consequatur voluptas fugiat qui. Corporis at quidem sed architecto ipsam ullam voluptate natus et. Et numquam est voluptates dicta quo voluptatibus. Laudantium dolore aut quis excepturi.", "486-8625-548-2170-6", false, 0, "firewall", "Use the optical XSS driver, then you can bypass the optical driver!", 1 },
                    { 42, "program", "3.jpeg", 1, "Exercitationem blanditiis et rerum possimus natus excepturi ut iure aspernatur. Esse pariatur non ut voluptatem harum excepturi. Et delectus quia similique quis magnam omnis. Occaecati aliquam nihil beatae non maiores voluptatem enim iste. Possimus iste voluptatem eaque qui esse nam autem. Deleniti perspiciatis error est accusamus sequi est nemo autem at.", "840-9680-319-8958-6", false, 0, "system", "Try to quantify the ADP matrix, maybe it will quantify the solid state matrix!", 1 },
                    { 43, "panel", "4.jpeg", 1, "Quidem quod iste corrupti impedit eos. Suscipit ad corrupti placeat aperiam ducimus. Autem et dolores.", "570-8711-887-6941-5", false, 1, "protocol", "synthesizing the protocol won't do anything, we need to bypass the wireless XSS protocol!", 1 },
                    { 44, "application", "4.jpeg", 1, "Corporis omnis a dicta voluptatibus molestiae nihil dolor aut odio. Maiores suscipit aut ipsum vel velit. Et earum aliquam necessitatibus voluptatem officiis quia incidunt id. Mollitia ad magnam quis. Molestiae corrupti ipsa esse sit ea temporibus aut.", "891-0003-467-6777-5", false, 1, "system", "Use the bluetooth SCSI matrix, then you can program the bluetooth matrix!", 1 },
                    { 45, "monitor", "5.jpeg", 1, "Amet ut aut. Ullam quod laborum minus laudantium. Autem non temporibus eos ex et repellendus quia cum. Qui tempore quia qui fugit id. Ea rerum nihil sunt ut. Excepturi quas animi autem fugit quis perferendis.", "331-6234-499-0724-9", false, 1, "system", "I'll hack the redundant FTP firewall, that should firewall the FTP firewall!", 1 },
                    { 46, "card", "4.jpeg", 1, "Quis occaecati totam odio. Neque aperiam soluta error non qui. Ipsam quaerat consectetur eum id. Dolor tenetur nulla ut facilis voluptatibus debitis ea est.", "903-2226-707-8940-6", false, 1, "monitor", "We need to synthesize the virtual CSS bandwidth!", 1 },
                    { 47, "interface", "1.jpeg", 1, "Amet eaque rerum. Voluptatem facilis doloribus dolores voluptatibus deleniti rerum vel incidunt est. Repellat et repellendus similique fuga dolorem ratione quia corporis architecto.", "207-4324-803-4308-6", false, 1, "program", "Try to index the PCI interface, maybe it will index the virtual interface!", 1 },
                    { 48, "application", "3.jpeg", 1, "Culpa ut qui et. Quae repellendus fugit culpa omnis nobis quasi. Pariatur nobis eaque ipsa cum repellat nemo id. Sunt vel et quasi nemo aut quis explicabo impedit. Deserunt voluptatem est sed. Consequatur voluptatem quo temporibus ut.", "244-7605-075-8524-6", false, 1, "firewall", "You can't program the hard drive without parsing the digital AI hard drive!", 1 },
                    { 49, "transmitter", "3.jpeg", 1, "Et consequatur neque pariatur consequatur minima occaecati ut aliquam harum. Autem quidem minus ducimus maiores dolores. Commodi in est et consequuntur in distinctio. Cum laudantium et. Dolores hic similique dicta.", "779-3702-416-1483-1", false, 1, "array", "Try to hack the JBOD panel, maybe it will hack the solid state panel!", 1 },
                    { 50, "array", "5.jpeg", 1, "Ut magni voluptatem ratione. Placeat deserunt autem dolorem blanditiis et distinctio et. Velit consequatur aspernatur est cum distinctio. Iste quis quia odio consequatur autem debitis. Rerum omnis qui.", "339-5082-096-4413-7", false, 0, "application", "If we input the feed, we can get to the USB feed through the bluetooth USB feed!", 1 },
                    { 51, "feed", "4.jpeg", 1, "Officia eius debitis. Quia sed cum tempora autem cum temporibus cupiditate. Distinctio voluptatibus in molestiae ducimus deleniti. Sit et et modi. Illum voluptatum numquam harum rerum excepturi. Officiis veniam et voluptatibus inventore ut.", "886-1933-874-3165-7", false, 0, "system", "We need to back up the redundant RAM system!", 1 },
                    { 52, "bandwidth", "1.jpeg", 1, "Sit aut suscipit recusandae iure magnam illum. Amet enim eligendi. Possimus dolorum quo.", "540-4901-814-9592-8", false, 0, "protocol", "We need to back up the haptic EXE circuit!", 1 },
                    { 53, "pixel", "4.jpeg", 1, "Amet sit sequi nihil. Voluptas sed facere. Et eius in quam molestias dolor est architecto autem quo. Unde consequuntur quo adipisci occaecati voluptate esse adipisci. Facilis et nesciunt sunt assumenda et voluptatem quaerat. Quo voluptatibus dolores reiciendis.", "884-9926-840-3003-9", false, 1, "driver", "If we connect the firewall, we can get to the RAM firewall through the online RAM firewall!", 1 },
                    { 54, "monitor", "2.jpeg", 1, "Id qui explicabo minus totam et in aut quaerat aperiam. Reprehenderit magnam praesentium nulla. Itaque incidunt blanditiis officia aut et eos illo commodi repellat. Consequuntur delectus voluptas eveniet exercitationem laboriosam itaque at provident.", "049-1265-793-2145-1", false, 0, "sensor", "You can't bypass the transmitter without bypassing the cross-platform SAS transmitter!", 1 },
                    { 55, "protocol", "1.jpeg", 1, "Nulla consequatur veritatis voluptatem et quia ratione aspernatur odio. Debitis illum quis itaque esse. Architecto dolorum totam provident repudiandae ut nihil assumenda.", "218-7716-198-8905-6", false, 1, "alarm", "navigating the circuit won't do anything, we need to input the online SSL circuit!", 1 },
                    { 56, "card", "5.jpeg", 1, "Cum dolorem et suscipit delectus. Quibusdam culpa deserunt est. Quae magnam repellendus ratione. Iste iste quasi. Deserunt et et. Magnam quia voluptas quia dicta optio id molestiae quas quos.", "210-7815-835-4348-4", false, 0, "application", "The AGP driver is down, bypass the cross-platform driver so we can bypass the AGP driver!", 1 },
                    { 57, "microchip", "2.jpeg", 1, "Placeat ea error ut. Temporibus consequatur aliquid eligendi et. Molestiae tempore aut aut temporibus explicabo voluptatem similique et sed. Dicta commodi consequatur et. Doloribus esse vitae. Adipisci quia voluptatem et asperiores laudantium cupiditate.", "938-8844-897-3292-0", false, 0, "driver", "We need to index the solid state ADP panel!", 1 },
                    { 58, "interface", "1.jpeg", 1, "Nam sequi deserunt incidunt aut consequuntur. Voluptas esse est maxime. Aspernatur quisquam cum architecto nam voluptatem sit quo sequi. Beatae est et facilis id temporibus rerum sit. Est assumenda optio numquam non.", "442-9700-990-1553-5", false, 0, "system", "I'll bypass the bluetooth HDD matrix, that should matrix the HDD matrix!", 1 },
                    { 59, "capacitor", "2.jpeg", 1, "Et ad aliquam. Quia nihil architecto quia. Nemo et voluptate molestiae illum quo consequatur corporis eius. Rerum exercitationem illum optio occaecati.", "832-4419-374-0150-3", false, 1, "array", "If we synthesize the interface, we can get to the SAS interface through the multi-byte SAS interface!", 1 },
                    { 60, "circuit", "1.jpeg", 1, "Libero magni iste hic ipsam ipsam atque voluptatibus quos voluptatum. Delectus quasi necessitatibus atque. Molestias quod qui ipsam officiis eligendi modi ipsum animi. Sed aut voluptatibus veniam atque. Voluptatum hic omnis architecto.", "695-3920-872-2967-3", false, 0, "driver", "The SCSI bus is down, reboot the 1080p bus so we can reboot the SCSI bus!", 1 },
                    { 61, "monitor", "2.jpeg", 1, "Nesciunt quam in sint id. Voluptates pariatur quasi est. Illum quae harum consequatur id perferendis natus eveniet quam. Consequatur et ut est eos assumenda. Voluptas voluptatem excepturi porro aliquam nam quia architecto. Ea et dignissimos pariatur.", "303-7108-514-5223-6", false, 1, "alarm", "If we index the interface, we can get to the PCI interface through the online PCI interface!", 1 },
                    { 62, "hard drive", "1.jpeg", 1, "Est sint beatae omnis sed est et dolorem qui in. Consequatur non et ducimus pariatur odit nesciunt. Unde nihil accusamus quis. Beatae iste et. Distinctio consequatur omnis quidem suscipit ducimus voluptatem est.", "263-6548-420-6235-3", false, 1, "port", "You can't hack the capacitor without generating the neural IB capacitor!", 1 },
                    { 63, "firewall", "5.jpeg", 1, "Blanditiis totam est nesciunt eius voluptate quis ipsam et consectetur. Sint laudantium veniam repellendus voluptatem tempora tempore. Quo ad repudiandae nulla et. Cum ea tenetur incidunt.", "171-6415-910-1423-5", false, 0, "pixel", "The THX system is down, parse the auxiliary system so we can parse the THX system!", 1 },
                    { 64, "card", "4.jpeg", 1, "Distinctio et consectetur. Est eius vitae. Veniam quia voluptates quibusdam quae aut dolores enim eveniet pariatur.", "254-0357-678-8585-5", false, 1, "bandwidth", "Try to override the AGP alarm, maybe it will override the cross-platform alarm!", 1 },
                    { 65, "sensor", "5.jpeg", 1, "Temporibus voluptates vel omnis rerum autem sapiente occaecati consequatur ratione. Repellendus dolorum aperiam aut. Eum repudiandae at. Deserunt eaque non repudiandae vero et architecto. Possimus sapiente sunt rem dolor autem sapiente harum. In dolor nisi reiciendis deserunt voluptates non est ipsum ullam.", "729-3211-217-4001-9", false, 1, "matrix", "You can't bypass the capacitor without navigating the optical SDD capacitor!", 1 },
                    { 66, "pixel", "1.jpeg", 1, "Earum soluta quaerat. Ut sit aut eos pariatur autem voluptatem. Illum dolores suscipit adipisci omnis maiores molestiae sapiente temporibus. Voluptatibus dolor cupiditate ea qui non et rerum.", "350-0659-517-6482-2", false, 1, "hard drive", "I'll program the open-source CSS array, that should array the CSS array!", 1 },
                    { 67, "sensor", "4.jpeg", 1, "Atque odit ipsa sint ipsum reprehenderit quaerat sapiente in dolorem. Provident reiciendis aliquam quo sunt. Quis magni quae quas rem qui laudantium ad rerum rerum. Perferendis corrupti libero tempora eligendi.", "342-3237-803-4083-2", false, 0, "sensor", "I'll input the digital SMTP application, that should application the SMTP application!", 1 },
                    { 68, "transmitter", "5.jpeg", 1, "Qui minus dolores alias molestiae. Et et quibusdam veniam veritatis. Molestias consequatur earum. Eos vitae nostrum fuga consectetur quaerat occaecati voluptatem nesciunt. Est eum impedit.", "268-1050-470-8846-1", false, 0, "protocol", "I'll compress the wireless RSS matrix, that should matrix the RSS matrix!", 1 },
                    { 69, "protocol", "4.jpeg", 1, "Illo quidem quia aut dolor eos quia sed. Quia quo illo occaecati iste facere soluta sapiente magni molestias. Qui voluptas odit veniam repellendus non doloremque. Tempora natus saepe inventore et. Aut eos dolore qui.", "965-6891-088-1880-5", false, 1, "hard drive", "The HTTP firewall is down, program the redundant firewall so we can program the HTTP firewall!", 1 },
                    { 70, "transmitter", "5.jpeg", 1, "Ut quasi iusto velit minima delectus voluptas molestiae voluptatem eos. Est tempore est. Minima repellendus qui maiores iure similique expedita.", "739-7732-539-3022-0", false, 1, "microchip", "Use the bluetooth FTP pixel, then you can back up the bluetooth pixel!", 1 },
                    { 71, "sensor", "1.jpeg", 1, "Illum dolor dolore ab quos odit eaque. Molestiae accusamus iure iure voluptate expedita quis quia amet. Modi sunt rem nulla quia quas officia at.", "959-8244-329-8714-7", false, 1, "matrix", "Use the redundant XSS array, then you can quantify the redundant array!", 1 },
                    { 72, "firewall", "3.jpeg", 1, "Error aut temporibus dolore aliquam doloribus vitae harum amet eaque. Cumque minus at molestiae. Laboriosam debitis officiis vero voluptatem. Dolores perspiciatis consectetur.", "012-7134-867-5505-8", false, 1, "program", "We need to hack the cross-platform PCI sensor!", 1 },
                    { 73, "interface", "3.jpeg", 1, "Voluptatibus accusamus reiciendis consequuntur. Enim vel numquam quo earum tempore adipisci ipsa. Enim unde magni natus. Corporis et et quia quia voluptatum pariatur adipisci vitae. Ipsum explicabo exercitationem magnam magni impedit.", "637-6080-425-8436-5", false, 0, "array", "If we calculate the circuit, we can get to the GB circuit through the optical GB circuit!", 1 },
                    { 74, "sensor", "2.jpeg", 1, "Et porro porro. Ut qui atque repellat aperiam minima consequatur vel. Ullam officia non repudiandae maxime sapiente quaerat quaerat consectetur. Atque dolor ut tenetur non porro adipisci porro ipsum commodi. Consequatur praesentium rerum repudiandae quia deleniti.", "380-4518-191-0325-0", false, 1, "driver", "Try to generate the THX card, maybe it will generate the auxiliary card!", 1 },
                    { 75, "feed", "1.jpeg", 1, "Ea et et dolorem ea enim et voluptatem quia. Eaque autem ipsa ea quisquam sit in. Officia tenetur aut aut deleniti ab similique. Mollitia labore delectus sunt.", "517-7999-240-6080-2", false, 1, "capacitor", "You can't input the pixel without hacking the haptic EXE pixel!", 1 },
                    { 76, "firewall", "2.jpeg", 1, "Sapiente vero ullam et accusantium aspernatur. Repudiandae exercitationem error nostrum. Cumque harum reprehenderit. Quas sapiente dolorem expedita distinctio non sit nam itaque. Et suscipit aliquid. Quidem minima et laboriosam exercitationem aut qui esse et.", "372-8837-410-8174-8", false, 0, "card", "Use the neural SDD bandwidth, then you can connect the neural bandwidth!", 1 },
                    { 77, "array", "3.jpeg", 1, "Similique eaque delectus dignissimos nostrum sint consectetur adipisci omnis sit. Dolorem exercitationem voluptatum. Illum molestiae qui dolores amet libero. Repellendus nulla placeat. Ipsum voluptatem ut laboriosam dolorem voluptate reprehenderit. Est nihil fugit.", "044-5628-478-1481-5", false, 1, "microchip", "We need to reboot the online HTTP sensor!", 1 },
                    { 78, "circuit", "5.jpeg", 1, "Deleniti eos alias dignissimos in quo aut provident. Dolorem enim rerum ut consectetur nobis quae alias ea. Excepturi et quia rerum recusandae amet. Voluptatem et aut ab.", "065-4094-052-6183-9", false, 1, "sensor", "Try to synthesize the USB bus, maybe it will synthesize the 1080p bus!", 1 },
                    { 79, "driver", "1.jpeg", 1, "Porro voluptatem at vel eveniet. Aperiam deserunt quo est vel. Repellendus magnam dolorem debitis inventore suscipit perferendis.", "153-1347-853-1902-2", false, 1, "microchip", "I'll parse the optical RAM program, that should program the RAM program!", 1 },
                    { 80, "system", "2.jpeg", 1, "Dolor quo inventore ad est a rerum aliquam ut. Totam quo dolor sunt soluta. Omnis mollitia voluptas.", "661-9574-393-9966-9", false, 1, "system", "If we calculate the bus, we can get to the SQL bus through the bluetooth SQL bus!", 1 },
                    { 81, "capacitor", "3.jpeg", 1, "Consequatur iure laudantium id quis aut cum alias molestiae accusamus. Provident officia quam. Aliquid provident animi voluptas animi reprehenderit qui corporis. Tenetur enim accusamus delectus delectus ab et dolores animi suscipit. Laboriosam et qui pariatur sit atque rem velit voluptas.", "466-9035-117-2413-9", false, 0, "system", "I'll copy the cross-platform ADP system, that should system the ADP system!", 1 },
                    { 82, "interface", "3.jpeg", 1, "Asperiores sed cumque non illo qui magni est. Ad sint quia. Consequatur voluptatem quibusdam recusandae. Asperiores non voluptas reiciendis minima.", "862-8300-609-6247-4", false, 0, "alarm", "Try to synthesize the JBOD array, maybe it will synthesize the auxiliary array!", 1 },
                    { 83, "interface", "4.jpeg", 1, "Aliquam est ullam modi. Aut qui aspernatur pariatur dolores. Aperiam repellat ad doloremque distinctio neque. Consequatur accusamus commodi sit nisi iste accusamus temporibus. Ex itaque temporibus at iure dolor earum est officiis sequi. Accusantium numquam tempore aspernatur.", "686-2264-304-6504-8", false, 1, "sensor", "We need to calculate the auxiliary SAS pixel!", 1 },
                    { 84, "driver", "2.jpeg", 1, "Quia commodi in dolorum quasi praesentium. Fuga dolorem quia error quod at voluptas neque sequi consequatur. Ipsum dolor et rerum voluptatem sint molestiae mollitia. Consectetur porro ipsum aut eveniet minus tempora qui unde. Voluptatem et non dignissimos saepe voluptas nesciunt.", "428-2690-461-9625-7", false, 0, "firewall", "You can't transmit the bus without bypassing the primary ADP bus!", 1 },
                    { 85, "matrix", "2.jpeg", 1, "Pariatur ab voluptate expedita qui fuga maxime ea non. Et quis sint voluptas ad aliquid iure. Omnis ab excepturi voluptatem dolor. Explicabo corrupti assumenda architecto voluptatum quis sit maiores quasi.", "761-0264-903-7754-0", false, 0, "monitor", "Use the multi-byte XSS sensor, then you can calculate the multi-byte sensor!", 1 },
                    { 86, "hard drive", "4.jpeg", 1, "Sequi error quia voluptatem. Accusantium quod laudantium officiis sint ratione provident culpa. Iusto delectus aliquam aut reiciendis. Animi dolorem et neque minima sint accusantium. Eius ut autem. Et ut ducimus architecto minus eius.", "394-2375-241-6453-6", false, 0, "port", "Use the mobile SCSI interface, then you can quantify the mobile interface!", 1 },
                    { 87, "pixel", "3.jpeg", 1, "Adipisci harum doloribus. Quas dolorum quod sint voluptatem non aliquam. Omnis veritatis et consequatur vel reprehenderit dicta. Sed harum maiores corrupti voluptatem iure ratione. Dolores blanditiis necessitatibus soluta eaque et.", "182-0961-750-3056-3", false, 0, "monitor", "We need to parse the solid state SQL port!", 1 },
                    { 88, "matrix", "4.jpeg", 1, "Ipsa et facilis. Vel sed tenetur facere facilis vitae qui saepe. Id enim aliquid quas repellendus vel ea qui. Pariatur dicta ut dicta vel ab molestiae enim quis voluptatem. Ut consequatur suscipit.", "074-7823-031-9024-4", false, 1, "system", "Use the auxiliary XML card, then you can quantify the auxiliary card!", 1 },
                    { 89, "program", "1.jpeg", 1, "Quaerat eos ipsa voluptatem molestias error est recusandae enim quia. Magnam et quis. Et dicta modi. Quas iste quam sit quasi. Nesciunt ipsum quia sed quo.", "017-3003-286-6914-4", false, 0, "sensor", "Try to connect the SMS driver, maybe it will connect the bluetooth driver!", 1 },
                    { 90, "port", "2.jpeg", 1, "Rem reprehenderit doloremque itaque culpa dolore. Cupiditate sunt iusto qui facilis perferendis qui odio voluptates. Eos quia dolorem esse vero error animi quam quis. Labore quia sed qui omnis eos sunt sit voluptas laudantium. Nihil est ut.", "919-9830-088-5337-0", false, 0, "port", "The USB sensor is down, copy the solid state sensor so we can copy the USB sensor!", 1 },
                    { 91, "program", "4.jpeg", 1, "Numquam quod rerum et voluptatem. Odit nemo est. Debitis voluptates voluptate nostrum at mollitia.", "355-6766-979-6559-8", false, 0, "circuit", "overriding the capacitor won't do anything, we need to navigate the redundant COM capacitor!", 1 },
                    { 92, "card", "2.jpeg", 1, "Eligendi est itaque magni. Earum sit dolor voluptates molestiae iure incidunt. Ullam voluptates ea.", "654-8679-523-8236-5", false, 0, "capacitor", "Try to connect the IB firewall, maybe it will connect the redundant firewall!", 1 },
                    { 93, "interface", "1.jpeg", 1, "Dolores explicabo harum libero qui doloremque est aut omnis odio. Voluptas numquam sed provident laudantium consequuntur autem repudiandae. Dolores eos harum quod repudiandae aspernatur.", "139-5873-806-7182-3", false, 0, "driver", "If we compress the card, we can get to the PNG card through the virtual PNG card!", 1 },
                    { 94, "matrix", "1.jpeg", 1, "Enim assumenda at minima in laboriosam aut totam non. Eos deleniti aut odit. Quia culpa sit ut distinctio non perferendis enim sunt distinctio. In dolorem sed aut et cumque. Voluptates perspiciatis aut qui. Sunt dicta sed deleniti asperiores ut nobis.", "517-6336-605-9948-7", false, 0, "program", "I'll transmit the solid state RAM circuit, that should circuit the RAM circuit!", 1 },
                    { 95, "program", "5.jpeg", 1, "Quos dolorem libero aut quaerat perspiciatis. Nam magni qui omnis sed deserunt dicta et laboriosam. Iusto non ipsam beatae recusandae ad.", "783-6610-231-7107-3", false, 0, "bus", "I'll parse the virtual SSL bandwidth, that should bandwidth the SSL bandwidth!", 1 },
                    { 96, "circuit", "5.jpeg", 1, "Sed ut quaerat soluta iure officiis. Voluptatibus ducimus voluptatem enim et. Id amet delectus dolorem nostrum asperiores quo sit ut omnis. Quae ut mollitia molestiae. Odio illum repudiandae magnam rerum non ea fugit. Qui neque voluptates iste sunt sunt ab est.", "857-4833-040-9985-0", false, 0, "alarm", "I'll reboot the solid state RSS bus, that should bus the RSS bus!", 1 },
                    { 97, "array", "5.jpeg", 1, "Maiores fugit sapiente atque voluptatem. Provident sint aut accusamus praesentium quia consequatur. Reiciendis quae necessitatibus similique est possimus. Suscipit nisi ipsa quos. Commodi nihil repellendus magnam blanditiis corporis sed. Veritatis non similique modi repellat mollitia id mollitia.", "144-2518-751-5085-3", false, 0, "hard drive", "Try to program the GB system, maybe it will program the online system!", 1 },
                    { 98, "transmitter", "5.jpeg", 1, "Maiores sed eum assumenda laborum odio officia maiores. Minus in a nesciunt sunt aut deserunt. Et atque quam voluptate sit enim perspiciatis a quia eius. Nisi qui unde suscipit. Ut exercitationem praesentium sit repellat. Eos repellat fuga et ab.", "909-0520-545-5139-0", false, 0, "capacitor", "I'll override the virtual AGP panel, that should panel the AGP panel!", 1 },
                    { 99, "interface", "4.jpeg", 1, "Quos eos quo. Iste soluta temporibus ut. At expedita nesciunt optio explicabo iusto quidem laboriosam quos. Vel qui pariatur adipisci. Aut quam voluptatem aliquam earum expedita earum harum.", "633-7907-501-9458-5", false, 0, "bandwidth", "Try to back up the SDD protocol, maybe it will back up the open-source protocol!", 1 },
                    { 100, "hard drive", "1.jpeg", 1, "Sint aut fuga aut deserunt ex aut. Adipisci magni commodi voluptatem quo quas optio ipsa asperiores. Provident quasi repellat doloremque rerum omnis distinctio. Similique rerum ut aut omnis sit rerum ipsa praesentium. Dolore eum rerum sunt quisquam. Corporis ut itaque sint quod doloribus eaque est voluptas eaque.", "059-5780-862-8288-8", false, 0, "sensor", "If we navigate the interface, we can get to the PCI interface through the open-source PCI interface!", 1 },
                    { 101, "sensor", "3.jpeg", 1, "Et eos id beatae sint in harum. Aut voluptatem quia velit rerum odio rem quas. Sint voluptatum incidunt quae dignissimos inventore. Culpa odio aliquid officia pariatur voluptate quo. Possimus quidem nihil in.", "905-9600-332-7566-1", false, 0, "program", "If we synthesize the port, we can get to the XSS port through the digital XSS port!", 1 },
                    { 102, "card", "1.jpeg", 1, "Ut accusantium aliquid ut voluptas eos nesciunt. Ut dolores voluptatum. Possimus et ut alias illo facilis sint quibusdam provident.", "599-8255-557-3641-6", false, 1, "system", "The USB panel is down, navigate the digital panel so we can navigate the USB panel!", 1 },
                    { 103, "panel", "1.jpeg", 1, "Aut corrupti aut non. Est tempora explicabo quaerat doloribus sint. Consectetur neque iure eius natus earum quasi quod ullam reiciendis. Et nesciunt omnis neque qui sed dolore. Delectus illo unde aperiam maxime et qui quas recusandae harum. Quod sed tenetur voluptas illum omnis voluptatem perferendis est pariatur.", "266-2795-989-8604-2", false, 1, "sensor", "You can't back up the bandwidth without navigating the auxiliary IB bandwidth!", 1 },
                    { 104, "driver", "5.jpeg", 1, "Voluptas minus nemo. Molestiae error officiis est sapiente et eius odio. Laudantium et suscipit.", "768-1938-261-0764-7", false, 0, "transmitter", "We need to reboot the mobile RAM monitor!", 1 },
                    { 105, "driver", "2.jpeg", 1, "Fugit corrupti enim blanditiis vitae voluptates officia. Aut aliquid a maiores reiciendis illo qui. Ea quo quis qui qui. Corporis suscipit dolorem laboriosam sequi suscipit accusamus.", "341-0168-053-7967-7", false, 0, "microchip", "The IB array is down, input the open-source array so we can input the IB array!", 1 },
                    { 106, "matrix", "1.jpeg", 1, "Libero qui atque enim. Quam deserunt ratione voluptatem sed sunt incidunt. Voluptatem ut laborum pariatur. Quasi quasi minus occaecati in fuga fugiat necessitatibus eveniet maxime. Voluptate voluptatem ipsum.", "051-1832-628-0179-9", false, 0, "panel", "We need to synthesize the primary EXE bandwidth!", 1 },
                    { 107, "feed", "4.jpeg", 1, "Nisi voluptates vel. Doloremque dolor voluptatibus recusandae quis deleniti. Quam tempore molestiae officiis quisquam nostrum.", "065-3787-253-2456-7", false, 0, "driver", "I'll parse the auxiliary XML feed, that should feed the XML feed!", 1 },
                    { 108, "pixel", "4.jpeg", 1, "Tenetur omnis labore sint quibusdam natus sequi. Corrupti laborum consequatur. Sit nulla doloribus. Occaecati atque unde illum consectetur est saepe explicabo.", "264-0370-981-8417-3", false, 1, "bus", "Try to input the AGP microchip, maybe it will input the primary microchip!", 1 },
                    { 109, "bandwidth", "4.jpeg", 1, "Rerum quia eaque rerum aut quia. Quia officia voluptatem quas soluta voluptatibus dolore. Officiis sit accusantium. Fugiat vero eum sit et. Veritatis amet minima ut.", "607-4867-625-6774-6", false, 0, "application", "We need to connect the bluetooth COM port!", 1 },
                    { 110, "matrix", "4.jpeg", 1, "Nemo corporis quia. Quia labore eos consequatur doloribus iusto aspernatur est error. Temporibus porro eaque voluptatum quidem qui molestiae deleniti. Sit nam error sit. Quia maxime earum impedit deleniti natus. Exercitationem aut perspiciatis sit eveniet facere nulla et nam debitis.", "846-5208-724-4098-3", false, 1, "bandwidth", "copying the monitor won't do anything, we need to input the digital GB monitor!", 1 },
                    { 111, "firewall", "2.jpeg", 1, "Eum maiores aliquid possimus enim atque possimus ut. Vel vel corrupti assumenda ut. Quas et in.", "847-5492-679-7946-4", false, 1, "panel", "You can't calculate the bandwidth without indexing the redundant RAM bandwidth!", 1 },
                    { 112, "matrix", "2.jpeg", 1, "Sapiente eius autem veniam. Ut sequi est vero adipisci. Non adipisci et itaque iusto in suscipit tempora. Recusandae exercitationem dolore velit occaecati quo. Dolores commodi repellat quis quidem aut adipisci. Vitae reiciendis molestias aut error tempora consectetur temporibus nulla tempore.", "355-7465-205-2757-1", false, 1, "interface", "We need to quantify the back-end IB circuit!", 1 },
                    { 113, "bus", "3.jpeg", 1, "Porro non laudantium est quo aut eius laborum odio. Dicta hic et corrupti. Aut corporis sed saepe occaecati. Et aut expedita sapiente. Deleniti ipsa qui dolores aut quasi ducimus iure.", "159-9183-915-6208-5", false, 1, "matrix", "Use the open-source JBOD bandwidth, then you can input the open-source bandwidth!", 1 },
                    { 114, "driver", "3.jpeg", 1, "Aut sint odio animi et ea placeat. Voluptas in ad sit eveniet. Maxime sunt voluptates cum mollitia eius nisi iusto est. Enim non perspiciatis soluta illo vel sed voluptatem et architecto. Consequatur ut corrupti sit doloribus consectetur et.", "132-4757-336-3097-3", false, 1, "bandwidth", "If we override the system, we can get to the AI system through the redundant AI system!", 1 },
                    { 115, "circuit", "2.jpeg", 1, "Aut et deleniti sed. Unde voluptatem ducimus provident magni velit architecto voluptatem. Qui numquam qui quae.", "493-6062-391-6246-2", false, 1, "sensor", "We need to transmit the digital COM microchip!", 1 },
                    { 116, "circuit", "3.jpeg", 1, "Amet et sint et et eius harum nobis consequatur. Quaerat et non doloremque qui. Eligendi porro natus exercitationem libero. Voluptatum quae incidunt itaque sunt. Quia ducimus sunt fugiat libero iure.", "621-1105-632-5548-7", false, 0, "hard drive", "You can't bypass the microchip without overriding the redundant RAM microchip!", 1 },
                    { 117, "application", "5.jpeg", 1, "Ipsum similique eum illo molestias ut beatae quaerat consequuntur laborum. Dolorum quos exercitationem. Est voluptatem sunt. Quae quia eius enim est.", "489-3575-563-5073-4", false, 0, "application", "parsing the card won't do anything, we need to override the redundant SCSI card!", 1 },
                    { 118, "system", "2.jpeg", 1, "Maiores provident dolores suscipit minima id veniam atque possimus pariatur. Sed fugiat inventore non ipsa. Aperiam ipsa necessitatibus voluptas inventore molestiae magni. Facere vel et et aut omnis ratione sit vel optio.", "538-4638-971-7391-5", false, 0, "sensor", "The CSS driver is down, copy the optical driver so we can copy the CSS driver!", 1 },
                    { 119, "application", "2.jpeg", 1, "Architecto accusamus id eum nemo perspiciatis veritatis. Consequuntur cupiditate natus esse facere. Nostrum quo consequuntur et fugit. A est tempore ea autem est animi.", "565-4146-327-1184-7", false, 1, "panel", "We need to navigate the mobile PCI bus!", 1 },
                    { 120, "interface", "1.jpeg", 1, "Odit quo impedit fuga. Non corporis consequuntur debitis. Minima quia ratione dolore ut ullam qui exercitationem amet rerum. Reprehenderit ut esse expedita vero aut.", "653-9762-500-0644-3", false, 0, "feed", "The SAS sensor is down, program the redundant sensor so we can program the SAS sensor!", 1 },
                    { 121, "monitor", "1.jpeg", 1, "Est vel nihil. Voluptas est nihil dignissimos at ab ea. Aut omnis quia qui ratione ut. Reiciendis omnis repellendus ut velit consequatur. Placeat qui repellat sapiente eveniet minima illo.", "145-5584-779-4819-1", false, 1, "circuit", "programming the card won't do anything, we need to parse the cross-platform GB card!", 1 },
                    { 122, "application", "1.jpeg", 1, "Placeat accusamus unde unde. Iure et qui ab omnis minus modi aut et porro. Modi dolor officia veritatis id eligendi quam. Quod aliquid sapiente veritatis fuga. Enim reprehenderit vel quo explicabo eveniet ut et natus qui. Qui voluptas ad.", "341-1968-732-2604-0", false, 1, "pixel", "Use the virtual SSL feed, then you can quantify the virtual feed!", 1 },
                    { 123, "protocol", "4.jpeg", 1, "Deleniti dolore illum quisquam velit consequatur dolores iusto odio. Est molestias non expedita. Non nihil et ut. Delectus nam impedit ipsum recusandae rerum porro consequatur eos. Fugit minus et ab.", "546-8992-046-9014-1", false, 1, "system", "You can't reboot the transmitter without transmitting the virtual SMTP transmitter!", 1 },
                    { 124, "alarm", "1.jpeg", 1, "Eius iste nihil qui earum. Et et quae. Porro ut placeat et nobis numquam. A autem et tenetur eaque voluptas autem dolore. Fugit laboriosam nam. Qui aut libero.", "386-3067-877-9015-8", false, 0, "system", "I'll generate the 1080p SMTP port, that should port the SMTP port!", 1 },
                    { 125, "bandwidth", "5.jpeg", 1, "Molestias nam nam. Architecto corrupti expedita et. Vitae nam officia autem. Omnis enim tempora quia harum repellendus amet. Rerum quis commodi est sit blanditiis quae quis.", "185-2981-901-1415-1", false, 0, "protocol", "We need to connect the open-source AI feed!", 1 },
                    { 126, "interface", "4.jpeg", 1, "Molestias quae eum tempora. Sit ut similique. Quaerat nam aperiam aut debitis non velit quos sunt dolor. Perferendis ipsam aut. Facilis veritatis sed accusamus qui dolor sint.", "130-9947-803-1246-0", false, 0, "array", "The XSS feed is down, bypass the back-end feed so we can bypass the XSS feed!", 1 },
                    { 127, "port", "3.jpeg", 1, "Quibusdam assumenda autem temporibus quia esse. Debitis ut iure saepe et. Veritatis neque voluptatem.", "943-7629-706-5456-6", false, 0, "matrix", "You can't calculate the card without connecting the haptic JSON card!", 1 },
                    { 128, "card", "4.jpeg", 1, "Nulla nisi incidunt qui nemo quia nemo possimus. Nemo eius quod perferendis quia neque quae itaque. Repellat est harum sunt pariatur numquam distinctio. Voluptatem provident officia qui similique tempora aut beatae itaque.", "414-9778-987-1243-0", false, 0, "microchip", "If we program the monitor, we can get to the EXE monitor through the auxiliary EXE monitor!", 1 },
                    { 129, "driver", "1.jpeg", 1, "Molestiae aliquam omnis eum distinctio odio quia minus molestiae. Neque optio est laborum ab. Molestiae eos quae omnis.", "369-7007-861-2257-4", false, 1, "transmitter", "The SDD interface is down, synthesize the solid state interface so we can synthesize the SDD interface!", 1 },
                    { 130, "array", "1.jpeg", 1, "Quo sequi tempore dolorem molestias quia. Consectetur optio ullam ut exercitationem maiores voluptatem ipsum molestiae sequi. Dolorem modi est repudiandae a repudiandae. Et eligendi maiores alias. Aspernatur quis minima et accusamus officiis sit saepe sequi. Ut expedita consectetur consectetur occaecati non.", "737-1350-358-9698-3", false, 1, "application", "calculating the port won't do anything, we need to parse the virtual SCSI port!", 1 },
                    { 131, "alarm", "1.jpeg", 1, "Voluptate quia laboriosam aperiam fuga. Aperiam nostrum expedita. A vitae placeat. Incidunt blanditiis nihil asperiores ea ullam temporibus suscipit nihil voluptate. Eos beatae tenetur at.", "618-7358-771-3307-5", false, 0, "card", "The SMS array is down, copy the auxiliary array so we can copy the SMS array!", 1 },
                    { 132, "firewall", "3.jpeg", 1, "Ut repellendus minima rerum. Temporibus ut sit exercitationem est. Quibusdam nam porro omnis. Sed qui voluptatum est excepturi eos explicabo amet. Velit dolore rem. Quia aperiam modi culpa voluptas rerum ut error veniam et.", "808-6974-489-3165-7", false, 1, "protocol", "You can't back up the transmitter without parsing the solid state TCP transmitter!", 1 },
                    { 133, "transmitter", "3.jpeg", 1, "Sapiente quasi itaque eos hic. A eligendi velit explicabo similique dignissimos ut aut. Dolores neque quo omnis ad beatae et. Rerum optio dignissimos sed eligendi ex.", "016-4396-110-7335-8", false, 0, "port", "Use the optical PCI system, then you can connect the optical system!", 1 },
                    { 134, "card", "5.jpeg", 1, "Qui impedit voluptas itaque sed. Ipsa magnam voluptate. Ut atque tempore eligendi aperiam. Distinctio consequatur unde et voluptatem quae earum veniam sit. Debitis architecto aliquam ut ipsum voluptas in dolorem.", "193-8401-350-5716-6", false, 1, "hard drive", "You can't input the transmitter without connecting the digital SAS transmitter!", 1 },
                    { 135, "circuit", "5.jpeg", 1, "Earum quibusdam blanditiis. Amet ea maiores vitae cum architecto. Saepe est consequatur dolore nulla et ipsam.", "353-5365-803-7132-2", false, 0, "panel", "The XML bus is down, override the multi-byte bus so we can override the XML bus!", 1 },
                    { 136, "alarm", "2.jpeg", 1, "Provident placeat fuga. Animi veniam quasi omnis. Aliquam nesciunt harum aut ut nihil quia. Nostrum mollitia quis et velit voluptatibus error culpa consequatur aut. Et magni molestias omnis iusto aliquid fugit aliquam voluptatum asperiores. Est deserunt consequatur quam expedita id ullam et.", "628-8328-141-4943-1", false, 1, "hard drive", "If we generate the capacitor, we can get to the SMTP capacitor through the haptic SMTP capacitor!", 1 },
                    { 137, "system", "2.jpeg", 1, "Eum pariatur et voluptatibus. Et sunt aut rerum. Sit quam earum quis aut earum in voluptate. Non error laboriosam nemo quo rerum quod veniam temporibus dolor.", "357-8600-303-1598-2", false, 1, "application", "We need to compress the multi-byte SQL matrix!", 1 },
                    { 138, "panel", "4.jpeg", 1, "Et maiores qui rerum consequuntur officia. Harum voluptatum consequatur natus cupiditate labore. Doloremque harum et animi soluta enim aspernatur dolorem cum. Sapiente vitae velit ullam praesentium voluptatem pariatur. Voluptas deserunt possimus repudiandae.", "909-6414-456-6581-2", false, 1, "pixel", "The FTP monitor is down, program the haptic monitor so we can program the FTP monitor!", 1 },
                    { 139, "feed", "3.jpeg", 1, "Voluptatem est repellendus et quos fugit quis. Qui eum iste delectus. Esse eveniet et eum quibusdam officia nulla. Culpa sit veniam aut quia sit labore ad dolorum debitis. Possimus nam nostrum officia labore.", "982-2195-932-9240-0", false, 0, "monitor", "I'll input the virtual XML card, that should card the XML card!", 1 },
                    { 140, "port", "2.jpeg", 1, "Maxime a suscipit quae sapiente laudantium quam qui. Reiciendis cum aut quia enim. Reprehenderit molestiae facere nam aperiam aliquam nemo.", "776-4167-926-5547-1", false, 0, "bus", "Use the multi-byte PNG panel, then you can copy the multi-byte panel!", 1 },
                    { 141, "pixel", "1.jpeg", 1, "Nihil rerum dolor. Voluptatem porro quod dolores. Nihil sit velit repellendus in vel voluptas quisquam quas. Blanditiis et nesciunt pariatur. Quia qui eos nihil accusantium. Numquam ut reprehenderit et consectetur nisi dolor mollitia incidunt.", "917-2504-321-2948-1", false, 0, "array", "You can't calculate the transmitter without quantifying the online SSL transmitter!", 1 },
                    { 142, "bandwidth", "1.jpeg", 1, "Harum enim similique inventore voluptatem ea. Non eveniet odio et sit. Recusandae deleniti eveniet soluta ut ducimus nihil ducimus aut. Illo esse qui doloremque non. Dignissimos est quae laboriosam.", "268-1629-488-6377-8", false, 0, "bus", "Try to compress the XML feed, maybe it will compress the optical feed!", 1 },
                    { 143, "sensor", "2.jpeg", 1, "Aut eos dolorem aspernatur fugiat quis. Dolor quia quis ut nemo sit et blanditiis illo. Harum ducimus fuga sit eos quibusdam. Cumque modi molestiae pariatur aut minus quia quae.", "105-6732-762-7233-5", false, 0, "interface", "The PCI protocol is down, back up the auxiliary protocol so we can back up the PCI protocol!", 1 },
                    { 144, "bandwidth", "1.jpeg", 1, "At voluptatem recusandae. Unde dolorem similique. Recusandae reiciendis consequatur molestias molestiae. Dolorum quis id vel et amet voluptas et.", "415-3909-403-7184-2", false, 1, "matrix", "You can't generate the alarm without overriding the optical SQL alarm!", 1 },
                    { 145, "feed", "3.jpeg", 1, "Atque sequi voluptate quis eum quia. Est vel quia beatae id consectetur dolor quo incidunt. Pariatur est non consequuntur voluptas iure voluptatibus. Tempora corrupti quis. Eveniet eligendi temporibus atque aliquam. Totam aut error modi incidunt commodi inventore eum quia.", "943-8339-013-7137-3", false, 1, "sensor", "You can't synthesize the bus without transmitting the bluetooth GB bus!", 1 },
                    { 146, "array", "5.jpeg", 1, "Voluptatem suscipit hic laboriosam nostrum. Porro delectus adipisci. Consequatur voluptas in enim qui et labore. Nemo voluptatibus accusamus assumenda qui corrupti architecto dolor dolores. Adipisci consequatur blanditiis ipsa.", "699-1220-750-8064-9", false, 0, "circuit", "I'll compress the multi-byte RAM program, that should program the RAM program!", 1 },
                    { 147, "circuit", "5.jpeg", 1, "Accusamus temporibus eveniet sit qui numquam incidunt tempora. Esse harum sed aut quo non assumenda tempora. Rerum in laudantium. Velit nam id sed officia.", "757-1083-622-5879-5", false, 1, "bandwidth", "If we back up the protocol, we can get to the SMTP protocol through the digital SMTP protocol!", 1 },
                    { 148, "panel", "5.jpeg", 1, "Itaque sunt qui velit. Deleniti placeat laudantium nisi ad natus autem voluptas quibusdam nostrum. Et deserunt dignissimos optio voluptas soluta labore explicabo. Laborum quibusdam qui cum magni ducimus nam.", "606-7225-063-5761-9", false, 0, "interface", "You can't quantify the firewall without copying the wireless IB firewall!", 1 },
                    { 149, "panel", "4.jpeg", 1, "Tempore ex hic quia aut molestiae. Necessitatibus accusantium et in. Autem unde at aut ut voluptas. Nihil inventore voluptate. Voluptatum et libero officia eveniet. Quia enim nam culpa.", "272-2893-650-7034-4", false, 1, "application", "The JBOD panel is down, index the auxiliary panel so we can index the JBOD panel!", 1 },
                    { 150, "interface", "3.jpeg", 1, "Nihil reiciendis ratione. Sit occaecati rerum possimus repellendus. Ut ab vel. Et porro necessitatibus ab placeat eligendi ut sed.", "149-9861-888-8926-7", false, 0, "monitor", "You can't calculate the circuit without overriding the open-source SMS circuit!", 1 },
                    { 151, "protocol", "5.jpeg", 1, "Perferendis veritatis occaecati fugit eos cum. Id ullam rem reprehenderit officiis adipisci. Est ullam dolore. Corporis consequuntur dolor itaque repellat dolor perspiciatis aut rem modi. Explicabo sed temporibus autem blanditiis sequi et. Voluptas et sint enim magni reiciendis natus placeat.", "289-6722-940-5500-8", false, 1, "sensor", "If we compress the microchip, we can get to the USB microchip through the redundant USB microchip!", 1 },
                    { 152, "alarm", "1.jpeg", 1, "Harum et eligendi occaecati et nulla molestiae. Eveniet et id molestiae iste omnis itaque unde. Aut est beatae quasi ducimus unde. Molestiae nemo quos ullam voluptas odit laborum. Possimus sint voluptatem et cupiditate est magni nam odio. Aut in deleniti et et.", "209-0459-950-8541-6", false, 1, "circuit", "quantifying the transmitter won't do anything, we need to reboot the cross-platform SCSI transmitter!", 1 },
                    { 153, "card", "2.jpeg", 1, "Molestiae dignissimos dolor quisquam veniam doloremque esse in hic. Ea consequatur cupiditate. Voluptatem minima unde numquam sed provident ab ut. Placeat rem magnam rerum et ipsum ut consequatur voluptatem. Ad error expedita rerum est asperiores.", "139-4309-696-0483-3", false, 0, "panel", "You can't generate the capacitor without hacking the neural SAS capacitor!", 1 },
                    { 154, "application", "3.jpeg", 1, "Nisi beatae eius quas. Eius occaecati dolores quo fugit necessitatibus nesciunt sit est voluptatibus. Dolor perspiciatis sed autem in.", "184-6241-564-3697-8", false, 1, "feed", "We need to copy the 1080p FTP card!", 1 },
                    { 155, "matrix", "4.jpeg", 1, "Tenetur quasi similique quidem mollitia mollitia. Earum qui qui est aliquid et ut at aliquid. Animi rerum odit recusandae exercitationem reprehenderit asperiores officia ut. In deleniti ab voluptatem est voluptas.", "904-7418-728-1604-2", false, 1, "capacitor", "The GB pixel is down, bypass the cross-platform pixel so we can bypass the GB pixel!", 1 },
                    { 156, "system", "5.jpeg", 1, "Temporibus architecto voluptates asperiores perspiciatis nobis. Vel qui qui. Reprehenderit nobis quae recusandae ea sunt maxime. Molestiae sapiente nobis quisquam. Officia et recusandae a provident enim et culpa esse in.", "573-4047-027-7397-3", false, 0, "program", "The SCSI monitor is down, compress the primary monitor so we can compress the SCSI monitor!", 1 },
                    { 157, "matrix", "4.jpeg", 1, "Esse omnis facilis repellat quidem magni. Quae accusantium enim reprehenderit esse est alias eius ut. Quia aperiam nihil molestiae mollitia. Et culpa dolore repellendus asperiores id omnis ut ipsa. Hic quasi fuga eveniet ipsa blanditiis.", "371-5942-295-1773-5", false, 1, "array", "The SDD panel is down, synthesize the mobile panel so we can synthesize the SDD panel!", 1 },
                    { 158, "alarm", "3.jpeg", 1, "Hic cum perferendis ex in aut excepturi optio itaque culpa. Consequatur dolorum et odit ut esse velit quidem expedita repellat. Voluptates ut blanditiis animi. Quaerat id accusantium eligendi nesciunt quia magni. Perspiciatis iste architecto molestiae alias suscipit. Ea magnam unde quos non sapiente sit odio reiciendis mollitia.", "769-8662-459-5929-1", false, 0, "application", "I'll parse the mobile JBOD sensor, that should sensor the JBOD sensor!", 1 },
                    { 159, "system", "2.jpeg", 1, "Libero sit dolores odio sunt. Voluptatem quo autem et in. Dolores nihil quia est nihil qui exercitationem qui asperiores. Est rerum et ut nihil ut rerum dolorum quo. Quia aut error modi architecto tempore. Et facere unde provident molestiae distinctio.", "066-6765-769-6298-6", false, 1, "array", "We need to navigate the 1080p PCI card!", 1 },
                    { 160, "transmitter", "5.jpeg", 1, "Veritatis qui qui quis beatae et. Est cupiditate nostrum et est vel incidunt explicabo voluptatum tempora. Placeat ut ad sunt eaque.", "139-9368-225-1051-4", false, 1, "firewall", "We need to parse the digital SSL pixel!", 1 },
                    { 161, "port", "3.jpeg", 1, "Ut tempora minus voluptatem vero dignissimos voluptatum. Ex voluptatibus odio eos. Vero quod molestias nobis doloribus ut.", "626-2040-492-2104-4", false, 1, "interface", "bypassing the transmitter won't do anything, we need to generate the back-end SQL transmitter!", 1 },
                    { 162, "array", "4.jpeg", 1, "Repudiandae iure adipisci neque cumque et aut. Sit nemo exercitationem eius quo. Cumque aut nulla. Explicabo necessitatibus beatae sed unde autem ex. Ut perspiciatis explicabo error ad. Ullam nemo nihil officia libero vitae cumque est aut laboriosam.", "759-6467-600-3208-1", false, 0, "monitor", "Use the redundant JBOD firewall, then you can parse the redundant firewall!", 1 },
                    { 163, "port", "4.jpeg", 1, "Et et culpa fugiat. Rerum et quis ipsa. Ut neque nesciunt asperiores atque et quaerat deleniti quis natus. Alias distinctio exercitationem atque aspernatur. Sunt molestias blanditiis rerum. Repellat ab quo fugit aliquam minima.", "982-8589-199-8400-5", false, 1, "panel", "You can't input the application without transmitting the digital SDD application!", 1 },
                    { 164, "transmitter", "1.jpeg", 1, "Maiores culpa omnis ratione et qui eos. Illo cum consequuntur laborum exercitationem quia quisquam sapiente labore voluptatibus. Similique quia ad aut voluptatem ea et enim adipisci.", "716-0788-091-0354-8", false, 0, "port", "We need to connect the solid state SCSI panel!", 1 },
                    { 165, "capacitor", "4.jpeg", 1, "A ipsam alias vel minima. Magni necessitatibus a voluptates qui. Aut modi omnis quis doloremque dignissimos quasi.", "617-8615-983-7889-8", false, 0, "card", "Try to transmit the COM sensor, maybe it will transmit the virtual sensor!", 1 },
                    { 166, "matrix", "3.jpeg", 1, "Sapiente quae sit est eligendi consequatur eius doloremque. Nihil rerum non autem deleniti. Aut tempora facere odio et ratione.", "494-9466-868-1916-1", false, 0, "application", "Try to synthesize the XSS firewall, maybe it will synthesize the mobile firewall!", 1 },
                    { 167, "program", "5.jpeg", 1, "Eveniet velit repudiandae. Ducimus dolorum eos deleniti natus rem placeat odio et temporibus. Qui dolorem ratione est ea aut maiores. Ullam numquam animi beatae harum.", "873-3797-079-4595-0", false, 0, "feed", "You can't hack the microchip without calculating the wireless COM microchip!", 1 },
                    { 168, "application", "1.jpeg", 1, "Atque ex unde aut ea repellat. Libero reiciendis non et ut velit distinctio qui totam aliquid. Maiores ut possimus. Sint nostrum vel sequi perferendis et.", "052-5858-407-6318-4", false, 0, "circuit", "If we quantify the panel, we can get to the HDD panel through the cross-platform HDD panel!", 1 },
                    { 169, "bandwidth", "1.jpeg", 1, "Distinctio occaecati a occaecati ipsum alias saepe quis error quis. Ea nostrum neque tempora sunt. Nam et vel explicabo rerum.", "955-0654-580-6451-2", false, 1, "application", "Use the multi-byte USB card, then you can quantify the multi-byte card!", 1 },
                    { 170, "system", "4.jpeg", 1, "Doloremque nemo dolorum beatae dignissimos quisquam minima est. Nulla porro voluptates quibusdam inventore ipsam tenetur rerum quis. Et distinctio et voluptatem aut et rerum debitis maxime libero. Id doloremque sed. Repudiandae odit sunt consectetur sit qui deserunt.", "181-2136-907-6213-3", false, 0, "panel", "You can't bypass the application without calculating the auxiliary RAM application!", 1 },
                    { 171, "port", "5.jpeg", 1, "Molestiae eum autem delectus vitae. Temporibus quia repudiandae ipsa deleniti culpa impedit sit. Quidem nostrum voluptatem sed. Neque dolores tempore non. Incidunt voluptatem consequatur voluptatibus et voluptatum ab maiores. Iste quia error nihil occaecati corporis tempore beatae dolorem.", "257-0341-807-0209-1", false, 0, "program", "You can't navigate the sensor without backing up the back-end THX sensor!", 1 },
                    { 172, "array", "1.jpeg", 1, "Voluptatibus et ut ipsam exercitationem quis illum labore iusto. Cumque alias ducimus. Perferendis et quas omnis inventore perspiciatis corporis porro hic. Animi illo reprehenderit quod officiis non dolor dolor quam. Et error quis suscipit sapiente aut quia ullam eos ut. Sed voluptas rerum itaque porro.", "926-7148-265-8356-3", false, 0, "protocol", "You can't compress the pixel without bypassing the bluetooth PCI pixel!", 1 },
                    { 173, "system", "2.jpeg", 1, "Quo libero eos voluptatibus consequatur libero ipsam nihil sit quae. Eos aut et sequi. Doloremque ipsum quod dicta ab consequuntur asperiores voluptatem voluptatem. Quod rerum qui rem eligendi iure rerum quibusdam est.", "208-8570-758-2093-4", false, 0, "bandwidth", "I'll back up the multi-byte SMTP port, that should port the SMTP port!", 1 },
                    { 174, "card", "1.jpeg", 1, "Qui omnis aut. Et consequatur voluptas nihil eos deserunt vel sed mollitia sed. Ut harum ipsum id excepturi dolor. Et eos commodi quas odio rem voluptatem. Rem ut doloremque dolores expedita soluta. Asperiores dolores quia voluptatibus maiores error.", "462-8911-288-9467-3", false, 1, "system", "You can't parse the panel without indexing the wireless CSS panel!", 1 },
                    { 175, "sensor", "5.jpeg", 1, "In quod tempore ducimus corporis dolorem. Veniam labore voluptatem eaque qui illo eos temporibus aut eos. Aut magnam aperiam voluptas.", "130-5702-559-2492-3", false, 1, "card", "You can't connect the panel without synthesizing the neural TCP panel!", 1 },
                    { 176, "feed", "4.jpeg", 1, "Dolorem distinctio quia. Commodi officiis et error. Praesentium totam quaerat maxime. Distinctio voluptas temporibus. Dolores in at nam. Esse repudiandae et.", "115-7952-729-5942-1", false, 1, "card", "The JBOD pixel is down, reboot the optical pixel so we can reboot the JBOD pixel!", 1 },
                    { 177, "system", "3.jpeg", 1, "Laboriosam ea reprehenderit quisquam est sed fugit. Sint et suscipit magni doloremque. Aliquam at sit et consectetur sint est aut quibusdam eveniet. Et aut maiores.", "064-5434-885-4162-6", false, 0, "bus", "Use the wireless ADP interface, then you can parse the wireless interface!", 1 },
                    { 178, "interface", "3.jpeg", 1, "Doloremque voluptatum sed voluptatem modi. Corporis enim provident consequatur voluptates cupiditate omnis molestias aut. Ut vero minus.", "260-2954-485-1314-4", false, 1, "firewall", "Use the neural HTTP feed, then you can back up the neural feed!", 1 },
                    { 179, "alarm", "1.jpeg", 1, "Dicta excepturi ab non qui totam. Nostrum quos fugiat quasi eum libero. Eligendi possimus enim omnis sint perspiciatis.", "335-3785-939-2274-9", false, 0, "matrix", "Use the digital XML hard drive, then you can parse the digital hard drive!", 1 },
                    { 180, "interface", "4.jpeg", 1, "Perferendis est ipsum quo et perspiciatis laborum. Qui vel temporibus consequatur accusamus dolorem molestiae ut dignissimos. Reiciendis fugit excepturi perspiciatis distinctio nostrum. Sequi tempore eos consequatur quia. Et tempore excepturi voluptatibus. Doloremque dolores architecto.", "541-3630-247-2280-7", false, 0, "card", "Try to copy the EXE monitor, maybe it will copy the multi-byte monitor!", 1 },
                    { 181, "protocol", "5.jpeg", 1, "Molestias similique architecto voluptatum et nesciunt sit animi suscipit recusandae. Voluptatem assumenda dolores nisi illum reprehenderit. Non recusandae quis in eaque tempore id rem sit corporis. Sed et similique pariatur cumque. Ullam magni excepturi quas corporis corporis sit.", "844-0093-163-6762-4", false, 0, "matrix", "The SSL firewall is down, navigate the neural firewall so we can navigate the SSL firewall!", 1 },
                    { 182, "system", "4.jpeg", 1, "Aut aperiam voluptatem quisquam. Minima aut fugiat at veniam dolorem. Rem qui dicta corporis ab libero. Accusamus eum sit dicta.", "230-4578-051-9499-3", false, 1, "bus", "I'll parse the primary FTP bandwidth, that should bandwidth the FTP bandwidth!", 1 },
                    { 183, "circuit", "4.jpeg", 1, "Aliquam ducimus et. Magni est aut. Ipsum assumenda officia fuga. Hic eum in libero adipisci aliquid a fugiat non.", "729-4429-259-6178-2", false, 1, "interface", "We need to bypass the auxiliary HDD bandwidth!", 1 },
                    { 184, "feed", "2.jpeg", 1, "Et debitis hic modi minima. Ipsam consequatur et numquam quasi. Voluptas eius deserunt minus quos cumque. Quaerat nihil laborum dicta sit aliquam quo reiciendis. Consequatur atque quia dolores non.", "697-5095-373-9280-8", false, 1, "driver", "I'll reboot the digital SQL pixel, that should pixel the SQL pixel!", 1 },
                    { 185, "sensor", "4.jpeg", 1, "Maxime quasi eum. Sed fugiat libero exercitationem vel est in. Sequi molestiae voluptatibus est exercitationem qui cum ullam. Ducimus fugit quae ab voluptatibus sed omnis earum. Asperiores quibusdam ea ratione vel reiciendis non porro rerum excepturi. Repellat voluptate pariatur beatae sit ut assumenda voluptate voluptatem sapiente.", "538-1249-038-8109-6", false, 0, "transmitter", "If we index the card, we can get to the PCI card through the neural PCI card!", 1 },
                    { 186, "transmitter", "3.jpeg", 1, "Dolorum omnis dolorem ex at. Rem soluta placeat ut fugit laboriosam quo. Quas recusandae vel ullam.", "562-7073-796-4684-7", false, 1, "bus", "Use the cross-platform HDD alarm, then you can compress the cross-platform alarm!", 1 },
                    { 187, "driver", "1.jpeg", 1, "Placeat qui est aut excepturi iusto. Commodi molestias qui quam quos in et enim accusamus temporibus. In ea hic. Hic possimus doloribus vel sed provident aperiam consequuntur minima. Quia et et culpa. Aperiam aliquid perferendis ea.", "950-1070-392-3889-9", false, 1, "bus", "The COM protocol is down, hack the open-source protocol so we can hack the COM protocol!", 1 },
                    { 188, "array", "5.jpeg", 1, "Deleniti esse aut ut quibusdam repudiandae ut. Quasi neque quaerat alias autem sed adipisci quod. Beatae nulla consequatur sequi quaerat enim consequatur velit consectetur necessitatibus. Dolor harum rerum omnis ad aliquam debitis. Rem ut repellendus suscipit doloribus quis harum.", "520-2006-651-1072-7", false, 0, "firewall", "You can't input the application without connecting the auxiliary HTTP application!", 1 },
                    { 189, "matrix", "4.jpeg", 1, "Nulla delectus sit aliquam quae totam officiis hic. Nesciunt pariatur itaque et voluptates a quasi. Voluptatem ipsum quo corporis ut eum.", "634-6413-542-5470-8", false, 1, "application", "If we parse the card, we can get to the SMTP card through the back-end SMTP card!", 1 },
                    { 190, "firewall", "1.jpeg", 1, "Autem est excepturi labore ipsa ratione ut modi. Quas qui iusto magni facere non consectetur. Perferendis sequi vitae ea qui omnis similique.", "573-3194-709-7625-1", false, 0, "card", "If we reboot the panel, we can get to the IB panel through the 1080p IB panel!", 1 },
                    { 191, "hard drive", "3.jpeg", 1, "Repudiandae molestiae omnis placeat aut blanditiis laudantium sint. Unde blanditiis aut laudantium. Nihil eos eos dolorem commodi. Labore consectetur qui. Et aliquam enim ut reprehenderit voluptatem aut tenetur velit. Quis et eius inventore omnis.", "191-1280-425-8838-5", false, 1, "interface", "Use the 1080p AI microchip, then you can override the 1080p microchip!", 1 },
                    { 192, "protocol", "3.jpeg", 1, "Molestias deleniti omnis. Sed eius sed similique similique iure quo. Porro eos ut error ducimus. Quos est rerum voluptate vero dolore in.", "140-8583-065-4386-0", false, 1, "monitor", "Use the optical JBOD bus, then you can copy the optical bus!", 1 },
                    { 193, "bus", "1.jpeg", 1, "Temporibus eius animi minus non. Molestiae error sit magnam commodi magni optio error est. Excepturi reprehenderit neque ab ipsa similique dolores omnis. Dolor quae corporis explicabo. Eveniet amet facilis consequatur quae dolorem eius.", "451-2563-826-1191-1", false, 1, "port", "If we input the transmitter, we can get to the ADP transmitter through the 1080p ADP transmitter!", 1 },
                    { 194, "transmitter", "1.jpeg", 1, "Accusantium aut nesciunt. Suscipit quasi velit labore hic aliquam sint. Ea sunt eligendi est quidem omnis eius recusandae voluptate sit. Dolorem possimus quisquam.", "461-5948-600-0260-3", false, 1, "card", "You can't parse the firewall without hacking the multi-byte SSL firewall!", 1 },
                    { 195, "application", "5.jpeg", 1, "Aliquam enim possimus perferendis culpa sint. Exercitationem harum cum dolor voluptatem voluptas. Nulla et rem voluptatibus. Voluptatem nihil exercitationem est architecto et.", "471-5291-331-6597-4", false, 1, "pixel", "We need to navigate the mobile FTP sensor!", 1 },
                    { 196, "sensor", "2.jpeg", 1, "Error molestias incidunt esse eaque enim. Consectetur a sit possimus et eveniet unde sunt. Velit id quas at ut id sint omnis. Nobis voluptatum sed qui sequi fugit. Temporibus itaque ut dolor.", "338-3144-340-3747-6", false, 1, "microchip", "indexing the feed won't do anything, we need to compress the redundant PNG feed!", 1 },
                    { 197, "protocol", "3.jpeg", 1, "Quisquam cupiditate et facere. Quia distinctio esse delectus. Voluptatem officiis quia maiores deleniti incidunt dicta facilis ratione sunt. Eos accusamus rem sed architecto blanditiis ab debitis alias. Iure est voluptatem quia eum autem asperiores cupiditate.", "286-8677-788-3988-1", false, 0, "capacitor", "Use the multi-byte RSS circuit, then you can program the multi-byte circuit!", 1 },
                    { 198, "interface", "5.jpeg", 1, "Et porro vel eum voluptatem rerum vitae eveniet autem. Ex sit laudantium minus. Sequi ut beatae. Autem necessitatibus ullam nam dicta molestiae. Voluptas dolorum eum enim rerum porro.", "732-3495-856-3696-7", false, 1, "microchip", "I'll back up the solid state PNG port, that should port the PNG port!", 1 },
                    { 199, "hard drive", "3.jpeg", 1, "Cum laudantium vel quasi veritatis. Et ab veniam itaque. Voluptate ipsum sit deserunt. Optio eius odio dolore.", "478-6841-532-6584-5", false, 1, "panel", "synthesizing the firewall won't do anything, we need to transmit the open-source IB firewall!", 1 },
                    { 200, "hard drive", "2.jpeg", 1, "Corrupti cupiditate quidem quaerat quae sit ipsam officiis praesentium libero. Perspiciatis aut inventore in velit ipsam dolorem ut voluptatem. Inventore hic non quidem eius ipsum.", "924-1783-752-0237-7", false, 0, "microchip", "You can't parse the panel without navigating the haptic SMS panel!", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_LibraryUserId",
                table: "Reviews",
                column: "LibraryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCheckouts_BookId",
                table: "UserCheckouts",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCheckouts_LibraryUserId",
                table: "UserCheckouts",
                column: "LibraryUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "UserCheckouts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
