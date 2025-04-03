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

            foreach (var detalle in traslado.TrasladosDetalles)
            {
                var carro = await contexto.Carros.FindAsync(detalle.CarroId);
                if (carro != null)
                {
                    carro.Precio += detalle.Monto;
                }
            }

            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Traslados trasladoActualizado)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            var trasladoExistente = await contexto.Traslados
                .Include(t => t.TrasladosDetalles)
                .FirstOrDefaultAsync(t => t.TrasladoId == trasladoActualizado.TrasladoId);

            if (trasladoExistente == null)
                return false;

            foreach (var detalleNew in trasladoActualizado.TrasladosDetalles)
            {
                var detalleOG = trasladoExistente.TrasladosDetalles.FirstOrDefault(d => d.DetalleId == detalleNew.DetalleId);
                if (detalleOG != null)
                {
                    var carro = await contexto.Carros.FindAsync(detalleNew.CarroId);
                    if (carro != null)
                        carro.Precio += (detalleNew.Monto - detalleOG.Monto);

                    contexto.Entry(detalleOG).CurrentValues.SetValues(detalleNew);
                }
                else
                {
                    trasladoExistente.TrasladosDetalles.Add(detalleNew);
                    var carro = await contexto.Carros.FindAsync(detalleNew.CarroId);
                    if (carro != null)
                        carro.Precio += detalleNew.Monto;
                }
            }

            foreach (var detalleOG in trasladoExistente.TrasladosDetalles.ToList())
            {
                bool existe = trasladoActualizado.TrasladosDetalles.Any(d => d.DetalleId == detalleOG.DetalleId);
                if (!existe)
                {
                    var carro = await contexto.Carros.FindAsync(detalleOG.CarroId);
                    if (carro != null)
                        carro.Precio -= detalleOG.Monto;
                    trasladoExistente.TrasladosDetalles.Remove(detalleOG);
                }
            }

            contexto.Entry(trasladoExistente).CurrentValues.SetValues(trasladoActualizado);

            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Traslados?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Traslados
                .Where(t => t.TrasladoId == id)
                .Include(t => t.TrasladosDetalles)
                .ThenInclude(d => d.Carro)
                .Include(t => t.Usuario)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var traslado = await contexto.Traslados
                .Include(t => t.TrasladosDetalles)
                .FirstOrDefaultAsync(t => t.TrasladoId == id);

            if (traslado == null)
                return false;

            foreach (var detalle in traslado.TrasladosDetalles)
            {
                var carro = await contexto.Carros.FindAsync(detalle.CarroId);
                if (carro != null)
                    carro.Precio -= detalle.Monto;
            }

            contexto.Traslados.Remove(traslado);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<List<Traslados>> Listar(Expression<Func<Traslados, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Traslados
                .Include(t => t.TrasladosDetalles)
                .ThenInclude(d => d.Carro)
                .Include(t => t.Usuario)
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}