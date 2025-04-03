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
            if (!await Existe(carro.CarroId))
            {
                return await Insertar(carro);
            }
            else
            {
                return await Modificar(carro);
            }
        }
        private string GetCurrentUserId()
        {
            return httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        private bool IsAdmin()
        {
            return httpContextAccessor.HttpContext?.User?.IsInRole("Admin") ?? false;
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
            return await contexto.Carros.Include(t=> t.Traslado).FirstOrDefaultAsync(c => c.CarroId == CarroId);
        }

        //Agregar validacion en el futuro si el carro esta en proceso de traslado no se puede eliminar
        public async Task<bool> Eliminar(int CarroId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            var carro = await contexto.Carros
                .Include(t => t.Traslado)
                .FirstOrDefaultAsync(p => p.CarroId == CarroId);

            if (carro == null)
                return false;

            contexto.Traslados.RemoveRange(carro.Traslado);

            contexto.Carros.Remove(carro);

            var cantidad = await contexto.SaveChangesAsync();

            return cantidad > 0;
        }

        public async Task<List<Carros>> Listar(Expression<Func<Carros, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Carros.Where(criterio).AsNoTracking().ToListAsync();
        }

        public async Task<bool> EliminarDetalle(int detalleId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var detalle = await contexto.Traslados.FindAsync(detalleId);

            if (detalle != null)
            {
                contexto.Traslados.Remove(detalle);
                await contexto.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> AprobarCarro(int carroId)
        {
            if (!IsAdmin()) throw new UnauthorizedAccessException("Solo administradores pueden aprobar carros");

            await using var contexto = await DbFactory.CreateDbContextAsync();
            var carro = await contexto.Carros.FindAsync(carroId);

            if (carro == null) return false;

            carro.Aprobado = true;
            contexto.Update(carro);
            return await contexto.SaveChangesAsync() > 0;
        }
        public async Task<List<Carros>> ListarSegunPermisos(bool incluirNoAprobados = false)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var query = contexto.Carros.AsQueryable();

            if (!IsAdmin())
            {
                var userId = GetCurrentUserId();
                query = query.Where(c => c.Id == userId);

                if (!incluirNoAprobados)
                {
                    query = query.Where(c => c.Aprobado);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }
    }
}
