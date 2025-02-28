using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RentFleet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CpfCnpj = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Endereco = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    UF = table.Column<string>(type: "text", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegrasDescontoJuros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoVeiculo = table.Column<string>(type: "text", nullable: false),
                    Categoria = table.Column<string>(type: "text", nullable: false),
                    TipoRegra = table.Column<string>(type: "text", nullable: false),
                    Percentual = table.Column<decimal>(type: "numeric", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegrasDescontoJuros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeAtendente = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValoresLocacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoVeiculo = table.Column<string>(type: "text", nullable: false),
                    Categoria = table.Column<string>(type: "text", nullable: false),
                    ValorDiaria = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValoresLocacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Categoria = table.Column<string>(type: "text", nullable: false),
                    Marca = table.Column<string>(type: "text", nullable: false),
                    Modelo = table.Column<string>(type: "text", nullable: false),
                    AnoFabricacao = table.Column<int>(type: "integer", nullable: false),
                    AnoModelo = table.Column<int>(type: "integer", nullable: false),
                    Cor = table.Column<string>(type: "text", nullable: false),
                    Placa = table.Column<string>(type: "text", nullable: false),
                    Chassi = table.Column<string>(type: "text", nullable: false),
                    QuilometragemInicial = table.Column<decimal>(type: "numeric", nullable: false),
                    QuilometragemAtual = table.Column<decimal>(type: "numeric", nullable: false),
                    NumeroPortas = table.Column<int>(type: "integer", nullable: false),
                    CapacidadeTanque = table.Column<decimal>(type: "numeric", nullable: false),
                    Combustivel = table.Column<string>(type: "text", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DadosCaminhoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VeiculoId = table.Column<int>(type: "integer", nullable: false),
                    TipoCaminhao = table.Column<string>(type: "text", nullable: false),
                    ComprimentoCarroceria = table.Column<decimal>(type: "numeric", nullable: false),
                    AlturaCarroceria = table.Column<decimal>(type: "numeric", nullable: false),
                    LarguraCarroceria = table.Column<decimal>(type: "numeric", nullable: false),
                    TipoCarroceria = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosCaminhoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosCaminhoes_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DadosLocalizacaoOperacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VeiculoId = table.Column<int>(type: "integer", nullable: false),
                    FilialRegistro = table.Column<string>(type: "text", nullable: true),
                    StatusLocacao = table.Column<string>(type: "text", nullable: false),
                    DataAquisicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValorAquisicao = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorLocacaoDiaria = table.Column<decimal>(type: "numeric", nullable: false),
                    Observacoes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosLocalizacaoOperacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosLocalizacaoOperacoes_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DadosMotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VeiculoId = table.Column<int>(type: "integer", nullable: false),
                    TipoMoto = table.Column<string>(type: "text", nullable: false),
                    CapacidadeBagageiro = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosMotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosMotos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DadosSegurancaConformidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VeiculoId = table.Column<int>(type: "integer", nullable: false),
                    DataUltimaInspecao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatusInspecao = table.Column<string>(type: "text", nullable: false),
                    NumeroSeguro = table.Column<string>(type: "text", nullable: false),
                    Seguradora = table.Column<string>(type: "text", nullable: false),
                    ValidadeSeguro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataUltimaManutencao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProximaManutencao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatusVeiculo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosSegurancaConformidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosSegurancaConformidades_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DadosTecnicosVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VeiculoId = table.Column<int>(type: "integer", nullable: false),
                    PotenciaMotor = table.Column<decimal>(type: "numeric", nullable: false),
                    Cilindrada = table.Column<int>(type: "integer", nullable: false),
                    Transmissao = table.Column<string>(type: "text", nullable: false),
                    NumeroMarchas = table.Column<int>(type: "integer", nullable: false),
                    Tracao = table.Column<string>(type: "text", nullable: false),
                    PesoBrutoTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    CapacidadeCarga = table.Column<decimal>(type: "numeric", nullable: false),
                    NumeroEixos = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosTecnicosVeiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosTecnicosVeiculos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentosDigitalizados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VeiculoId = table.Column<int>(type: "integer", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    UrlDocumento = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentosDigitalizados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentosDigitalizados_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FotosVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VeiculoId = table.Column<int>(type: "integer", nullable: false),
                    UrlImagem = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosVeiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotosVeiculos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocacoesVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VeiculoId = table.Column<int>(type: "integer", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataFim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValorBase = table.Column<decimal>(type: "numeric", nullable: false),
                    Desconto = table.Column<decimal>(type: "numeric", nullable: false),
                    Juros = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    StatusLocacao = table.Column<string>(type: "text", nullable: false),
                    QuilometragemInicial = table.Column<decimal>(type: "numeric", nullable: false),
                    QuilometragemFinal = table.Column<decimal>(type: "numeric", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Observacoes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocacoesVeiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocacoesVeiculos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocacoesVeiculos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManutencoesVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VeiculoId = table.Column<int>(type: "integer", nullable: false),
                    DataManutencao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TipoManutencao = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Custo = table.Column<decimal>(type: "numeric", nullable: false),
                    Quilometragem = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManutencoesVeiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManutencoesVeiculos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VeiculoId = table.Column<int>(type: "integer", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    DataReserva = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataFim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatusReserva = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CpfCnpj",
                table: "Clientes",
                column: "CpfCnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DadosCaminhoes_VeiculoId",
                table: "DadosCaminhoes",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_DadosLocalizacaoOperacoes_VeiculoId",
                table: "DadosLocalizacaoOperacoes",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_DadosMotos_VeiculoId",
                table: "DadosMotos",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_DadosSegurancaConformidades_VeiculoId",
                table: "DadosSegurancaConformidades",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_DadosTecnicosVeiculos_VeiculoId",
                table: "DadosTecnicosVeiculos",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosDigitalizados_VeiculoId",
                table: "DocumentosDigitalizados",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_FotosVeiculos_VeiculoId",
                table: "FotosVeiculos",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_LocacoesVeiculos_ClienteId",
                table: "LocacoesVeiculos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_LocacoesVeiculos_VeiculoId",
                table: "LocacoesVeiculos",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_ManutencoesVeiculos_VeiculoId",
                table: "ManutencoesVeiculos",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ClienteId",
                table: "Reservas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_VeiculoId",
                table: "Reservas",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_Placa",
                table: "Veiculos",
                column: "Placa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosCaminhoes");

            migrationBuilder.DropTable(
                name: "DadosLocalizacaoOperacoes");

            migrationBuilder.DropTable(
                name: "DadosMotos");

            migrationBuilder.DropTable(
                name: "DadosSegurancaConformidades");

            migrationBuilder.DropTable(
                name: "DadosTecnicosVeiculos");

            migrationBuilder.DropTable(
                name: "DocumentosDigitalizados");

            migrationBuilder.DropTable(
                name: "FotosVeiculos");

            migrationBuilder.DropTable(
                name: "LocacoesVeiculos");

            migrationBuilder.DropTable(
                name: "ManutencoesVeiculos");

            migrationBuilder.DropTable(
                name: "RegrasDescontoJuros");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ValoresLocacao");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
