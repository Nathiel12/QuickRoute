using QuickRoute.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace QuickRoute.Services;

public class SugerenciasService(IDbContextFactory<Contexto> DbFactory)
{
	public async Task<bool> Guardar(Sugerencias sugerencia)
	{
		if (!await Existe(sugerencia.SugerenciaId))
		{
			return await Insertar(sugerencia);
		}
		else
		{
			return await Modificar(sugerencia);
		}
	}

	private async Task<bool> Existe(int sugerenciaId)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.Sugerencias.AnyAsync(s => s.SugerenciaId == sugerenciaId);
	}

	private async Task<bool> Insertar(Sugerencias sugerencia)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		contexto.Sugerencias.Add(sugerencia);
		return await contexto.SaveChangesAsync() > 0;
	}

	private async Task<bool> Modificar(Sugerencias sugerencia)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		contexto.Update(sugerencia);
		return await contexto.SaveChangesAsync() > 0;
	}

	public async Task<Sugerencias?> Buscar(int sugerenciaId)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.Sugerencias.FirstOrDefaultAsync(s => s.SugerenciaId == sugerenciaId);
	}

	public async Task<(bool Success, string Message)> Eliminar(int sugerenciaId)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();

		bool deleted =
			await contexto.Sugerencias.AsNoTracking().Where(s => s.SugerenciaId == sugerenciaId).ExecuteDeleteAsync() > 0;
		return (deleted, deleted ? "Sugerencia eliminada exitosamente." : "Error al eliminar la sugerencia.");
	}

	public async Task<List<Sugerencias>> Listar(Expression<Func<Sugerencias, bool>> criterio)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.Sugerencias.Where(criterio).AsNoTracking().ToListAsync();
	}
}