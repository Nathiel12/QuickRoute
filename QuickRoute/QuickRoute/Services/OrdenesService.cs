using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuickRoute.Data;
using QuickRoute.Data.Models;

namespace QuickRoute.Services
{
    public class OrdenesService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<int> CrearOrdenDesdeCarrito(string userId, double total)
        {
            await using var context = await DbFactory.CreateDbContextAsync();

            var itemsCarrito = await context.Carrito
                .Where(c => c.Id == userId)
                .Include(c => c.Carro)
                .ToListAsync();

            if (!itemsCarrito.Any()) return 0;

            var orden = new Ordenes
            {
                Id = userId,
                FechaOrden = DateTime.Now,
                Total = total,
                Detalles = itemsCarrito.Select(i => new OrdenDetalle
                {
                    CarroId = i.CarroId,
                    Cantidad = i.Cantidad,
                    PrecioUnitario = i.Carro.Precio
                }).ToList()
            };
            foreach (var item in itemsCarrito)
            {
                item.Carro.CantidadStock -= item.Cantidad;
            }

            context.Ordenes.Add(orden);
            await context.SaveChangesAsync();

            return orden.OrdenId; // Retorna el ID generado
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

            orden.Pagada = false;
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Ordenes>> Listar(Expression<Func<Ordenes, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Ordenes
                .Where(criterio)
                .Include(o => o.Detalles) // Asegura cargar los detalles
                .AsNoTracking()
                .ToListAsync();
        }
        /**public async Task<List<Ordenes>> ObtenerOrdenesPorUsuario(string usuarioId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Ordenes
                .Where(o => o.Id == usuarioId)
                .Include(o => o.Detalles)
                    .ThenInclude(d => d.Carro)
                .OrderByDescending(o => o.FechaOrden)
                .ToListAsync();
        }**/
        public async Task<Ordenes> ObtenerOrdenDetallada(int ordenId, string usuarioId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Ordenes
                .Include(o => o.Detalles)
                    .ThenInclude(d => d.Carro)
                .FirstOrDefaultAsync(o => o.OrdenId == ordenId && o.Id == usuarioId);
        }
        /**public async Task<Ordenes?> ObtenerOrdenActivaPorUsuario(string userId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Ordenes
                .FirstOrDefaultAsync(o => o.Id == userId && !o.Pagada);
        }**/
    }
}
