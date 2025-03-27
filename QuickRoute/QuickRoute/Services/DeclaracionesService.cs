using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuickRoute.Data;
using QuickRoute.Data.Models;

namespace QuickRoute.Services
{
    public class DeclaracionesService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<bool> Guardar(Declaraciones declaracion)
        {
            if (!await Existe(declaracion.DeclaracionId))
            {
                return await Insertar(declaracion);
            }
            else
            {
                return await Modificar(declaracion);
            }
        }

        public async Task<bool> Existe(int DeclaracionId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Declaraciones.AnyAsync(d => d.DeclaracionId == DeclaracionId);
        }

        private async Task<bool> Insertar(Declaraciones declaracion)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Declaraciones.Add(declaracion);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Declaraciones declaracion)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(declaracion);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Declaraciones?> Buscar(int DeclaracionId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Declaraciones.FirstOrDefaultAsync(d => d.DeclaracionId == DeclaracionId);
        }

        public async Task<bool> Eliminar(int DeclaracionId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Declaraciones.AsNoTracking().Where(d => d.DeclaracionId == DeclaracionId).ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Declaraciones>> Listar(Expression<Func<Declaraciones, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Declaraciones.Where(criterio).AsNoTracking().ToListAsync();
        }
    }
}
