namespace QuickRoute.Services;
using QuickRoute.Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

public class CasosService(IDbContextFactory<ApplicationDbContext> DbFactory, IHttpContextAccessor httpContextAccessor)
{
    public async Task<bool> Guardar(Casos caso, string userId)
    {
        if (!await Existe(caso.CasoId))
        {
            caso.Id = userId;
            return await Insertar(caso, userId);
        }
        else
        {
            return await Modificar(caso);
        }
    }

    public async Task<bool> Existe(int casoId)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Casos.AnyAsync(t => t.CasoId == casoId);
    }

    private async Task<bool> Insertar(Casos casos, string userId)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        var nuevoCaso = new Casos
        {
            Id = userId,
            Contacto = casos.Contacto,
            Fecha = DateTime.Today,
            Asunto = casos.Asunto,
            Descripcion = casos.Descripcion,
            ContactoId = casos.ContactoId
        };
        Contexto.Casos.Add(nuevoCaso);
        return await Contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Casos casos)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        Contexto.Casos.Update(casos);
        return await Contexto.SaveChangesAsync() > 0;
    }
    
    //Nota: modificar para incluir al contacto/usuario
    public async Task<Casos?> Buscar(int casoId)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Casos.FirstOrDefaultAsync(c => c.CasoId == casoId);
    }
    
    public async Task<bool> Eliminar(int casoId)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Casos.AsNoTracking().Where(c => c.CasoId == casoId).ExecuteDeleteAsync() > 0;
    }
    
    //Nota: modificar para incluir al usuario al listar
    public async Task<List<Casos>> Listar(Expression<Func<Casos, bool>> criterio)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Casos.Where(criterio)
            .AsNoTracking()
            .Include(c => c.Contacto)
            .ToListAsync();
    }
    public async Task<Casos?> ObtenerCasosDetallado(int casoId, string usuarioId)
    {
        await using var context = await DbFactory.CreateDbContextAsync();

        var resultado = context.Casos
            .Where(c => c.CasoId == casoId);

        if (!string.IsNullOrEmpty(usuarioId))
        {
            resultado = resultado.Where(o => o.Id == usuarioId);
        }

        return await resultado.FirstOrDefaultAsync();
    }
}