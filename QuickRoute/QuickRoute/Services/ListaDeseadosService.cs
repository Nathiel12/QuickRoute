using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuickRoute.Data;
using QuickRoute.Data.Models;

namespace QuickRoute.Services
{
    public class ListaDeseadosService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<bool> AgregarALista(string usuarioId, int carroId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            
            // Verificar si ya existe en la lista
            var existe = await context.ListaDeseados
                .AnyAsync(ld => ld.UsuarioId == usuarioId && ld.CarroId == carroId);
                
            if (existe) return false;
            
            var item = new ListaDeseados
            {
                UsuarioId = usuarioId,
                CarroId = carroId
            };
            
            context.ListaDeseados.Add(item);
            return await context.SaveChangesAsync() > 0;
        }
        
        public async Task<bool> EliminarDeLista(string usuarioId, int carroId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            
            var item = await context.ListaDeseados
                .FirstOrDefaultAsync(ld => ld.UsuarioId == usuarioId && ld.CarroId == carroId);
                
            if (item == null) return false;
            
            context.ListaDeseados.Remove(item);
            return await context.SaveChangesAsync() > 0;
        }
        
        public async Task<List<ListaDeseados>> ObtenerListaPorUsuario(string usuarioId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            
            return await context.ListaDeseados
                .Where(ld => ld.UsuarioId == usuarioId)
                .Include(ld => ld.Carro)
                .OrderByDescending(ld => ld.FechaAgregado)
                .AsNoTracking()
                .ToListAsync();
        }
        
        public async Task<bool> ExisteEnLista(string usuarioId, int carroId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            
            return await context.ListaDeseados
                .AnyAsync(ld => ld.UsuarioId == usuarioId && ld.CarroId == carroId);
        }
    }
}