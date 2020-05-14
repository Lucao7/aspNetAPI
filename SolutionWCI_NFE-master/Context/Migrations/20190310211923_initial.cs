using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COM_Company",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    TradingName = table.Column<string>(maxLength: 100, nullable: false),
                    FantasyName = table.Column<string>(maxLength: 100, nullable: true),
                    CNPJ = table.Column<string>(maxLength: 20, nullable: false),
                    StateRegistration = table.Column<string>(maxLength: 20, nullable: false),
                    CNAE = table.Column<string>(maxLength: 20, nullable: true),
                    MunicipalityRegistration = table.Column<string>(maxLength: 20, nullable: true),
                    StateRegistrationReplaceTributary = table.Column<string>(maxLength: 20, nullable: true),
                    UrlLogo = table.Column<string>(nullable: true),
                    CellPhone = table.Column<string>(maxLength: 150, nullable: true),
                    PhoneNumbers = table.Column<string>(maxLength: 150, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: false),
                    AddressNumber = table.Column<string>(maxLength: 20, nullable: false),
                    AddressComplement = table.Column<string>(maxLength: 250, nullable: true),
                    Neighborhood = table.Column<string>(maxLength: 150, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "COM_Company_Config_NFe",
                columns: table => new
                {
                    CompanyConfigNFeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    CurrentNumberNfe = table.Column<int>(nullable: false),
                    VersionNfe = table.Column<string>(nullable: false),
                    EnvironmentNFE = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_Company_Config_NFe", x => x.CompanyConfigNFeId);
                    table.ForeignKey(
                        name: "FK_COM_Company_Config_NFe_COM_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "COM_Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COM_Personal_Information",
                columns: table => new
                {
                    PersonalInformationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: true),
                    CompanyId = table.Column<Guid>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    IndividualResistration = table.Column<string>(maxLength: 20, nullable: true),
                    CellPhone = table.Column<string>(maxLength: 150, nullable: true),
                    PhoneNumbers = table.Column<string>(maxLength: 150, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: true),
                    AddressNumber = table.Column<string>(maxLength: 10, nullable: true),
                    AddressComplement = table.Column<string>(maxLength: 100, nullable: true),
                    Neighborhood = table.Column<string>(maxLength: 70, nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    StateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_Personal_Information", x => x.PersonalInformationId);
                    table.ForeignKey(
                        name: "FK_COM_Personal_Information_COM_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "COM_Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ACC_Account",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    EmailAccount = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACC_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_ACC_Account_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACC_Account_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COM_State",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    FederativeUnit = table.Column<string>(maxLength: 2, nullable: true),
                    ExternalCode = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_State", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_COM_State_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COM_State_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INV_Invoice_CFOP",
                columns: table => new
                {
                    InvoiceCFOPId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 4, nullable: false),
                    Description = table.Column<string>(maxLength: 350, nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INV_Invoice_CFOP", x => x.InvoiceCFOPId);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_CFOP_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_CFOP_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INV_Invoice_Related",
                columns: table => new
                {
                    InvoiceRelatedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    AccessKey = table.Column<string>(nullable: true),
                    ModelInvoce = table.Column<string>(nullable: true),
                    SeriesInvoce = table.Column<int>(nullable: false),
                    NumberInvoce = table.Column<int>(nullable: false),
                    DateEmission = table.Column<DateTime>(nullable: false),
                    CNPJ = table.Column<string>(maxLength: 20, nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INV_Invoice_Related", x => x.InvoiceRelatedId);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Related_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Related_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ORD_Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORD_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_ORD_Order_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORD_Order_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Product_Exoneration_Reason_ICMS",
                columns: table => new
                {
                    ProductExonerationReasonICMSId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 4, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product_Exoneration_Reason_ICMS", x => x.ProductExonerationReasonICMSId);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Exoneration_Reason_ICMS_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Exoneration_Reason_ICMS_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Product_Origin_ICMS",
                columns: table => new
                {
                    ProductOriginId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 4, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product_Origin_ICMS", x => x.ProductOriginId);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Origin_ICMS_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Origin_ICMS_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Product_Tributary_Situation_COFINS",
                columns: table => new
                {
                    ProductTributarySituationCOFINSId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 4, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product_Tributary_Situation_COFINS", x => x.ProductTributarySituationCOFINSId);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Tributary_Situation_COFINS_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Tributary_Situation_COFINS_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Product_Tributary_Situation_ICMS",
                columns: table => new
                {
                    ProductTributarySituationICMSId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    Regime = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 4, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product_Tributary_Situation_ICMS", x => x.ProductTributarySituationICMSId);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Tributary_Situation_ICMS_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Tributary_Situation_ICMS_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Product_Tributary_Situation_IPI",
                columns: table => new
                {
                    ProductTributarySituationIPIId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 4, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product_Tributary_Situation_IPI", x => x.ProductTributarySituationIPIId);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Tributary_Situation_IPI_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Tributary_Situation_IPI_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Product_Tributary_Situation_PIS",
                columns: table => new
                {
                    ProductTributarySituationPISId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 4, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product_Tributary_Situation_PIS", x => x.ProductTributarySituationPISId);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Tributary_Situation_PIS_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Tributary_Situation_PIS_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Product_Unit_Commercial",
                columns: table => new
                {
                    ProductUnitCommercialId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product_Unit_Commercial", x => x.ProductUnitCommercialId);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Unit_Commercial_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Unit_Commercial_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Product_Unit_Tributary",
                columns: table => new
                {
                    ProductUnitTributaryId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product_Unit_Tributary", x => x.ProductUnitTributaryId);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Unit_Tributary_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Unit_Tributary_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INV_Invoice_NatureOperation",
                columns: table => new
                {
                    InvoiceNatureOperationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 120, nullable: false),
                    AdditionalInformationTaxpayer = table.Column<string>(maxLength: 255, nullable: true),
                    AdditionalInformationFiscal = table.Column<string>(maxLength: 255, nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INV_Invoice_NatureOperation", x => x.InvoiceNatureOperationId);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_NatureOperation_ACC_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "ACC_Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_NatureOperation_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_NatureOperation_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_ProductNCM",
                columns: table => new
                {
                    ProductNCMId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    NCM = table.Column<string>(maxLength: 8, nullable: false),
                    Simple = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    SimpleTaxSubstitution = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    BCICMS = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    AliquotICMSOrigin = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    AliquotICMSDestination = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    MarginValueAggregate = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    BCICMS_ST = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ValueIcms_ST = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_ProductNCM", x => x.ProductNCMId);
                    table.ForeignKey(
                        name: "FK_PRO_ProductNCM_ACC_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "ACC_Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_ProductNCM_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_ProductNCM_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COM_City",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    ExternalCode = table.Column<string>(maxLength: 50, nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_COM_City_COM_State_StateId",
                        column: x => x.StateId,
                        principalTable: "COM_State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COM_City_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COM_City_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INV_Invoice_Related_Producer",
                columns: table => new
                {
                    InvoiceRelatedProducerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    SeriesInvoce = table.Column<int>(nullable: false),
                    NumberInvoce = table.Column<int>(nullable: false),
                    DateEmission = table.Column<DateTime>(nullable: false),
                    Model = table.Column<int>(nullable: false),
                    CNPJ = table.Column<string>(maxLength: 20, nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    StateRegistration = table.Column<string>(maxLength: 20, nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INV_Invoice_Related_Producer", x => x.InvoiceRelatedProducerId);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Related_Producer_COM_State_StateId",
                        column: x => x.StateId,
                        principalTable: "COM_State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Related_Producer_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Related_Producer_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Product_COFINS",
                columns: table => new
                {
                    ProductCOFINSId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    ProductTributarySituationCOFINSId = table.Column<int>(nullable: false),
                    TypeCalculationCOFINS = table.Column<int>(nullable: false),
                    ValueBaseCalculation = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    AliquotPercentage = table.Column<decimal>(type: "decimal(4,4)", nullable: true),
                    AliquotValue = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    AmountSold = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    ValueOfCOFINS = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    TypeCalculationCOFINS_ST = table.Column<int>(nullable: false),
                    ValueBaseCalculation_ST = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    AliquotPercentage_ST = table.Column<decimal>(type: "decimal(4,4)", nullable: true),
                    AliquotValue_ST = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    AmountSold_ST = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    ValueOfCOFINS_ST = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product_COFINS", x => x.ProductCOFINSId);
                    table.ForeignKey(
                        name: "FK_PRO_Product_COFINS_PRO_Product_Tributary_Situation_COFINS_ProductTributarySituationCOFINSId",
                        column: x => x.ProductTributarySituationCOFINSId,
                        principalTable: "PRO_Product_Tributary_Situation_COFINS",
                        principalColumn: "ProductTributarySituationCOFINSId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_Product_COFINS_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_COFINS_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Product_ICMS",
                columns: table => new
                {
                    ProductICMSId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    Regime = table.Column<int>(nullable: false),
                    ProductTributarySituationICMSId = table.Column<int>(nullable: false),
                    ProductOriginId = table.Column<int>(nullable: true),
                    ApplicableRateCreditCalculation = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    IcmsCreditCanBeAvalied = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ModalityDeterminationICMS = table.Column<int>(nullable: true),
                    DeductionICMS = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    BCICMS = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    AliquotICMS = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    OperationOwn = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ProductExonerationReasonICMSId = table.Column<int>(nullable: true),
                    ModalityDeterminationICMS_ST = table.Column<int>(nullable: true),
                    DeductionICMS_ST = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    MaginValueAddedICMS_ST = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    BCICMS_ST = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    AliquotICMS_ST = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ICMS_ST = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    StateId = table.Column<int>(nullable: true),
                    BCIcmsSTPreviouslyRetained = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    IcmsSTPreviouslyRetained = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product_ICMS", x => x.ProductICMSId);
                    table.ForeignKey(
                        name: "FK_PRO_Product_ICMS_PRO_Product_Exoneration_Reason_ICMS_ProductExonerationReasonICMSId",
                        column: x => x.ProductExonerationReasonICMSId,
                        principalTable: "PRO_Product_Exoneration_Reason_ICMS",
                        principalColumn: "ProductExonerationReasonICMSId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_ICMS_PRO_Product_Origin_ICMS_ProductOriginId",
                        column: x => x.ProductOriginId,
                        principalTable: "PRO_Product_Origin_ICMS",
                        principalColumn: "ProductOriginId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_ICMS_PRO_Product_Tributary_Situation_ICMS_ProductTributarySituationICMSId",
                        column: x => x.ProductTributarySituationICMSId,
                        principalTable: "PRO_Product_Tributary_Situation_ICMS",
                        principalColumn: "ProductTributarySituationICMSId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_Product_ICMS_COM_State_StateId",
                        column: x => x.StateId,
                        principalTable: "COM_State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_ICMS_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_ICMS_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Product_IPI",
                columns: table => new
                {
                    ProductIPIId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    ProductTributarySituationIPIId = table.Column<int>(nullable: false),
                    ClassFramework = table.Column<string>(maxLength: 5, nullable: true),
                    CodeFrameworkLegal = table.Column<string>(maxLength: 5, nullable: true),
                    ProducerCNPJ = table.Column<string>(maxLength: 20, nullable: true),
                    CodeSealControl = table.Column<string>(maxLength: 60, nullable: true),
                    AmountCodeSealControl = table.Column<int>(nullable: true),
                    TypeCalculation = table.Column<int>(nullable: false),
                    ValueBaseCalculation = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Aliquot = table.Column<decimal>(type: "decimal(4,4)", nullable: true),
                    AmountTotalUnitDefault = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    ValuePerUnit = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    ValueOfIPI = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product_IPI", x => x.ProductIPIId);
                    table.ForeignKey(
                        name: "FK_PRO_Product_IPI_PRO_Product_Tributary_Situation_IPI_ProductTributarySituationIPIId",
                        column: x => x.ProductTributarySituationIPIId,
                        principalTable: "PRO_Product_Tributary_Situation_IPI",
                        principalColumn: "ProductTributarySituationIPIId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_Product_IPI_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_IPI_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Product_PIS",
                columns: table => new
                {
                    ProductPISId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    ProductTributarySituationPISId = table.Column<int>(nullable: false),
                    TypeCalculationPIS = table.Column<int>(nullable: false),
                    ValueBaseCalculation = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    AliquotPercentage = table.Column<decimal>(type: "decimal(4,4)", nullable: true),
                    AliquotValue = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    AmountSold = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    ValueOfPIS = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    TypeCalculationPIS_ST = table.Column<int>(nullable: false),
                    ValueBaseCalculation_ST = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    AliquotPercentage_ST = table.Column<decimal>(type: "decimal(4,4)", nullable: true),
                    AliquotValue_ST = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    AmountSold_ST = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    ValueOfPIS_ST = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product_PIS", x => x.ProductPISId);
                    table.ForeignKey(
                        name: "FK_PRO_Product_PIS_PRO_Product_Tributary_Situation_PIS_ProductTributarySituationPISId",
                        column: x => x.ProductTributarySituationPISId,
                        principalTable: "PRO_Product_Tributary_Situation_PIS",
                        principalColumn: "ProductTributarySituationPISId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_Product_PIS_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_PIS_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    ProductCode = table.Column<string>(maxLength: 60, nullable: false),
                    ProductName = table.Column<string>(maxLength: 120, nullable: false),
                    EuropeanArticleNumber = table.Column<string>(maxLength: 14, nullable: true),
                    EuropeanArticleNumberUT = table.Column<string>(maxLength: 14, nullable: true),
                    ExTipi = table.Column<string>(maxLength: 3, nullable: true),
                    Genre = table.Column<string>(maxLength: 4, nullable: true),
                    ProductNCMId = table.Column<int>(nullable: false),
                    CEST = table.Column<string>(maxLength: 7, nullable: true),
                    ProductUnitCommercialId = table.Column<int>(nullable: false),
                    ValueCommercialUnit = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    ProductUnitTributaryId = table.Column<int>(nullable: false),
                    TributaryAmount = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    ValueTributaryUnit = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_PRO_Product_ACC_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "ACC_Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_Product_PRO_ProductNCM_ProductNCMId",
                        column: x => x.ProductNCMId,
                        principalTable: "PRO_ProductNCM",
                        principalColumn: "ProductNCMId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_PRO_Product_Unit_Commercial_ProductUnitCommercialId",
                        column: x => x.ProductUnitCommercialId,
                        principalTable: "PRO_Product_Unit_Commercial",
                        principalColumn: "ProductUnitCommercialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_Product_PRO_Product_Unit_Tributary_ProductUnitTributaryId",
                        column: x => x.ProductUnitTributaryId,
                        principalTable: "PRO_Product_Unit_Tributary",
                        principalColumn: "ProductUnitTributaryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_Product_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUS_Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    TradingName = table.Column<string>(maxLength: 150, nullable: false),
                    FantasyName = table.Column<string>(maxLength: 150, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 20, nullable: false),
                    StateRegistration = table.Column<string>(maxLength: 20, nullable: true),
                    MunicipalityRegistration = table.Column<string>(maxLength: 20, nullable: true),
                    Suframa = table.Column<string>(maxLength: 100, nullable: true),
                    CellPhone = table.Column<string>(maxLength: 150, nullable: true),
                    PhoneNumbers = table.Column<string>(maxLength: 150, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: true),
                    AddressNumber = table.Column<string>(maxLength: 10, nullable: true),
                    AddressComplement = table.Column<string>(maxLength: 100, nullable: true),
                    Neighborhood = table.Column<string>(maxLength: 150, nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUS_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_CUS_Customer_ACC_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "ACC_Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CUS_Customer_COM_City_CityId",
                        column: x => x.CityId,
                        principalTable: "COM_City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CUS_Customer_COM_State_StateId",
                        column: x => x.StateId,
                        principalTable: "COM_State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CUS_Customer_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CUS_Customer_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SHC_Shipping_Company ",
                columns: table => new
                {
                    ShippingCompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    TradingName = table.Column<string>(maxLength: 150, nullable: false),
                    FantasyName = table.Column<string>(maxLength: 150, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 20, nullable: false),
                    StateRegistration = table.Column<string>(maxLength: 20, nullable: true),
                    FreeICMS = table.Column<bool>(nullable: false),
                    CellPhone = table.Column<string>(maxLength: 150, nullable: true),
                    PhoneNumbers = table.Column<string>(maxLength: 150, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: true),
                    AddressNumber = table.Column<string>(maxLength: 10, nullable: true),
                    AddressComplement = table.Column<string>(maxLength: 100, nullable: true),
                    Neighborhood = table.Column<string>(maxLength: 150, nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHC_Shipping_Company ", x => x.ShippingCompanyId);
                    table.ForeignKey(
                        name: "FK_SHC_Shipping_Company _ACC_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "ACC_Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SHC_Shipping_Company _COM_City_CityId",
                        column: x => x.CityId,
                        principalTable: "COM_City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SHC_Shipping_Company _COM_State_StateId",
                        column: x => x.StateId,
                        principalTable: "COM_State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SHC_Shipping_Company _COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SHC_Shipping_Company _COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Product_X_ProductCOFINS",
                columns: table => new
                {
                    PRO_Product_X_ProductCOFINSId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductCOFINSId = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product_X_ProductCOFINS", x => x.PRO_Product_X_ProductCOFINSId);
                    table.ForeignKey(
                        name: "FK_PRO_Product_X_ProductCOFINS_PRO_Product_COFINS_ProductCOFINSId",
                        column: x => x.ProductCOFINSId,
                        principalTable: "PRO_Product_COFINS",
                        principalColumn: "ProductCOFINSId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_Product_X_ProductCOFINS_PRO_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRO_Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_Product_X_ProductCOFINS_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_X_ProductCOFINS_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Product_x_ProductICMS",
                columns: table => new
                {
                    PRO_Product_x_ProductICMSId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductICMSId = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product_x_ProductICMS", x => x.PRO_Product_x_ProductICMSId);
                    table.ForeignKey(
                        name: "FK_PRO_Product_x_ProductICMS_PRO_Product_ICMS_ProductICMSId",
                        column: x => x.ProductICMSId,
                        principalTable: "PRO_Product_ICMS",
                        principalColumn: "ProductICMSId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_Product_x_ProductICMS_PRO_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRO_Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_Product_x_ProductICMS_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_x_ProductICMS_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Product_X_ProductIPI",
                columns: table => new
                {
                    PRO_Product_X_ProductIPIId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductIPIId = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product_X_ProductIPI", x => x.PRO_Product_X_ProductIPIId);
                    table.ForeignKey(
                        name: "FK_PRO_Product_X_ProductIPI_PRO_Product_IPI_ProductIPIId",
                        column: x => x.ProductIPIId,
                        principalTable: "PRO_Product_IPI",
                        principalColumn: "ProductIPIId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_Product_X_ProductIPI_PRO_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRO_Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_Product_X_ProductIPI_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_X_ProductIPI_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRO_Product_X_ProductPIS",
                columns: table => new
                {
                    PRO_Product_X_ProductPISId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductPISId = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product_X_ProductPIS", x => x.PRO_Product_X_ProductPISId);
                    table.ForeignKey(
                        name: "FK_PRO_Product_X_ProductPIS_PRO_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRO_Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_Product_X_ProductPIS_PRO_Product_PIS_ProductPISId",
                        column: x => x.ProductPISId,
                        principalTable: "PRO_Product_PIS",
                        principalColumn: "ProductPISId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_Product_X_ProductPIS_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRO_Product_X_ProductPIS_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INV_Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    AccessKey = table.Column<string>(nullable: false),
                    OrderId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    ModelInvoce = table.Column<string>(nullable: false),
                    SeriesInvoce = table.Column<int>(nullable: false),
                    NumberInvoce = table.Column<int>(nullable: false),
                    DateEmission = table.Column<DateTime>(nullable: false),
                    CodeNumbericInvoce = table.Column<int>(nullable: false),
                    VerifyingDigit = table.Column<int>(nullable: false),
                    TypeDocument = table.Column<int>(nullable: false),
                    DateInputExit = table.Column<DateTime>(nullable: false),
                    PaymentForm = table.Column<int>(nullable: false),
                    EmissionForm = table.Column<int>(nullable: false),
                    EmissionPurpose = table.Column<int>(nullable: false),
                    TypePrint = table.Column<int>(nullable: false),
                    ConsumerFinal = table.Column<int>(nullable: false),
                    DestinationOperation = table.Column<int>(nullable: false),
                    CustomerService = table.Column<int>(nullable: false),
                    InvoiceNatureOperationId = table.Column<int>(nullable: false),
                    NatureOperation = table.Column<string>(maxLength: 120, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    AdditionalInformationTaxpayer = table.Column<string>(maxLength: 255, nullable: true),
                    AdditionalInformationFiscal = table.Column<string>(maxLength: 255, nullable: true),
                    DateInputContingency = table.Column<DateTime>(nullable: true),
                    JustificationInputContigency = table.Column<string>(maxLength: 255, nullable: true),
                    ShippingCompanyId = table.Column<int>(nullable: true),
                    FreightMode = table.Column<int>(nullable: false),
                    InvoiceStatus = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INV_Invoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_ACC_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "ACC_Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_COM_City_CityId",
                        column: x => x.CityId,
                        principalTable: "COM_City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_COM_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "COM_Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_CUS_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CUS_Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_INV_Invoice_NatureOperation_InvoiceNatureOperationId",
                        column: x => x.InvoiceNatureOperationId,
                        principalTable: "INV_Invoice_NatureOperation",
                        principalColumn: "InvoiceNatureOperationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_ORD_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "ORD_Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_SHC_Shipping_Company _ShippingCompanyId",
                        column: x => x.ShippingCompanyId,
                        principalTable: "SHC_Shipping_Company ",
                        principalColumn: "ShippingCompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_COM_State_StateId",
                        column: x => x.StateId,
                        principalTable: "COM_State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INV_Invoice_Product",
                columns: table => new
                {
                    InvoiceProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductCode = table.Column<string>(maxLength: 8, nullable: false),
                    ProductName = table.Column<string>(maxLength: 120, nullable: true),
                    EuropeanArticleNumber = table.Column<string>(maxLength: 14, nullable: true),
                    EuropeanArticleNumberUT = table.Column<string>(maxLength: 14, nullable: true),
                    ProductNCM = table.Column<string>(maxLength: 60, nullable: false),
                    CST = table.Column<string>(maxLength: 4, nullable: false),
                    InvoiceCFOPId = table.Column<int>(nullable: false),
                    CFOP = table.Column<string>(nullable: false),
                    Unit = table.Column<string>(maxLength: 20, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    ValueUnit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ValueTotal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    UnitTributary = table.Column<string>(nullable: false),
                    TributaryAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ValueTributaryUnit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ApproximateTotalTaxes = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ProductICMSId = table.Column<int>(nullable: false),
                    ProductOrigin = table.Column<int>(nullable: false),
                    ModalityDeterminationICMS = table.Column<int>(nullable: false),
                    BaseCalculationICMS = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ValueICMS = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ProductIPIId = table.Column<int>(nullable: false),
                    CodeFrameworkLegal = table.Column<string>(maxLength: 5, nullable: true),
                    ProductTributarySituationIPI = table.Column<string>(nullable: false),
                    ValueIPI = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AliquotICMS = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AliquotIPI = table.Column<decimal>(type: "decimal(4,4)", nullable: false),
                    ProductPISId = table.Column<int>(nullable: false),
                    ProductTributarySituationPIS = table.Column<string>(nullable: true),
                    AliquotPIS = table.Column<decimal>(type: "decimal(4,4)", nullable: false),
                    ValuePIS = table.Column<decimal>(type: "decimal(12,4)", nullable: false),
                    ProductCOFINSId = table.Column<int>(nullable: false),
                    ProductTributarySituationCOFINS = table.Column<string>(nullable: true),
                    AliquotCOFINS = table.Column<decimal>(type: "decimal(4,4)", nullable: false),
                    ValueCOFINS = table.Column<decimal>(type: "decimal(12,4)", nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INV_Invoice_Product", x => x.InvoiceProductId);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Product_INV_Invoice_CFOP_InvoiceCFOPId",
                        column: x => x.InvoiceCFOPId,
                        principalTable: "INV_Invoice_CFOP",
                        principalColumn: "InvoiceCFOPId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Product_INV_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "INV_Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Product_PRO_Product_COFINS_ProductCOFINSId",
                        column: x => x.ProductCOFINSId,
                        principalTable: "PRO_Product_COFINS",
                        principalColumn: "ProductCOFINSId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Product_PRO_Product_ICMS_ProductICMSId",
                        column: x => x.ProductICMSId,
                        principalTable: "PRO_Product_ICMS",
                        principalColumn: "ProductICMSId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Product_PRO_Product_IPI_ProductIPIId",
                        column: x => x.ProductIPIId,
                        principalTable: "PRO_Product_IPI",
                        principalColumn: "ProductIPIId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Product_PRO_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRO_Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Product_PRO_Product_PIS_ProductPISId",
                        column: x => x.ProductPISId,
                        principalTable: "PRO_Product_PIS",
                        principalColumn: "ProductPISId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Product_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Product_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INV_Invoice_Related_Coupon",
                columns: table => new
                {
                    InvoiceRelatedCouponId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    SequentialOrderNumber = table.Column<int>(nullable: false),
                    AmountOrderOperational = table.Column<int>(nullable: false),
                    ModelCoupon = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INV_Invoice_Related_Coupon", x => x.InvoiceRelatedCouponId);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Related_Coupon_INV_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "INV_Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Related_Coupon_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Related_Coupon_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INV_Invoice_Tickets",
                columns: table => new
                {
                    InvoiceTicketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    MaturityDate = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INV_Invoice_Tickets", x => x.InvoiceTicketId);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Tickets_INV_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "INV_Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Tickets_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Tickets_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INV_Invoice_Vehicle",
                columns: table => new
                {
                    InvoiceVehicleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    CodeAntt = table.Column<string>(maxLength: 60, nullable: true),
                    PlaqueVehicle = table.Column<string>(maxLength: 60, nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INV_Invoice_Vehicle", x => x.InvoiceVehicleId);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Vehicle_INV_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "INV_Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Vehicle_COM_State_StateId",
                        column: x => x.StateId,
                        principalTable: "COM_State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Vehicle_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Vehicle_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INV_Invoice_Volumes",
                columns: table => new
                {
                    InvoiceVolumesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Species = table.Column<string>(maxLength: 60, nullable: true),
                    Brand = table.Column<string>(maxLength: 60, nullable: true),
                    Numbering = table.Column<string>(maxLength: 60, nullable: true),
                    GrossWeight = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    NetWeight = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INV_Invoice_Volumes", x => x.InvoiceVolumesId);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Volumes_INV_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "INV_Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Volumes_COM_Personal_Information_UserID",
                        column: x => x.UserID,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INV_Invoice_Volumes_COM_Personal_Information_UserIDLastUpdate",
                        column: x => x.UserIDLastUpdate,
                        principalTable: "COM_Personal_Information",
                        principalColumn: "PersonalInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACC_Account_UserID",
                table: "ACC_Account",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_Account_UserIDLastUpdate",
                table: "ACC_Account",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_COM_City_StateId",
                table: "COM_City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_City_UserID",
                table: "COM_City",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_COM_City_UserIDLastUpdate",
                table: "COM_City",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_COM_Company_AccountId",
                table: "COM_Company",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_Company_CityId",
                table: "COM_Company",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_Company_StateId",
                table: "COM_Company",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_Company_UserID",
                table: "COM_Company",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_COM_Company_UserIDLastUpdate",
                table: "COM_Company",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_COM_Company_Config_NFe_AccountId",
                table: "COM_Company_Config_NFe",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_Company_Config_NFe_CompanyId",
                table: "COM_Company_Config_NFe",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COM_Company_Config_NFe_UserID",
                table: "COM_Company_Config_NFe",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_COM_Company_Config_NFe_UserIDLastUpdate",
                table: "COM_Company_Config_NFe",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_COM_Personal_Information_AccountId",
                table: "COM_Personal_Information",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_Personal_Information_CityId",
                table: "COM_Personal_Information",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_Personal_Information_CompanyId",
                table: "COM_Personal_Information",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_Personal_Information_StateId",
                table: "COM_Personal_Information",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_State_UserID",
                table: "COM_State",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_COM_State_UserIDLastUpdate",
                table: "COM_State",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_CUS_Customer_AccountId",
                table: "CUS_Customer",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CUS_Customer_CityId",
                table: "CUS_Customer",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CUS_Customer_StateId",
                table: "CUS_Customer",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CUS_Customer_UserID",
                table: "CUS_Customer",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CUS_Customer_UserIDLastUpdate",
                table: "CUS_Customer",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_AccountId",
                table: "INV_Invoice",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_CityId",
                table: "INV_Invoice",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_CompanyId",
                table: "INV_Invoice",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_CustomerId",
                table: "INV_Invoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_InvoiceNatureOperationId",
                table: "INV_Invoice",
                column: "InvoiceNatureOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_OrderId",
                table: "INV_Invoice",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_ShippingCompanyId",
                table: "INV_Invoice",
                column: "ShippingCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_StateId",
                table: "INV_Invoice",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_UserID",
                table: "INV_Invoice",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_UserIDLastUpdate",
                table: "INV_Invoice",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_CFOP_UserID",
                table: "INV_Invoice_CFOP",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_CFOP_UserIDLastUpdate",
                table: "INV_Invoice_CFOP",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_NatureOperation_AccountId",
                table: "INV_Invoice_NatureOperation",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_NatureOperation_UserID",
                table: "INV_Invoice_NatureOperation",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_NatureOperation_UserIDLastUpdate",
                table: "INV_Invoice_NatureOperation",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Product_InvoiceCFOPId",
                table: "INV_Invoice_Product",
                column: "InvoiceCFOPId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Product_InvoiceId",
                table: "INV_Invoice_Product",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Product_ProductCOFINSId",
                table: "INV_Invoice_Product",
                column: "ProductCOFINSId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Product_ProductICMSId",
                table: "INV_Invoice_Product",
                column: "ProductICMSId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Product_ProductIPIId",
                table: "INV_Invoice_Product",
                column: "ProductIPIId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Product_ProductId",
                table: "INV_Invoice_Product",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Product_ProductPISId",
                table: "INV_Invoice_Product",
                column: "ProductPISId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Product_UserID",
                table: "INV_Invoice_Product",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Product_UserIDLastUpdate",
                table: "INV_Invoice_Product",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Related_UserID",
                table: "INV_Invoice_Related",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Related_UserIDLastUpdate",
                table: "INV_Invoice_Related",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Related_Coupon_InvoiceId",
                table: "INV_Invoice_Related_Coupon",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Related_Coupon_UserID",
                table: "INV_Invoice_Related_Coupon",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Related_Coupon_UserIDLastUpdate",
                table: "INV_Invoice_Related_Coupon",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Related_Producer_StateId",
                table: "INV_Invoice_Related_Producer",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Related_Producer_UserID",
                table: "INV_Invoice_Related_Producer",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Related_Producer_UserIDLastUpdate",
                table: "INV_Invoice_Related_Producer",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Tickets_InvoiceId",
                table: "INV_Invoice_Tickets",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Tickets_UserID",
                table: "INV_Invoice_Tickets",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Tickets_UserIDLastUpdate",
                table: "INV_Invoice_Tickets",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Vehicle_InvoiceId",
                table: "INV_Invoice_Vehicle",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Vehicle_StateId",
                table: "INV_Invoice_Vehicle",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Vehicle_UserID",
                table: "INV_Invoice_Vehicle",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Vehicle_UserIDLastUpdate",
                table: "INV_Invoice_Vehicle",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Volumes_InvoiceId",
                table: "INV_Invoice_Volumes",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Volumes_UserID",
                table: "INV_Invoice_Volumes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_INV_Invoice_Volumes_UserIDLastUpdate",
                table: "INV_Invoice_Volumes",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_ORD_Order_UserID",
                table: "ORD_Order",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ORD_Order_UserIDLastUpdate",
                table: "ORD_Order",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_AccountId",
                table: "PRO_Product",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_ProductNCMId",
                table: "PRO_Product",
                column: "ProductNCMId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_ProductUnitCommercialId",
                table: "PRO_Product",
                column: "ProductUnitCommercialId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_ProductUnitTributaryId",
                table: "PRO_Product",
                column: "ProductUnitTributaryId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_UserID",
                table: "PRO_Product",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_UserIDLastUpdate",
                table: "PRO_Product",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_COFINS_ProductTributarySituationCOFINSId",
                table: "PRO_Product_COFINS",
                column: "ProductTributarySituationCOFINSId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_COFINS_UserID",
                table: "PRO_Product_COFINS",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_COFINS_UserIDLastUpdate",
                table: "PRO_Product_COFINS",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_Exoneration_Reason_ICMS_UserID",
                table: "PRO_Product_Exoneration_Reason_ICMS",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_Exoneration_Reason_ICMS_UserIDLastUpdate",
                table: "PRO_Product_Exoneration_Reason_ICMS",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_ICMS_ProductExonerationReasonICMSId",
                table: "PRO_Product_ICMS",
                column: "ProductExonerationReasonICMSId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_ICMS_ProductOriginId",
                table: "PRO_Product_ICMS",
                column: "ProductOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_ICMS_ProductTributarySituationICMSId",
                table: "PRO_Product_ICMS",
                column: "ProductTributarySituationICMSId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_ICMS_StateId",
                table: "PRO_Product_ICMS",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_ICMS_UserID",
                table: "PRO_Product_ICMS",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_ICMS_UserIDLastUpdate",
                table: "PRO_Product_ICMS",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_IPI_ProductTributarySituationIPIId",
                table: "PRO_Product_IPI",
                column: "ProductTributarySituationIPIId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_IPI_UserID",
                table: "PRO_Product_IPI",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_IPI_UserIDLastUpdate",
                table: "PRO_Product_IPI",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_Origin_ICMS_UserID",
                table: "PRO_Product_Origin_ICMS",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_Origin_ICMS_UserIDLastUpdate",
                table: "PRO_Product_Origin_ICMS",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_PIS_ProductTributarySituationPISId",
                table: "PRO_Product_PIS",
                column: "ProductTributarySituationPISId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_PIS_UserID",
                table: "PRO_Product_PIS",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_PIS_UserIDLastUpdate",
                table: "PRO_Product_PIS",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_Tributary_Situation_COFINS_UserID",
                table: "PRO_Product_Tributary_Situation_COFINS",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_Tributary_Situation_COFINS_UserIDLastUpdate",
                table: "PRO_Product_Tributary_Situation_COFINS",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_Tributary_Situation_ICMS_UserID",
                table: "PRO_Product_Tributary_Situation_ICMS",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_Tributary_Situation_ICMS_UserIDLastUpdate",
                table: "PRO_Product_Tributary_Situation_ICMS",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_Tributary_Situation_IPI_UserID",
                table: "PRO_Product_Tributary_Situation_IPI",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_Tributary_Situation_IPI_UserIDLastUpdate",
                table: "PRO_Product_Tributary_Situation_IPI",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_Tributary_Situation_PIS_UserID",
                table: "PRO_Product_Tributary_Situation_PIS",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_Tributary_Situation_PIS_UserIDLastUpdate",
                table: "PRO_Product_Tributary_Situation_PIS",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_Unit_Commercial_UserID",
                table: "PRO_Product_Unit_Commercial",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_Unit_Commercial_UserIDLastUpdate",
                table: "PRO_Product_Unit_Commercial",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_Unit_Tributary_UserID",
                table: "PRO_Product_Unit_Tributary",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_Unit_Tributary_UserIDLastUpdate",
                table: "PRO_Product_Unit_Tributary",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_X_ProductCOFINS_ProductCOFINSId",
                table: "PRO_Product_X_ProductCOFINS",
                column: "ProductCOFINSId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_X_ProductCOFINS_ProductId",
                table: "PRO_Product_X_ProductCOFINS",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_X_ProductCOFINS_UserID",
                table: "PRO_Product_X_ProductCOFINS",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_X_ProductCOFINS_UserIDLastUpdate",
                table: "PRO_Product_X_ProductCOFINS",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_x_ProductICMS_ProductICMSId",
                table: "PRO_Product_x_ProductICMS",
                column: "ProductICMSId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_x_ProductICMS_ProductId",
                table: "PRO_Product_x_ProductICMS",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_x_ProductICMS_UserID",
                table: "PRO_Product_x_ProductICMS",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_x_ProductICMS_UserIDLastUpdate",
                table: "PRO_Product_x_ProductICMS",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_X_ProductIPI_ProductIPIId",
                table: "PRO_Product_X_ProductIPI",
                column: "ProductIPIId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_X_ProductIPI_ProductId",
                table: "PRO_Product_X_ProductIPI",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_X_ProductIPI_UserID",
                table: "PRO_Product_X_ProductIPI",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_X_ProductIPI_UserIDLastUpdate",
                table: "PRO_Product_X_ProductIPI",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_X_ProductPIS_ProductId",
                table: "PRO_Product_X_ProductPIS",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_X_ProductPIS_ProductPISId",
                table: "PRO_Product_X_ProductPIS",
                column: "ProductPISId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_X_ProductPIS_UserID",
                table: "PRO_Product_X_ProductPIS",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_X_ProductPIS_UserIDLastUpdate",
                table: "PRO_Product_X_ProductPIS",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_ProductNCM_AccountId",
                table: "PRO_ProductNCM",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_ProductNCM_UserID",
                table: "PRO_ProductNCM",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_ProductNCM_UserIDLastUpdate",
                table: "PRO_ProductNCM",
                column: "UserIDLastUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_SHC_Shipping_Company _AccountId",
                table: "SHC_Shipping_Company ",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SHC_Shipping_Company _CityId",
                table: "SHC_Shipping_Company ",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_SHC_Shipping_Company _StateId",
                table: "SHC_Shipping_Company ",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_SHC_Shipping_Company _UserID",
                table: "SHC_Shipping_Company ",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SHC_Shipping_Company _UserIDLastUpdate",
                table: "SHC_Shipping_Company ",
                column: "UserIDLastUpdate");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_Company_COM_Personal_Information_UserID",
                table: "COM_Company",
                column: "UserID",
                principalTable: "COM_Personal_Information",
                principalColumn: "PersonalInformationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_Company_COM_Personal_Information_UserIDLastUpdate",
                table: "COM_Company",
                column: "UserIDLastUpdate",
                principalTable: "COM_Personal_Information",
                principalColumn: "PersonalInformationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_Company_COM_State_StateId",
                table: "COM_Company",
                column: "StateId",
                principalTable: "COM_State",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_Company_ACC_Account_AccountId",
                table: "COM_Company",
                column: "AccountId",
                principalTable: "ACC_Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_Company_COM_City_CityId",
                table: "COM_Company",
                column: "CityId",
                principalTable: "COM_City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_Company_Config_NFe_COM_Personal_Information_UserID",
                table: "COM_Company_Config_NFe",
                column: "UserID",
                principalTable: "COM_Personal_Information",
                principalColumn: "PersonalInformationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_Company_Config_NFe_COM_Personal_Information_UserIDLastUpdate",
                table: "COM_Company_Config_NFe",
                column: "UserIDLastUpdate",
                principalTable: "COM_Personal_Information",
                principalColumn: "PersonalInformationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_Company_Config_NFe_ACC_Account_AccountId",
                table: "COM_Company_Config_NFe",
                column: "AccountId",
                principalTable: "ACC_Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_Personal_Information_COM_State_StateId",
                table: "COM_Personal_Information",
                column: "StateId",
                principalTable: "COM_State",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_Personal_Information_ACC_Account_AccountId",
                table: "COM_Personal_Information",
                column: "AccountId",
                principalTable: "ACC_Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_Personal_Information_COM_City_CityId",
                table: "COM_Personal_Information",
                column: "CityId",
                principalTable: "COM_City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ACC_Account_COM_Personal_Information_UserID",
                table: "ACC_Account");

            migrationBuilder.DropForeignKey(
                name: "FK_ACC_Account_COM_Personal_Information_UserIDLastUpdate",
                table: "ACC_Account");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_City_COM_Personal_Information_UserID",
                table: "COM_City");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_City_COM_Personal_Information_UserIDLastUpdate",
                table: "COM_City");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_Company_COM_Personal_Information_UserID",
                table: "COM_Company");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_Company_COM_Personal_Information_UserIDLastUpdate",
                table: "COM_Company");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_State_COM_Personal_Information_UserID",
                table: "COM_State");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_State_COM_Personal_Information_UserIDLastUpdate",
                table: "COM_State");

            migrationBuilder.DropTable(
                name: "COM_Company_Config_NFe");

            migrationBuilder.DropTable(
                name: "INV_Invoice_Product");

            migrationBuilder.DropTable(
                name: "INV_Invoice_Related");

            migrationBuilder.DropTable(
                name: "INV_Invoice_Related_Coupon");

            migrationBuilder.DropTable(
                name: "INV_Invoice_Related_Producer");

            migrationBuilder.DropTable(
                name: "INV_Invoice_Tickets");

            migrationBuilder.DropTable(
                name: "INV_Invoice_Vehicle");

            migrationBuilder.DropTable(
                name: "INV_Invoice_Volumes");

            migrationBuilder.DropTable(
                name: "PRO_Product_X_ProductCOFINS");

            migrationBuilder.DropTable(
                name: "PRO_Product_x_ProductICMS");

            migrationBuilder.DropTable(
                name: "PRO_Product_X_ProductIPI");

            migrationBuilder.DropTable(
                name: "PRO_Product_X_ProductPIS");

            migrationBuilder.DropTable(
                name: "INV_Invoice_CFOP");

            migrationBuilder.DropTable(
                name: "INV_Invoice");

            migrationBuilder.DropTable(
                name: "PRO_Product_COFINS");

            migrationBuilder.DropTable(
                name: "PRO_Product_ICMS");

            migrationBuilder.DropTable(
                name: "PRO_Product_IPI");

            migrationBuilder.DropTable(
                name: "PRO_Product");

            migrationBuilder.DropTable(
                name: "PRO_Product_PIS");

            migrationBuilder.DropTable(
                name: "CUS_Customer");

            migrationBuilder.DropTable(
                name: "INV_Invoice_NatureOperation");

            migrationBuilder.DropTable(
                name: "ORD_Order");

            migrationBuilder.DropTable(
                name: "SHC_Shipping_Company ");

            migrationBuilder.DropTable(
                name: "PRO_Product_Tributary_Situation_COFINS");

            migrationBuilder.DropTable(
                name: "PRO_Product_Exoneration_Reason_ICMS");

            migrationBuilder.DropTable(
                name: "PRO_Product_Origin_ICMS");

            migrationBuilder.DropTable(
                name: "PRO_Product_Tributary_Situation_ICMS");

            migrationBuilder.DropTable(
                name: "PRO_Product_Tributary_Situation_IPI");

            migrationBuilder.DropTable(
                name: "PRO_ProductNCM");

            migrationBuilder.DropTable(
                name: "PRO_Product_Unit_Commercial");

            migrationBuilder.DropTable(
                name: "PRO_Product_Unit_Tributary");

            migrationBuilder.DropTable(
                name: "PRO_Product_Tributary_Situation_PIS");

            migrationBuilder.DropTable(
                name: "COM_Personal_Information");

            migrationBuilder.DropTable(
                name: "COM_Company");

            migrationBuilder.DropTable(
                name: "ACC_Account");

            migrationBuilder.DropTable(
                name: "COM_City");

            migrationBuilder.DropTable(
                name: "COM_State");
        }
    }
}
