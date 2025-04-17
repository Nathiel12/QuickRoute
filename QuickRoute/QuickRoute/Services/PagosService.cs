using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuickRoute.Data;
using QuickRoute.Data.Models;

namespace QuickRoute.Services
{
    public class PagosService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<bool> Guardar(Pagos pagos)
        {
            if (!await Existe(pagos.PagoId))
            {
                return await Insertar(pagos);
            }
            else
            {
                return await Modificar(pagos);
            }
        }

        private async Task<bool> Existe(int pagosId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Pagos.AnyAsync(p => p.PagoId == pagosId);
        }

        private async Task<bool> Insertar(Pagos pagos)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Pagos.Add(pagos);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Pagos pagos)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(pagos);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Pagos?> Buscar(int pagoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Pagos.FirstOrDefaultAsync(p => p.PagoId == pagoId);
        }
        public async Task<List<Pagos>> Listar(Expression<Func<Pagos, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Pagos.Where(criterio).AsNoTracking().ToListAsync();
        }
    }
}
