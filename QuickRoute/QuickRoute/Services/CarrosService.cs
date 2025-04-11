using System.Linq.Expressions;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using QuickRoute.Data;
using QuickRoute.Data.Models;

namespace QuickRoute.Services
{
    public class CarrosService(IDbContextFactory<ApplicationDbContext> DbFactory, IHttpContextAccessor httpContextAccessor)
    {
        public async Task<bool> Guardar(Carros carro)
        {
            await using var context = await DbFactory.CreateDbContextAsync();

            if (carro.CarroId == 0) 
            {
                carro.Disponibilidad = true; 
                context.Carros.Add(carro);
            }
            else 
            {
                context.Carros.Update(carro);
            }

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<Carros?> ObtenerProducto(int carroId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Carros
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CarroId == carroId);
        }

       
        public async Task<bool> DesactivarProducto(int carroId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var carro = await context.Carros.FindAsync(carroId);

            if (carro == null) return false;

            carro.Disponibilidad = false;
            context.Carros.Update(carro);

            return await context.SaveChangesAsync() > 0;
        }

       
        public async Task<List<Carros>> ListarProductos(bool soloDisponibles = true)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var query = context.Carros.AsQueryable();

            if (soloDisponibles)
            {
                query = query.Where(c => c.Disponibilidad && c.CantidadStock > 0);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<bool> ActualizarStock(int carroId, int cantidad)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var carro = await context.Carros.FindAsync(carroId);

            if (carro == null) return false;

            carro.CantidadStock += cantidad; 

            if (carro.CantidadStock <= 0)
            {
                carro.CantidadStock = 0;
                carro.Disponibilidad = false;
            }
            else if (!carro.Disponibilidad)
            {
                carro.Disponibilidad = true; 
            }

            return await context.SaveChangesAsync() > 0;
        }
    }
}
