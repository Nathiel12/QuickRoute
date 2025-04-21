using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuickRoute.Data;
using QuickRoute.Data.Models;

namespace QuickRoute.Services
{
    public class TipoVehiculosService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<List<TipoVehiculos>> Listar(Expression<Func<TipoVehiculos, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TipoVehiculos.Where(criterio).AsNoTracking().ToListAsync();
        }
    }
}
