using QuickRoute.Data;
namespace QuickRoute.Services;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


public class ContactosService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Guardar(Contactos contacto)
    {
        if (!await Existe(contacto.ContactoId))
        {
            return await Insertar(contacto);
        }
        else
        {
            return await Modificar(contacto);
        }
    }

    private async Task<bool> Existe(int contactoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Contactos.AnyAsync(t => t.ContactoId == contactoId);
    }

    private async Task<bool> Insertar(Contactos contacto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Contactos.Add(contacto);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Contactos contacto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(contacto);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Contactos?> Buscar(int contactoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Contactos.FirstOrDefaultAsync(t => t.ContactoId == contactoId);
    }

    public async Task<(bool Success, string Message)> Eliminar(int contactoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        bool hasCasos = await contexto.Casos.AnyAsync(c => c.Contacto.ContactoId == contactoId);
        if (hasCasos)
        {
            return (false, "El Contacto tiene casos asignados. Reasigne los casos antes de eliminar.");
        }

        bool deleted =
            await contexto.Contactos.AsNoTracking().Where(t => t.ContactoId == contactoId).ExecuteDeleteAsync() > 0;
        return (deleted, deleted ? "Contacto eliminado exitosamente." : "Error al eliminar el Contacto.");
    }

    public async Task<List<Contactos>> Listar(Expression<Func<Contactos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Contactos.Where(criterio).AsNoTracking().ToListAsync();
    }

    public async Task<bool> ExisteEmail(string Email)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Contactos.AnyAsync(c => c.Email.ToLower() == Email.ToLower());
    }

    public async Task<bool> ExisteNombre(string Nombre)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Contactos.AnyAsync(c => c.Nombre.ToLower() == Nombre.ToLower());
    }

    public async Task<bool> ExisteTelefono(string Telefono)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Contactos.AnyAsync(c => c.Telefono == Telefono);
    }
}