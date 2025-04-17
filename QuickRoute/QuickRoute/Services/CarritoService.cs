using QuickRoute.Data;
using QuickRoute.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
 
namespace QuickRoute.Services
{
    public class CarritoService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;
 
        public CarritoService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }
 
        public async Task<bool> AgregarAlCarrito(int carroId, string userId, int cantidad = 1)
        {
            if (string.IsNullOrEmpty(userId)) return false;
 
            await using var context = await _dbFactory.CreateDbContextAsync();
 
            var itemExistente = await context.Carrito
                .FirstOrDefaultAsync(c => c.Id == userId && c.CarroId == carroId);
 
            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                var nuevoItem = new Carrito
                {
                    Id = userId,
                    CarroId = carroId,
                    Cantidad = cantidad
                };
                context.Carrito.Add(nuevoItem);
            }
 
            return await context.SaveChangesAsync() > 0;
        }
 
        public async Task<List<Carrito>> ObtenerCarritoUsuario(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return new List<Carrito>();
 
            await using var context = await _dbFactory.CreateDbContextAsync();
            return await context.Carrito
                .Where(c => c.Id == userId)
                .Include(c => c.Carro)
                .OrderByDescending(c => c.FechaAgregado)
                .ToListAsync();
        }
 
        public async Task<bool> EliminarDelCarrito(int carritoId, string userId)
        {
            if (string.IsNullOrEmpty(userId)) return false;
 
            await using var context = await _dbFactory.CreateDbContextAsync();
            var item = await context.Carrito
                .FirstOrDefaultAsync(c => c.CarritoId == carritoId && c.Id == userId);
 
            if (item == null) return false;
 
            context.Carrito.Remove(item);
            return await context.SaveChangesAsync() > 0;
        }
 
        public async Task<bool> ActualizarCantidad(int carritoId, int nuevaCantidad, string userId)
        {
            if (nuevaCantidad < 1 || string.IsNullOrEmpty(userId)) return false;
 
            await using var context = await _dbFactory.CreateDbContextAsync();
            var item = await context.Carrito
                .Include(c => c.Carro)
                .FirstOrDefaultAsync(c => c.CarritoId == carritoId && c.Id == userId);
 
            if (item == null) return false;
 
            // Validar stock
            if (nuevaCantidad > item.Carro.CantidadStock) return false;
 
            item.Cantidad = nuevaCantidad;
            return await context.SaveChangesAsync() > 0;
        }
        
        public async Task<decimal> ObtenerTotalCarrito(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return 0;
 
            await using var context = await _dbFactory.CreateDbContextAsync();
            var items = await context.Carrito
                .Where(c => c.Id == userId)
                .Include(c => c.Carro)
                .ToListAsync();
 
            return items.Sum(i => i.Cantidad * (decimal)i.Carro.Precio);
        }
    }
}