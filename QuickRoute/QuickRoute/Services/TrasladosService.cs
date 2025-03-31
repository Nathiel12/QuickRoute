using System.Linq.Expressions;
using QuickRoute.Data.Models;
using QuickRoute.Data;
using Microsoft.EntityFrameworkCore;

namespace QuickRoute.Services
{
    public class TrasladosService(IDbContextFactory<ApplicationDbContext> DbFactory)

    {
        public async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Traslados.AnyAsync(t => t.TrasladoId == id);
        }

        public async Task<bool> Guardar(Traslados traslado)
        {
            if (!await Existe(traslado.TrasladoId))
                return await Insertar(traslado);
            else
                return await Modificar(traslado);
        }

        public async Task<bool> Insertar(Traslados traslado)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Traslados.Add(traslado);

            var carro = await contexto.Carros.FindAsync(traslado.Id);
            if (carro != null)
            {
                carro.Precio += traslado.Monto;
            }

            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Traslados trasladoActualizado)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            var trasladoExistente = await contexto.Traslados
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TrasladoId == trasladoActualizado.TrasladoId);

            if (trasladoExistente == null)
                return false;

            var carroOriginal = await contexto.Carros.FindAsync(trasladoExistente.Id);
            if (carroOriginal != null)
            {
                carroOriginal.Precio -= trasladoExistente.Monto;
            }

            var carroNuevo = await contexto.Carros.FindAsync(trasladoActualizado.Id);
            if (carroNuevo != null)
            {
                carroNuevo.Precio += trasladoActualizado.Monto;
            }

            contexto.Entry(trasladoActualizado).State = EntityState.Modified;

            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Traslados?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Traslados
                .Include(t => t.Carros)
                .Include(t => t.Usuario)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TrasladoId == id);
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var traslado = await contexto.Traslados.FirstOrDefaultAsync(t => t.TrasladoId == id);
            if (traslado == null)
                return false;

            var carro = await contexto.Carros.FindAsync(traslado.Id);
            if (carro != null)
            {
                carro.Precio -= traslado.Monto;
            }

            contexto.Traslados.Remove(traslado);
            return await contexto.SaveChangesAsync() > 0;
        }
        public async Task<List<Traslados>> Listar(Expression<Func<Traslados, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Traslados
                .Include(t => t.Carros)
                .Include(t => t.Usuario)
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
