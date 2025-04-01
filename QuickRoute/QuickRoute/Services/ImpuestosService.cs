using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuickRoute.Data;
using QuickRoute.Data.Models;

namespace QuickRoute.Services
{
    public class ImpuestosService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<List<Impuestos>> Listar(Expression<Func<Impuestos, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Impuestos
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Impuestos> Buscar(int impuestoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Impuestos
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.ImpuestoId == impuestoId);
        }
    }
}
