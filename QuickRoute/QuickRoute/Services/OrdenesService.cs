using Microsoft.EntityFrameworkCore;
using QuickRoute.Data;
using QuickRoute.Data.Models;

namespace QuickRoute.Services
{
    public class OrdenesService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<Ordenes> CrearOrden(List<OrdenDetalle> detalles, string usuarioId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();

            double total = detalles.Sum(d => d.PrecioUnitario * d.Cantidad);

            var nuevaOrden = new Ordenes
            {
                Id = usuarioId,
                FechaOrden = DateTime.Now,
                Total = total,
                Estado = "Pendiente",
                Detalles = detalles
            };

            foreach (var detalle in detalles)
            {
                var carro = await context.Carros.FindAsync(detalle.CarroId);
                if (carro != null)
                {
                    carro.CantidadStock -= detalle.Cantidad;
                }
            }

            context.Ordenes.Add(nuevaOrden);
            await context.SaveChangesAsync();

            return nuevaOrden;
        }
        public async Task<bool> CancelarOrden(int ordenId, string usuarioId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var orden = await context.Ordenes
                .Include(o => o.Detalles)
                    .ThenInclude(d => d.Carro) 
                .FirstOrDefaultAsync(o => o.OrdenId == ordenId && o.Id == usuarioId);

            if (orden == null)
            {
                return false;
            }
            foreach (var detalle in orden.Detalles)
            {
                if (detalle.Carro != null)
                {
                    detalle.Carro.CantidadStock += detalle.Cantidad;

                    if (!detalle.Carro.Disponibilidad && detalle.Carro.CantidadStock > 0)
                    {
                        detalle.Carro.Disponibilidad = true;
                    }
                }
            }

            orden.Estado = "Cancelada";
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Ordenes>> ObtenerOrdenesPorUsuario(string usuarioId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Ordenes
                .Where(o => o.Id == usuarioId)
                .Include(o => o.Detalles)
                    .ThenInclude(d => d.Carro)
                .OrderByDescending(o => o.FechaOrden)
                .ToListAsync();
        }
        public async Task<Ordenes> ObtenerOrdenDetallada(int ordenId, string usuarioId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Ordenes
                .Include(o => o.Detalles)
                    .ThenInclude(d => d.Carro)
                .FirstOrDefaultAsync(o => o.OrdenId == ordenId && o.Id == usuarioId);
        }
    }
}
