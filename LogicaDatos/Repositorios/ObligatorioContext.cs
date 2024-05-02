using LogicaNegocio.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios {
    public class ObligatorioContext : DbContext {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Articulo> Articulos { get; set; }

        public ObligatorioContext(DbContextOptions options) : base(options) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Articulo>().ToTable("Articulos");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Cliente>().OwnsOne(
                c => c.Direccion, d => { 
                    d.OwnsOne(c => c.Calle);
                    d.OwnsOne(n => n.NumeroPuerta);
                    d.OwnsOne(ci => ci.Ciudad);
                }); 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(
            //    "Data Source=localhost\\SQLEXPRESS; Initial Catalog=ObligatorioP3; Integrated Security=SSPI;TrustServerCertificate=True"
            //);
        } 
        //TODO https://learn.microsoft.com/en-us/ef/core/modeling/owned-entities#configuring-owned-types
    }
}
