using LogicaNegocio.Dominio;
using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaDatos.Repositorios {
    public class ObligatorioContext : DbContext {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoExpress> PedidoExpress { get; set; }
        public DbSet<PedidoComun> PedidoComun { get; set; }
        public DbSet<Linea> Lineas { get; set; }
        public DbSet<Parametro> Parametros { get; set; }

        public ObligatorioContext(DbContextOptions options) : base(options) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Articulo>().ToTable("Articulos");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Pedido>().ToTable("Pedidos");
            modelBuilder.Entity<Linea>().ToTable("Lineas");
            modelBuilder.Entity<Parametro>().ToTable("Parametros");

            //--------------------------------------------------------------------------
            //---------------------------- TEST DATA -----------------------------------
            //--------------------------------------------------------------------------
            modelBuilder.Entity<Cliente>(builder => {
            builder.OwnsOne(d => d.Direccion, direccion => {
                direccion.OwnsOne(ca => ca.Calle, calle => {
                    calle.HasData(
                            new { Valor = "Ciudadela", DireccionId = 1 },
                            new { Valor = "Reconquista", DireccionId = 2 },
                            new { Valor = "Durazno", DireccionId = 3 },
                            new { Valor = "San Jose", DireccionId = 4 },
                            new { Valor = "Maldonado", DireccionId = 5 },
                            new { Valor = "Canelones", DireccionId = 6 }
                        );
                });
                direccion.OwnsOne(n => n.NumeroPuerta, numero => {
                    numero.HasData(
                            new { Valor = "1180", DireccionId = 1 },
                            new { Valor = "600", DireccionId = 2 },
                            new { Valor = "902", DireccionId = 3 },
                            new { Valor = "1060", DireccionId = 4 },
                            new { Valor = "2010", DireccionId = 5 },
                            new { Valor = "1110", DireccionId = 6 }
                        );
                });
                direccion.OwnsOne(ci => ci.Ciudad, ciudad => {
                    ciudad.HasData(
                            new { Valor = "Montevideo", DireccionId = 1 },
                            new { Valor = "Montevideo", DireccionId = 2 },
                            new { Valor = "Montevideo", DireccionId = 3 },
                            new { Valor = "Montevideo", DireccionId = 4 },
                            new { Valor = "Montevideo", DireccionId = 5 },
                            new { Valor = "Montevideo", DireccionId = 6 }
                        );
                });
                direccion.HasData(
                    new { ClienteId = 1 },
                    new { ClienteId = 2 },
                    new { ClienteId = 3 },
                    new { ClienteId = 4 },
                    new { ClienteId = 5 },
                    new { ClienteId = 6 }
                );

            });
            builder.HasData(
                    new Cliente { Id = 1, RazonSocial = "Fleetium Macs", Rut = "123456789012", DistanciaHastaDeposito = 98 },
                    new Cliente { Id = 2, RazonSocial = "Pink Folks", Rut = "987654321098", DistanciaHastaDeposito = 101 },
                    new Cliente { Id = 3, RazonSocial = "Thurston & Kim Co.", Rut = "111222333444", DistanciaHastaDeposito = 96 },
                    new Cliente { Id = 4, RazonSocial = "Nueva Helvecia Dolls", Rut = "111222333555", DistanciaHastaDeposito = 94 },
                    new Cliente { Id = 5, RazonSocial = "Fenix", Rut = "111222333666", DistanciaHastaDeposito = 82 },
                    new Cliente { Id = 6, RazonSocial = "AB/CD", Rut = "111222333777", DistanciaHastaDeposito = 91 }
                );
            });
            
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Email = "admin@admin.com", Nombre = "Sys", Apellido = "Admin", Contraseña = "Passw0rd!", Tipo = TipoUsuario.Administrador },
                new Usuario { Id = 2, Email = "rplanta@lz.com", Nombre = "Roberto", Apellido = "Planta", Contraseña = "Passw0rd!", Tipo = TipoUsuario.Estandar },
                new Usuario { Id = 2, Email = "jblanco@tws.com", Nombre = "Jacobo", Apellido = "Blanco", Contraseña = "Passw0rd!", Tipo = TipoUsuario.Encargado }
            );

            modelBuilder.Entity<Articulo>().HasData(
                new Articulo { Id = 1, Nombre = "Calculadora Casio", Descripcion = "Calculadora de bolsillo Casio", CodigoProveedor = "1234567890123", Precio = 300, Stock = 10 },
                new Articulo { Id = 2, Nombre = "Resma A4", Descripcion = "500 hojas para imprimir en formato A4", CodigoProveedor = "1234567890124", Precio = 250, Stock = 50 },
                new Articulo { Id = 3, Nombre = "Auriculares con Micrófono", Descripcion = "Bluetooth o conexión USB, cable desmontable", CodigoProveedor = "1234567890125", Precio = 500, Stock = 40 },
                new Articulo { Id = 4, Nombre = "Silla De Escritorio", Descripcion = "Soporte lumbar, altura ajustable y base giratoria con ruedas", CodigoProveedor = "1234567890126", Precio = 3200, Stock = 20 },
                new Articulo { Id = 5, Nombre = "Notas Adhesivas", Descripcion = "Block de notas autoadhesivas", CodigoProveedor = "1234597890124", Precio = 50, Stock = 100 },
                new Articulo { Id = 6, Nombre = "Bandas Elásticas", Descripcion = "100 unidades", CodigoProveedor = "1274597890124", Precio = 150, Stock = 90 },
                new Articulo { Id = 7, Nombre = "Engrampadora", Descripcion = "Hasta 100 hojas", CodigoProveedor = "1834597890124", Precio = 800, Stock = 10 },
                new Articulo { Id = 8, Nombre = "Cable HDMI", Descripcion = "HD, FullHD y 4K", CodigoProveedor = "1236597890124", Precio = 200, Stock = 10 }

            );

            modelBuilder.Entity<Parametro>().HasData(
                new Parametro { Id = 1, Nombre = "IVA", Valor = 0.18M },
                new Parametro { Id = 2, Nombre = "RecargoComun_DistanciaMayor100", Valor = 0.05M },
                new Parametro { Id = 3, Nombre = "RecargoComun_DistanciaMenor100", Valor = 0 },
                new Parametro { Id = 4, Nombre = "RecargoExpress_Plazo1Dia", Valor = 0.15M },
                new Parametro { Id = 5, Nombre = "RecargoExpress_PlazoMayor1Dia", Valor = 0.10M }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(
            //    "Data Source=localhost\\SQLEXPRESS; Initial Catalog=ObligatorioProg3; Integrated Security=SSPI;TrustServerCertificate=True"
            //);
        } 
    }
    // Owned types https://learn.microsoft.com/en-us/ef/core/modeling/owned-entities#configuring-owned-types
    // Data Seeding https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding
    // Seeding Owned https://github.com/dotnet/efcore/issues/32746
}
