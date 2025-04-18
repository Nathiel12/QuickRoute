using System.Linq.Expressions;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using QuickRoute.Data;
using QuickRoute.Data.Models;

namespace QuickRoute.Services
{
    public class DireccionesService(IDbContextFactory<ApplicationDbContext> DbFactory, IHttpContextAccessor httpContextAccessor)
    {
        public async Task<bool> Guardar(Direccion direccion)
        {
            var userId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!await Existe(direccion.DireccionId))
            {
                direccion.Id = userId;
                return await Insertar(direccion);
            }
            else
            {
                return await Modificar(direccion);
            }
        }

        private async Task<bool> Existe(int direccionId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Direcciones.AnyAsync(d => d.DireccionId == direccionId);
        }

        private async Task<bool> Insertar(Direccion direccion)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Direcciones.Add(direccion);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Direccion direccion)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(direccion);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Direccion?> Buscar(int direccionId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Direcciones.FirstOrDefaultAsync(d => d.DireccionId == direccionId);
        }
        public async Task<List<Direccion>> Listar(Expression<Func<Direccion, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Direcciones.Where(criterio).Include(d => d.Usuario).AsNoTracking().ToListAsync();
        }
        public async Task<bool> Eliminar(int direccionId)
        {
            await using var Contexto = await DbFactory.CreateDbContextAsync();
            return await Contexto.Direcciones.AsNoTracking().Where(d => d.DireccionId == direccionId).ExecuteDeleteAsync() > 0;
        }

    }
}
