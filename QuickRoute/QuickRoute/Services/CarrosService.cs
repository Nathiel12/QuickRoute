using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuickRoute.Data;
using QuickRoute.Data.Models;

namespace QuickRoute.Services
{
    public class CarrosService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<bool> Guardar(Carros carro)
        {
            if (!await Existe(carro.CarroId))
            {
                return await Insertar(carro);
            }
            else
            {
                return await Modificar(carro);
            }
        }

        public async Task<bool> Existe(int CarroId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Carros.AnyAsync(c => c.CarroId == CarroId);
        }

        private async Task<bool> Insertar(Carros carro)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Carros.Add(carro);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Carros carro)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(carro);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Carros?> Buscar(int CarroId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Carros.FirstOrDefaultAsync(c => c.CarroId == CarroId);
        }

        public async Task<bool> Eliminar(int CarroId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Carros.AsNoTracking().Where(c => c.CarroId == CarroId).ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Carros>> Listar(Expression<Func<Carros, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Carros.Where(criterio).AsNoTracking().ToListAsync();
        }
    }
}
