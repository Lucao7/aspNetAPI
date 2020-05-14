using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUS_Customer",
                columns: table => new
                {
                    CorretoraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserIDLastUpdate = table.Column<int>(nullable: false),
                    CnpjCpf = table.Column<string>(maxLength: 14, nullable: false),
                    RazaoSocialCorretor = table.Column<string>(maxLength: 150, nullable: true),
                    EnderecoCorretor = table.Column<string>(maxLength: 150, nullable: true),
                    Bairro = table.Column<string>(maxLength: 150, nullable: true),
                    Complemento = table.Column<string>(maxLength: 150, nullable: true),
                    Cidade = table.Column<string>(maxLength: 150, nullable: true),
                    Estado = table.Column<string>(maxLength: 2, nullable: true),
                    MeioComunicacao = table.Column<string>(maxLength: 150, nullable: true),
                    TipoMeioComunicacao = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUS_Customer", x => x.CorretoraId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CUS_Customer");
        }
    }
}
