using QuickRoute.Data;
using QuickRoute.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace QuickRoute.Services
{
    public class CarritoService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;
        
        // Evento para notificar cambios en el carrito
        public event Action OnCarritoChanged;

        public CarritoService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        private void NotificarCambio()
        {
            OnCarritoChanged?.Invoke();
        }

        public async Task<bool> AgregarAlCarrito(int carroId, string userId, int cantidad = 1)
        {
            await using var context = await _dbFactory.CreateDbContextAsync();

            var itemExistente = await context.Carrito
                .FirstOrDefaultAsync(c => c.Id == userId && c.CarroId == carroId);

            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                context.Carrito.Add(new Carrito
                {
                    Id = userId,
                    CarroId = carroId,
                    Cantidad = cantidad,
                    FechaAgregado = DateTime.Now
                });
            }
            
            var result = await context.SaveChangesAsync() > 0;
            if (result) NotificarCambio();
            return result;
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
            var result = await context.SaveChangesAsync() > 0;
            if (result) NotificarCambio();
            return result;
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
            var result = await context.SaveChangesAsync() > 0;
            if (result) NotificarCambio();
            return result;
        }
        
        public async Task<double> ObtenerTotalCarrito(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return 0;

            await using var context = await _dbFactory.CreateDbContextAsync();
            var items = await context.Carrito
                .Where(c => c.Id == userId)
                .Include(c => c.Carro)
                .ToListAsync();

            return items.Sum(i => i.Cantidad * (double)i.Carro.Precio);
        }

        public async Task<bool> VaciarCarrito(string userId)
        {
            await using var context = await _dbFactory.CreateDbContextAsync();
            var items = await context.Carrito
                .Where(c => c.Id == userId)
                .ToListAsync();

            if (!items.Any()) return true;

            context.Carrito.RemoveRange(items);
            var result = await context.SaveChangesAsync() > 0;
            if (result) NotificarCambio();
            return result;
        }

        public async Task<int> ObtenerCantidadTotalItems(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return 0;

            await using var context = await _dbFactory.CreateDbContextAsync();
            var items = await context.Carrito
                .Where(c => c.Id == userId)
                .ToListAsync();

            return items.Sum(i => i.Cantidad);
        }
    }
}