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
                            new { Valor = "Durazno", DireccionId = 3 }
                        );
                });
                direccion.OwnsOne(n => n.NumeroPuerta, numero => {
                    numero.HasData(
                            new { Valor = "1180", DireccionId = 1 },
                            new { Valor = "600", DireccionId = 2 },
                            new { Valor = "902", DireccionId = 3 }
                        );
                });
                direccion.OwnsOne(ci => ci.Ciudad, ciudad => {
                    ciudad.HasData(
                            new { Valor = "Montevideo", DireccionId = 1 },
                            new { Valor = "Montevideo", DireccionId = 2 },
                            new { Valor = "Montevideo", DireccionId = 3 }
                        );
                });
                direccion.HasData(
                    new { ClienteId = 1 },
                    new { ClienteId = 2 },
                    new { ClienteId = 3 }
                );

            });
            builder.HasData(
                    new Cliente { Id = 1, RazonSocial = "PF", Rut = "123456789012", DistanciaHastaDeposito = 98 },
                    new Cliente { Id = 2, RazonSocial = "LZ", Rut = "987654321098", DistanciaHastaDeposito = 101 },
                    new Cliente { Id = 3, RazonSocial = "TWS", Rut = "111222333444", DistanciaHastaDeposito = 96 }
                );
            });
            
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Email = "admin@admin.com", Nombre = "Sys", Apellido = "Admin", Contraseña = "Passw0rd!", Tipo = TipoUsuario.Administrador },
                new Usuario { Id = 2, Email = "rplanta@lz.com", Nombre = "Roberto", Apellido = "Planta", Contraseña = "Passw0rd!", Tipo = TipoUsuario.Estandar }
            );

            modelBuilder.Entity<Articulo>().HasData(
                new Articulo { Id = 1, Nombre = "Calculadora Casio", Descripcion = "Calculadora de bolsillo Casio", CodigoProveedor = "1234567890123", Precio = 300, Stock = 10 },
                new Articulo { Id = 2, Nombre = "Resma A4", Descripcion = "500 hojas para imprimir en formato A4", CodigoProveedor = "1234567890124", Precio = 250, Stock = 50 },
                new Articulo { Id = 3, Nombre = "Auriculares con Micrófono", Descripcion = "Bluetooth o conexión USB, cable desmontable", CodigoProveedor = "1234567890125", Precio = 500, Stock = 40 },
                new Articulo { Id = 4, Nombre = "Silla De Escritorio", Descripcion = "Soporte lumbar, altura ajustable y base giratoria con ruedas", CodigoProveedor = "1234567890126", Precio = 3200, Stock = 20 }
            );

            modelBuilder.Entity<Parametro>().HasData(
                new Parametro { Id = 1, Nombre = "IVA", Valor = 0.18M }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(
            //    "Data Source=localhost\\SQLEXPRESS; Initial Catalog=ObligatorioP3; Integrated Security=SSPI;TrustServerCertificate=True"
            //);
        } 
    }
    // Owned types https://learn.microsoft.com/en-us/ef/core/modeling/owned-entities#configuring-owned-types
    // Data Seeding https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding
    // Seeding Owned https://github.com/dotnet/efcore/issues/32746
}
