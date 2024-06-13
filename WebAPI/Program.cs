using DataTransferObjects;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<ICUOrdenarArticulosAsc, CUOrdenarArticulosAsc>();
            builder.Services.AddScoped<ICUOrdenarPedidosAnuladosDesc, CUOrdenarPedidosAnuladosDesc>();

            builder.Services.AddScoped<IRepositorioArticulos, RepositorioArticulos>();
            builder.Services.AddScoped<IRepositorioPedidos, RepositorioPedidos>();

            builder.Services.AddScoped<ICUAlta<TipoMovimientoDTO>, CUAltaTipoMovimiento>();
            builder.Services.AddScoped<ICUBaja<TipoMovimientoDTO>, CUBajaTipoMovimiento>();
            builder.Services.AddScoped<ICUListado<TipoMovimientoDTO>, CUListadoTiposMovimientos>();
            builder.Services.AddScoped<ICUModificar<TipoMovimientoDTO>, CUModificarTipoMovimiento>();
            builder.Services.AddScoped<ICUBuscarPorId<TipoMovimientoDTO>, CUBuscarPorIdTipoMovimiento>();

            builder.Services.AddScoped<ICUAlta<MovimientoStockDTO>, CUAltaMovimientoStock>();
            builder.Services.AddScoped<ICUListado<MovimientoStockDTO>, CUListadoMovimientosStock>();
            builder.Services.AddScoped<ICUBuscarPorId<MovimientoStockDTO>, CUBuscarPorIdMovimientoStock>();

            string conStr = builder.Configuration.GetConnectionString("Caro-Zenbook");
            builder.Services.AddDbContext<ObligatorioContext>(options => options.UseSqlServer(conStr));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
