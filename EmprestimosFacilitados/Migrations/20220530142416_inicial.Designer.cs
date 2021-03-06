// <auto-generated />
using EmprestimosFacilitados.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmprestimosFacilitados.Migrations
{
    [DbContext(typeof(EmprestimosFacilitadosContext))]
    [Migration("20220530142416_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmprestimosFacilitados.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("RendaMensal")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("EmprestimosFacilitados.Models.MeuEmprestimo", b =>
                {
                    b.Property<int>("MeuEmprestimoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeuEmprestimoId"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("TipoEmprestimoId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorEmprestado")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorTotalQueSerapago")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("MeuEmprestimoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoEmprestimoId");

                    b.ToTable("MeusEmprestimos");
                });

            modelBuilder.Entity("EmprestimosFacilitados.Models.TipoEmprestimo", b =>
                {
                    b.Property<int>("TipoEmprestimoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoEmprestimoId"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Juros")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("QuantidadeMeses")
                        .HasColumnType("int");

                    b.HasKey("TipoEmprestimoId");

                    b.ToTable("TiposEmprestimos");
                });

            modelBuilder.Entity("EmprestimosFacilitados.Models.MeuEmprestimo", b =>
                {
                    b.HasOne("EmprestimosFacilitados.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmprestimosFacilitados.Models.TipoEmprestimo", "TipoEmprestimo")
                        .WithMany()
                        .HasForeignKey("TipoEmprestimoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("TipoEmprestimo");
                });
#pragma warning restore 612, 618
        }
    }
}
