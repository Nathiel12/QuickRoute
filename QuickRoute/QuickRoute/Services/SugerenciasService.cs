using System.Linq.Expressions;
using QuickRoute.Data.Models;
using QuickRoute.Data;
using Microsoft.EntityFrameworkCore;

namespace QuickRoute.Services
{
	public class SugerenciasService(IDbContextFactory<ApplicationDbContext> DbFactory)
	{
		public async Task<bool> Existe(int id)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Sugerencias.AnyAsync(s => s.SugerenciaId == id);
		}

		public async Task<bool> Guardar(Sugerencias sugerencia)
		{
			if (!await Existe(sugerencia.SugerenciaId))
				return await Insertar(sugerencia);
			else
				return await Modificar(sugerencia);
		}

		public async Task<bool> Insertar(Sugerencias sugerencia)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			contexto.Sugerencias.Add(sugerencia);
			return await contexto.SaveChangesAsync() > 0;
		}

		public async Task<bool> Modificar(Sugerencias sugerencia)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			contexto.Update(sugerencia);
			return await contexto.SaveChangesAsync() > 0;
		}

		public async Task<Sugerencias?> Buscar(int id)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Sugerencias
				.Where(s => s.SugerenciaId == id)
				.AsNoTracking()
				.FirstOrDefaultAsync();
		}

		public async Task<bool> Eliminar(int id)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			var sugerencia = await contexto.Sugerencias
				.FirstOrDefaultAsync(s => s.SugerenciaId == id);

			if (sugerencia == null)
				return false;

			contexto.Sugerencias.Remove(sugerencia);
			return await contexto.SaveChangesAsync() > 0;
		}

		public async Task<List<Sugerencias>> Listar(Expression<Func<Sugerencias, bool>> criterio)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Sugerencias
				.Where(criterio)
				.AsNoTracking()
				.ToListAsync();
		}
	}
}