using System.Linq.Expressions;
using QuickRoute.Data.Models;
using QuickRoute.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace QuickRoute.Services
{
	public class SugerenciasService(IDbContextFactory<ApplicationDbContext> DbFactory, IHttpContextAccessor httpContextAccessor)
	{
		public async Task<bool> Existe(int id)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Sugerencias.AnyAsync(s => s.SugerenciaId == id);
		}

		public async Task<bool> Guardar(Sugerencias sugerencia, string userId)
		{
            if (!await Existe(sugerencia.SugerenciaId))
			{
				sugerencia.Id = userId;
                return await Insertar(sugerencia, userId);
            }
			else
				return await Modificar(sugerencia);
		}

		public async Task<bool> Insertar(Sugerencias sugerencia, string userId)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
            var nuevaSugerencia = new Sugerencias
            {
                Id = userId,
                Fecha = DateTime.Today,
                Asunto = sugerencia.Asunto,
                Descripcion = sugerencia.Descripcion,
                satisfaccion= sugerencia.satisfaccion,
            };
            contexto.Sugerencias.Add(nuevaSugerencia);
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