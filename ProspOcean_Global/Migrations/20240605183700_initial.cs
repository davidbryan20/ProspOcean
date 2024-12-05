using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProspOcean_Global.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especie",
                columns: table => new
                {
                    id_esp = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_commum_esp = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    nm_cientifico_esp = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    desc_esp = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    habitat_esp = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.id_esp);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id_usu = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    email_usu = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    senha_usu = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    nome_usu = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id_usu);
                });

            migrationBuilder.CreateTable(
                name: "Conservacao",
                columns: table => new
                {
                    id_cons = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    titulo_cons = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    desc_cons = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    dt_inicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    contato_cons = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    Especie_id_esp = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conservacao", x => x.id_cons);
                    table.ForeignKey(
                        name: "FK_Conservacao_Especie_Especie_id_esp",
                        column: x => x.Especie_id_esp,
                        principalTable: "Especie",
                        principalColumn: "id_esp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favoritadas",
                columns: table => new
                {
                    id_fav = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Usuario_id_usu = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Especie_id_esp = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritadas", x => x.id_fav);
                    table.ForeignKey(
                        name: "FK_Favoritadas_Especie_Especie_id_esp",
                        column: x => x.Especie_id_esp,
                        principalTable: "Especie",
                        principalColumn: "id_esp",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoritadas_Usuario_Usuario_id_usu",
                        column: x => x.Usuario_id_usu,
                        principalTable: "Usuario",
                        principalColumn: "id_usu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conservacao_Especie_id_esp",
                table: "Conservacao",
                column: "Especie_id_esp");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritadas_Especie_id_esp",
                table: "Favoritadas",
                column: "Especie_id_esp");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritadas_Usuario_id_usu",
                table: "Favoritadas",
                column: "Usuario_id_usu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conservacao");

            migrationBuilder.DropTable(
                name: "Favoritadas");

            migrationBuilder.DropTable(
                name: "Especie");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
