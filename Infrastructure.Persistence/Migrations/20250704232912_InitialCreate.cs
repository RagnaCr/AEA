using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiConnections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConnectionName = table.Column<string>(type: "text", nullable: false),
                    ExchangeName = table.Column<string>(type: "text", nullable: false),
                    EncryptedKey1 = table.Column<string>(type: "text", nullable: false),
                    EncryptedKey2 = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    LastSuccessfulSync = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastErrorMessage = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiConnections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NickName = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ticker = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AssetClass = table.Column<int>(type: "integer", nullable: false),
                    Sector = table.Column<string>(type: "text", nullable: true),
                    Industry = table.Column<string>(type: "text", nullable: true),
                    CountryCode = table.Column<string>(type: "text", nullable: true),
                    IsCustom = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioDailySnapshots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PortfolioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MarketValue = table.Column<decimal>(type: "numeric", nullable: false),
                    CostBasis = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioDailySnapshots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolios_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    TaxYear = table.Column<int>(type: "integer", nullable: false),
                    JurisdictionCountryCode = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    CostBasisMethod = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxReports_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PortfolioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Source = table.Column<int>(type: "integer", nullable: false),
                    SourceOperationId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    RawData = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioApiConnections",
                columns: table => new
                {
                    PortfolioId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApiConnectionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioApiConnections", x => new { x.PortfolioId, x.ApiConnectionId });
                    table.ForeignKey(
                        name: "FK_PortfolioApiConnections_ApiConnections_ApiConnectionId",
                        column: x => x.ApiConnectionId,
                        principalTable: "ApiConnections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioApiConnections_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxReportPortfolios",
                columns: table => new
                {
                    TaxReportId = table.Column<Guid>(type: "uuid", nullable: false),
                    PortfolioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxReportPortfolios", x => new { x.TaxReportId, x.PortfolioId });
                    table.ForeignKey(
                        name: "FK_TaxReportPortfolios_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxReportPortfolios_TaxReports_TaxReportId",
                        column: x => x.TaxReportId,
                        principalTable: "TaxReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxableEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaxReportId = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceOperationId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssetId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateOfDisposal = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    QuantityDisposed = table.Column<decimal>(type: "numeric(18,8)", nullable: false),
                    Proceeds = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CostBasis = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    HoldingPeriod = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxableEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxableEvents_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxableEvents_Operations_SourceOperationId",
                        column: x => x.SourceOperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxableEvents_TaxReports_TaxReportId",
                        column: x => x.TaxReportId,
                        principalTable: "TaxReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionLegs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OperationId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssetId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric(18,8)", nullable: false),
                    Direction = table.Column<int>(type: "integer", nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "numeric(18,8)", nullable: true),
                    PriceCurrencyId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLegs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionLegs_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionLegs_Assets_PriceCurrencyId",
                        column: x => x.PriceCurrencyId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionLegs_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "AssetClass", "CountryCode", "Industry", "IsCustom", "Name", "Sector", "Ticker", "UserId" },
                values: new object[,]
                {
                    { new Guid("024f8c86-6909-48cd-8d73-c3e459d3179d"), 4, null, null, false, "Eritrean Nakfa", null, "ERN", null },
                    { new Guid("026f86b5-3c88-4169-99d4-95850879e87a"), 4, null, null, false, "Romanian Leu", null, "RON", null },
                    { new Guid("03a49e55-04e6-48bc-9a7c-a8f41962815c"), 4, null, null, false, "Kenyan Shilling", null, "KES", null },
                    { new Guid("03c82b37-b491-4eda-94f9-cd674fdc9e4c"), 4, null, null, false, "Central African Republic Franc", null, "CAF", null },
                    { new Guid("05e06868-8f76-4793-95e8-2c712cc0894a"), 4, null, null, false, "Japanese Yen", null, "JPY", null },
                    { new Guid("07f88392-d02d-4879-9cf0-38bf7ee153f1"), 4, null, null, false, "Afghan Afghani", null, "AFN", null },
                    { new Guid("0d8f3b42-976d-486b-bf2a-caa7b361174d"), 4, null, null, false, "Macanese Pataca", null, "MOP", null },
                    { new Guid("0dfdf499-d77d-414f-b124-a9f61cc43302"), 4, null, null, false, "West African CFA Franc", null, "XOF", null },
                    { new Guid("0e3a43c3-ced3-44c9-8eff-92125f69f84e"), 4, null, null, false, "Hong Kong Dollar", null, "HKD", null },
                    { new Guid("108eb812-5056-47f4-bd4d-3e8795488ccd"), 4, null, null, false, "Singapore Dollar", null, "SGD", null },
                    { new Guid("12061183-c46c-4264-a26d-6089ed262931"), 4, null, null, false, "Iraqi Dinar", null, "IQD", null },
                    { new Guid("1270444d-4246-489e-89af-cae50d2413b9"), 4, null, null, false, "Namibian Dollar", null, "NAD", null },
                    { new Guid("12836d29-5bd7-44be-9899-ea5b62deafda"), 4, null, null, false, "Panamanian Balboa", null, "PAB", null },
                    { new Guid("12a45ab9-0166-4195-94cb-d61ae5c646bc"), 4, null, null, false, "Maldivian Rufiyaa", null, "MVR", null },
                    { new Guid("14ecd1a3-fc23-459b-95fa-d96f256514f6"), 4, null, null, false, "Comorian Franc", null, "KMF", null },
                    { new Guid("184cfbd0-36c3-4796-b42f-51372a39fcab"), 4, null, null, false, "Bangladeshi Taka", null, "BDT", null },
                    { new Guid("18bf8d2c-8c92-473e-a8fe-7db0691e2753"), 4, null, null, false, "Brunei Dollar", null, "BND", null },
                    { new Guid("199154c4-eb9e-4916-bd4c-f69025e1ad5e"), 4, null, null, false, "Paraguayan Guarani", null, "PYG", null },
                    { new Guid("1997c794-2098-483c-87bf-c0b6272cc1de"), 4, null, null, false, "Iranian Rial", null, "IRR", null },
                    { new Guid("1ca7f042-fa02-4c69-8609-59ab3de4e87d"), 4, null, null, false, "Rwandan Franc", null, "RWF", null },
                    { new Guid("1dd71a42-4b2e-4b4c-b6ba-328c6d724473"), 4, null, null, false, "Armenian Dram", null, "AMD", null },
                    { new Guid("20a4575e-5819-4fad-ae8a-d91eaa9a005f"), 4, null, null, false, "Turkmenistani Manat", null, "TMT", null },
                    { new Guid("2193cc16-f96b-414e-8bf9-d52899fd199e"), 4, null, null, false, "Kuwaiti Dinar", null, "KWD", null },
                    { new Guid("21e1ce6e-c52c-490c-9714-e45b156a1540"), 4, null, null, false, "Honduran Lempira", null, "HNL", null },
                    { new Guid("2227b150-7379-4554-9e06-8b0a00829ec0"), 4, null, null, false, "Sri Lankan Rupee", null, "LKR", null },
                    { new Guid("24a133df-c52c-48b9-ae6b-f912c3217c78"), 4, null, null, false, "Swiss Franc", null, "CHF", null },
                    { new Guid("25676d7f-2101-4485-bbd9-e9aa10fc13e5"), 4, null, null, false, "Mauritian Rupee", null, "MUR", null },
                    { new Guid("2658e8c3-77a2-4462-b3a8-4527dd2ffc67"), 4, null, null, false, "Bulgarian Lev", null, "BGN", null },
                    { new Guid("282e94e2-ecea-4af5-8ca8-b4aa510a9eb0"), 4, null, null, false, "Yemeni Rial", null, "YER", null },
                    { new Guid("29201e8d-21f4-4757-8e3e-769734f488f2"), 4, null, null, false, "Guyanese Dollar", null, "GYD", null },
                    { new Guid("2bb8b9a0-9c95-478e-9fc7-77ca07bf67a1"), 4, null, null, false, "East Caribbean Dollar", null, "XCD", null },
                    { new Guid("2d87129c-96fc-45bb-bfd6-a713ab996c23"), 4, null, null, false, "Russian Ruble", null, "RUB", null },
                    { new Guid("2fa50609-3d49-415a-8165-cfb41dcdd5bc"), 4, null, null, false, "Norwegian Krone", null, "NOK", null },
                    { new Guid("2fdaea83-9f93-4e42-95d9-8a4a284541de"), 4, null, null, false, "Bhutanese Ngultrum", null, "BTN", null },
                    { new Guid("32b49394-032e-4039-b3fb-ec74e90e651e"), 4, null, null, false, "Mozambican Metical", null, "MZN", null },
                    { new Guid("330d6d95-bd76-4261-b45c-757be4c171d0"), 4, null, null, false, "Zambian Kwacha", null, "ZMW", null },
                    { new Guid("334847cd-724e-4658-8651-ad317a79f032"), 4, null, null, false, "Ghanaian Cedi", null, "GHS", null },
                    { new Guid("33d43655-d8a7-494e-b45c-1a8c86b74cc4"), 4, null, null, false, "Sierra Leonean Leone", null, "SLE", null },
                    { new Guid("342ab7b7-b682-4341-94c1-c98dd7a76aa4"), 4, null, null, false, "South Sudanese Pound", null, "SSP", null },
                    { new Guid("34ada21d-ac91-428b-a22b-a45b304132fa"), 4, null, null, false, "Ugandan Shilling", null, "UGX", null },
                    { new Guid("34c46ac5-fb63-4173-9959-ebd39118890f"), 4, null, null, false, "Turkish Lira", null, "TRY", null },
                    { new Guid("39d35c6e-ad87-4b94-8d2f-ad603f1fbd8d"), 4, null, null, false, "Ukrainian Hryvnia", null, "UAH", null },
                    { new Guid("3b136058-452b-4964-abac-045bb7c9be42"), 4, null, null, false, "Thai Baht", null, "THB", null },
                    { new Guid("3f14e688-cf72-43d2-b4f5-7e264a3059f7"), 4, null, null, false, "Lebanese Pound", null, "LBP", null },
                    { new Guid("455b6463-ae97-4c8e-b76e-0e7fe6695be7"), 4, null, null, false, "Hungarian Forint", null, "HUF", null },
                    { new Guid("457838d7-4434-46c8-a407-8e2f1f7e844f"), 4, null, null, false, "Trinidad and Tobago Dollar", null, "TTD", null },
                    { new Guid("49f1ec15-aab3-4b87-af58-ae2867b05582"), 4, null, null, false, "Colombian Peso", null, "COP", null },
                    { new Guid("4a8d05ff-e55f-4f4b-83ff-bd1eb087e155"), 4, null, null, false, "Dominican Peso", null, "DOP", null },
                    { new Guid("4c99428e-15d2-4a26-814e-df0485fe2ba6"), 4, null, null, false, "Tajikistani Somoni", null, "TJS", null },
                    { new Guid("4cee1848-ce24-4a1e-b984-b8e272059386"), 4, null, null, false, "Canadian Dollar", null, "CAD", null },
                    { new Guid("4eb6fd4a-5770-4d16-b4f1-dec85ded9455"), 4, null, null, false, "Algerian Dinar", null, "DZD", null },
                    { new Guid("51407e6b-b022-4743-a29a-6720956fa82e"), 4, null, null, false, "CFP Franc", null, "XPF", null },
                    { new Guid("53346a1b-ff62-42ba-948c-45f2a7f44bee"), 4, null, null, false, "Bermudian Dollar", null, "BMD", null },
                    { new Guid("53c24d9c-86a2-408c-aa49-ae078e9ab5fc"), 4, null, null, false, "Tunisian Dinar", null, "TND", null },
                    { new Guid("55dc8d16-d3dd-4d64-86c0-ac1cee1d5fd9"), 4, null, null, false, "Serbian Dinar", null, "RSD", null },
                    { new Guid("57e36279-d09f-4d46-8d51-aab67f5a8310"), 4, null, null, false, "Saudi Riyal", null, "SAR", null },
                    { new Guid("595ea6bb-b268-492f-a17d-2529f7480cca"), 4, null, null, false, "Haitian Gourde", null, "HTG", null },
                    { new Guid("5a1f0ab5-2b7c-4ef4-a202-dab1c23036f0"), 4, null, null, false, "Congolese Franc", null, "CDF", null },
                    { new Guid("5d3ef524-0b65-4f94-bd5c-96a7752e44bf"), 4, null, null, false, "Belize Dollar", null, "BZD", null },
                    { new Guid("5dbbbf94-0e92-4590-93c5-4505863ca5f2"), 4, null, null, false, "Angolan Kwanza", null, "AOA", null },
                    { new Guid("5ff97503-b02f-4270-8969-a9dea0e0ccaf"), 4, null, null, false, "Moldovan Leu", null, "MDL", null },
                    { new Guid("6194b501-6c22-4f3f-ba76-1a8f5d1b7229"), 4, null, null, false, "Central African CFA Franc", null, "XAF", null },
                    { new Guid("61de6cb4-9b1a-45fd-a9bd-47a56617e718"), 4, null, null, false, "Euro", null, "EUR", null },
                    { new Guid("64143c05-c227-46bf-b4e9-b50e23dac42a"), 4, null, null, false, "Lao Kip", null, "LAK", null },
                    { new Guid("6469b582-f146-4e4e-8a70-0abe613ee07d"), 4, null, null, false, "Costa Rican Colón", null, "CRC", null },
                    { new Guid("647912a6-4d43-46c7-9b53-9888c005f4b6"), 4, null, null, false, "Czech Koruna", null, "CZK", null },
                    { new Guid("663aed05-3efa-4e23-9add-acae97edfde7"), 4, null, null, false, "Chinese Yuan", null, "CNY", null },
                    { new Guid("66c146e3-808d-4e5d-80aa-c44018cb50eb"), 4, null, null, false, "South Korean Won", null, "KRW", null },
                    { new Guid("691b6fe9-d770-4df5-96f0-1c1ff4096467"), 4, null, null, false, "Malawian Kwacha", null, "MWK", null },
                    { new Guid("6a01b72f-8bdd-43a7-bdec-43165a8338f0"), 4, null, null, false, "Guatemalan Quetzal", null, "GTQ", null },
                    { new Guid("6a2d7d2a-8ee5-4682-aefe-f81089b81264"), 4, null, null, false, "Kyrgyzstani Som", null, "KGS", null },
                    { new Guid("6b6321de-7fae-4a0f-97e6-30f4c29c969e"), 4, null, null, false, "Uruguayan Peso", null, "UYU", null },
                    { new Guid("6c570f89-6b79-442b-87ce-6f08d38faae8"), 4, null, null, false, "Seychellois Rupee", null, "SCR", null },
                    { new Guid("6e63c4ec-68df-44b9-bd5e-24c150470923"), 4, null, null, false, "Chilean Peso", null, "CLP", null },
                    { new Guid("71e7733a-9349-4c4f-91cd-dd8ac062b989"), 4, null, null, false, "Taiwan Dollar", null, "TWD", null },
                    { new Guid("7a21fb6d-2d54-41e8-a71c-59d82a49b807"), 4, null, null, false, "Barbadian Dollar", null, "BBD", null },
                    { new Guid("7b171f95-97f2-4312-9a7b-3af40df2b0ad"), 4, null, null, false, "Croatian Kuna", null, "HRK", null },
                    { new Guid("7be1726b-498d-4445-ac9f-a45fb2cac47e"), 4, null, null, false, "British Pound Sterling", null, "GBP", null },
                    { new Guid("7d5fbafc-964d-4088-be3a-45bc28161d06"), 4, null, null, false, "Albanian Lek", null, "ALL", null },
                    { new Guid("7dbd0cf4-88b5-4d63-9ace-c40b5457e17f"), 4, null, null, false, "Danish Krone", null, "DKK", null },
                    { new Guid("7e29f768-a561-43f2-b142-31096247c127"), 4, null, null, false, "Libyan Dinar", null, "LYD", null },
                    { new Guid("8039eeac-40fa-47cf-bb6b-3b80a8aaed1d"), 4, null, null, false, "Guinean Franc", null, "GNF", null },
                    { new Guid("814337ea-257e-4eff-9b70-77c6241c968e"), 4, null, null, false, "Qatari Riyal", null, "QAR", null },
                    { new Guid("82947a9e-85bd-4c13-a609-080ed08c29f6"), 4, null, null, false, "Vietnamese Dong", null, "VND", null },
                    { new Guid("85458e9d-d3fb-4324-8d5f-37ea3b35de79"), 4, null, null, false, "Sudanese Pound", null, "SDG", null },
                    { new Guid("85d3c698-3004-4698-b8d8-0791d8ffe16a"), 4, null, null, false, "Cuban Peso", null, "CUP", null },
                    { new Guid("8a05b642-daf9-491f-9069-57b0950d0255"), 4, null, null, false, "Mexican Peso", null, "MXN", null },
                    { new Guid("8f4a80c3-c44b-464c-abc2-a6b59acbd735"), 4, null, null, false, "Nicaraguan Córdoba", null, "NIO", null },
                    { new Guid("8fe8d78c-1659-4a13-a5e7-8e609d85e871"), 4, null, null, false, "Australian Dollar", null, "AUD", null },
                    { new Guid("91afd8a5-2ebe-43bc-b2d0-f7305ece6942"), 4, null, null, false, "Gambian Dalasi", null, "GMD", null },
                    { new Guid("946aea29-e85a-4405-8aff-326df580abdb"), 4, null, null, false, "Cayman Islands Dollar", null, "KYD", null },
                    { new Guid("94e17a33-d71c-4b35-89bb-db2f5942d7c1"), 4, null, null, false, "Bosnia and Herzegovina Convertible Mark", null, "BAM", null },
                    { new Guid("9c443b6d-a3e9-4a14-97e8-9844d907625a"), 4, null, null, false, "Uzbekistani Som", null, "UZS", null },
                    { new Guid("9d7b7e3e-865c-41c7-8e89-f293931064b1"), 4, null, null, false, "Azerbaijani Manat", null, "AZN", null },
                    { new Guid("9dff6f64-147f-4d30-a16f-c8fd6e17c0e2"), 4, null, null, false, "Botswana Pula", null, "BWP", null },
                    { new Guid("9e962372-1faf-4058-a26d-b2650cb9f1ae"), 4, null, null, false, "Malaysian Ringgit", null, "MYR", null },
                    { new Guid("9f99abf3-a0f1-438e-8bd4-6f4fe2e4b348"), 4, null, null, false, "Netherlands Antillean Guilder", null, "ANG", null },
                    { new Guid("9fb13e5a-df0b-40f5-b04f-c9007314131c"), 4, null, null, false, "Malagasy Ariary", null, "MGA", null },
                    { new Guid("9fd52c0c-91e2-478b-9d2c-49bed0142057"), 4, null, null, false, "Argentine Peso", null, "ARS", null },
                    { new Guid("a18aa9b9-42ed-4a33-9c6c-905b8c41f3e6"), 4, null, null, false, "Nepalese Rupee", null, "NPR", null },
                    { new Guid("a1f73f99-f262-413b-91c7-2b9434269fe7"), 4, null, null, false, "Swedish Krona", null, "SEK", null },
                    { new Guid("a5647e0e-4afe-4ab0-ba46-14a5946c4d43"), 4, null, null, false, "Indonesian Rupiah", null, "IDR", null },
                    { new Guid("a788cbec-91b6-4926-9ce4-23829fb93c22"), 4, null, null, false, "Syrian Pound", null, "SYP", null },
                    { new Guid("a930e6eb-2e00-4f07-b81d-e3cc93294bb5"), 4, null, null, false, "Somali Shilling", null, "SOS", null },
                    { new Guid("accb3d3f-9427-4f5b-ad55-75cbe5377186"), 4, null, null, false, "Nigerian Naira", null, "NGN", null },
                    { new Guid("b0383f66-0007-496a-9d56-a668121a1310"), 4, null, null, false, "Liberian Dollar", null, "LRD", null },
                    { new Guid("b07afbf6-d542-45fb-9426-04fa7ec8b051"), 4, null, null, false, "Cambodian Riel", null, "KHR", null },
                    { new Guid("b1a794ce-ad5f-4d7f-91a2-819b1dd5e756"), 4, null, null, false, "North Korean Won", null, "KPW", null },
                    { new Guid("b6c97579-8d54-4883-9d8c-5060443ec822"), 4, null, null, false, "Belarusian Ruble", null, "BYN", null },
                    { new Guid("b7eb2fab-df0f-4d01-a59e-04375257610c"), 4, null, null, false, "Myanmar Kyat", null, "MMK", null },
                    { new Guid("b906a6c3-d805-428c-9f7e-9044a0c264b0"), 4, null, null, false, "Egyptian Pound", null, "EGP", null },
                    { new Guid("bc6b3a64-1729-4755-bf55-f912269c9a6f"), 4, null, null, false, "Djiboutian Franc", null, "DJF", null },
                    { new Guid("be8b0477-748b-454b-9dee-4a03af13b079"), 4, null, null, false, "Jamaican Dollar", null, "JMD", null },
                    { new Guid("c1142a11-84bf-4be5-b83c-2b3ee6e405d5"), 4, null, null, false, "Israeli New Shekel", null, "ILS", null },
                    { new Guid("c15412f6-7dec-43c8-ae41-79e83a9b118c"), 4, null, null, false, "Indian Rupee", null, "INR", null },
                    { new Guid("c22d2e2e-bf37-4cac-9b1c-f5571a559d97"), 4, null, null, false, "Mongolian Tugrik", null, "MNT", null },
                    { new Guid("c2447cad-09cd-4d88-8ee6-fad1bf6439db"), 4, null, null, false, "US Dollar", null, "USD", null },
                    { new Guid("c4140e31-efb7-49a2-94b4-9bcb999c2d7b"), 4, null, null, false, "Cape Verdean Escudo", null, "CVE", null },
                    { new Guid("c7e16a4e-bf28-4e1d-9b26-b59ae6ba596b"), 4, null, null, false, "Bolivian Boliviano", null, "BOB", null },
                    { new Guid("c85bb462-c65b-4ebf-b348-f862f3cb4582"), 4, null, null, false, "Aruban Florin", null, "AWG", null },
                    { new Guid("c88119b8-fa8f-4232-b970-377e155104a5"), 4, null, null, false, "UAE Dirham", null, "AED", null },
                    { new Guid("c88e8959-76e6-4bc6-a4ae-1cc4a49b2711"), 4, null, null, false, "Surinamese Dollar", null, "SRD", null },
                    { new Guid("c89e26f6-1910-4734-a225-b179f950b42f"), 4, null, null, false, "Lesotho Loti", null, "LSL", null },
                    { new Guid("c92098b2-ba07-4aff-8b7b-52a5c0518c3b"), 4, null, null, false, "South African Rand", null, "ZAR", null },
                    { new Guid("c9df998b-365a-45e1-a54d-cab06e00ce1f"), 4, null, null, false, "Icelandic Krona", null, "ISK", null },
                    { new Guid("ca036578-a1a9-4449-8c11-3f0735f1ce96"), 4, null, null, false, "Brazilian Real", null, "BRL", null },
                    { new Guid("cf37decf-2f5f-4f86-8a88-ee20a2b41150"), 4, null, null, false, "Ethiopian Birr", null, "ETB", null },
                    { new Guid("d0c9b454-2b6d-43bd-b1fb-1b23faeddc6f"), 4, null, null, false, "Georgian Lari", null, "GEL", null },
                    { new Guid("d1c48450-ed21-4672-8ebf-e67b27baf038"), 4, null, null, false, "Philippine Peso", null, "PHP", null },
                    { new Guid("d1d9219b-d1e8-42e4-a9a4-3b1e6885890d"), 4, null, null, false, "Venezuelan Bolívar Soberano", null, "VES", null },
                    { new Guid("d1e9bb46-2643-4818-b47d-391cef92ffed"), 4, null, null, false, "Polish Zloty", null, "PLN", null },
                    { new Guid("d3cb4a85-0a91-4981-b460-9cd0b303821a"), 4, null, null, false, "Peruvian Sol", null, "PEN", null },
                    { new Guid("d3d7342b-a4aa-4832-b082-bb95f1b3c9c1"), 4, null, null, false, "São Tomé and Príncipe Dobra", null, "STN", null },
                    { new Guid("d5a778db-61e5-4fc0-864c-0f3b45985afa"), 4, null, null, false, "Pakistani Rupee", null, "PKR", null },
                    { new Guid("d5e3b831-e600-4a7e-95eb-cbc87199a32b"), 4, null, null, false, "Macedonian Denar", null, "MKD", null },
                    { new Guid("dcdd88a5-afc6-48da-9c18-3fe19a16b3a0"), 4, null, null, false, "Zimbabwean Dollar", null, "ZWL", null },
                    { new Guid("ddc37a97-9fe6-45dd-99be-601a9d59daa2"), 4, null, null, false, "Burundian Franc", null, "BIF", null },
                    { new Guid("e4799e8d-87d5-4139-9686-5549c64be7b8"), 4, null, null, false, "Moroccan Dirham", null, "MAD", null },
                    { new Guid("e4c5709d-1598-4aa5-997b-557934e63b7a"), 4, null, null, false, "Falkland Islands Pound", null, "FKP", null },
                    { new Guid("e4d2065d-9c41-4132-bf08-e992caa58ec4"), 4, null, null, false, "Kazakhstani Tenge", null, "KZT", null },
                    { new Guid("e74a4a65-f4fb-45b4-a5e2-065eacd13961"), 4, null, null, false, "Swazi Lilangeni", null, "SZL", null },
                    { new Guid("e7a9a8f3-0bdb-45ba-a858-34b3bf79d305"), 4, null, null, false, "Bahamian Dollar", null, "BSD", null },
                    { new Guid("e9456e82-e049-4be6-8747-a68bc46382d0"), 4, null, null, false, "Omani Rial", null, "OMR", null },
                    { new Guid("f1fadfbe-51d5-49fb-85e0-504ae550bdd0"), 4, null, null, false, "Tanzanian Shilling", null, "TZS", null },
                    { new Guid("f5e8f9b7-a142-4892-a71f-d8e3f8646d5f"), 4, null, null, false, "Jordanian Dinar", null, "JOD", null },
                    { new Guid("f7219f13-1120-4c81-b058-2ac8b09eb06a"), 4, null, null, false, "Bahraini Dinar", null, "BHD", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Ticker",
                table: "Assets",
                column: "Ticker",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_UserId",
                table: "Assets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_PortfolioId",
                table: "Operations",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_Source_SourceOperationId",
                table: "Operations",
                columns: new[] { "Source", "SourceOperationId" });

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioApiConnections_ApiConnectionId",
                table: "PortfolioApiConnections",
                column: "ApiConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_UserId",
                table: "Portfolios",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxableEvents_AssetId",
                table: "TaxableEvents",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxableEvents_SourceOperationId",
                table: "TaxableEvents",
                column: "SourceOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxableEvents_TaxReportId",
                table: "TaxableEvents",
                column: "TaxReportId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxReportPortfolios_PortfolioId",
                table: "TaxReportPortfolios",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxReports_UserId",
                table: "TaxReports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLegs_AssetId",
                table: "TransactionLegs",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLegs_OperationId",
                table: "TransactionLegs",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLegs_PriceCurrencyId",
                table: "TransactionLegs",
                column: "PriceCurrencyId");
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
                name: "PortfolioApiConnections");

            migrationBuilder.DropTable(
                name: "PortfolioDailySnapshots");

            migrationBuilder.DropTable(
                name: "TaxableEvents");

            migrationBuilder.DropTable(
                name: "TaxReportPortfolios");

            migrationBuilder.DropTable(
                name: "TransactionLegs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ApiConnections");

            migrationBuilder.DropTable(
                name: "TaxReports");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
