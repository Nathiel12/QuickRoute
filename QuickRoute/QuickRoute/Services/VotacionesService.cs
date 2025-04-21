using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuickRoute.Data;
using QuickRoute.Data.Models;

namespace QuickRoute.Services
{
    public class VotacionesService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<bool> Guardar(Votaciones votacion)
        {
            if (!await Existe(votacion.VotacionId))
            {
                return await Insertar(votacion);
            }
            else
            {
                return await Modificar(votacion);
            }
        }

        private async Task<bool> Existe(int votacionId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Votaciones.AnyAsync(v => v.VotacionId == votacionId);
        }

        private async Task<bool> Insertar(Votaciones votaciones)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Votaciones.Add(votaciones);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Votaciones votaciones)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(votaciones);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Votaciones?> Buscar(int votacionId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Votaciones.FirstOrDefaultAsync(v => v.VotacionId == votacionId);
        }

        public async Task<bool> Eliminar(int votacionId)
        {
            await using var Contexto = await DbFactory.CreateDbContextAsync();
            return await Contexto.Votaciones.AsNoTracking().Where(v => v.VotacionId == votacionId).ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Votaciones>> Listar(Expression<Func<Votaciones, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Votaciones.Where(criterio).AsNoTracking().ToListAsync();
        }

        public async Task<bool> GuardarVotacionCompleta(Votaciones votacion, List<TipoVehiculos> vehiculosVotados, string usuarioId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            if (await UsuarioYaVoto(usuarioId))
                return false;

            votacion.Id = usuarioId;

            votacion.FechaEncuesta = DateTime.Now;

            contexto.Votaciones.Add(votacion);

            await contexto.SaveChangesAsync();

            var vehiculosIds = vehiculosVotados.Select(v => v.TipoVehiculoId).ToList();

            var vehiculosEnBD = await contexto.TipoVehiculos
            .Where(v => vehiculosIds.Contains(v.TipoVehiculoId))
            .Include(v => v.VotosRecibidos)
            .ToDictionaryAsync(v => v.TipoVehiculoId);

            foreach (var vehiculo in vehiculosVotados.Where(v => v.PuntuacionVoto > 0))
            {
                contexto.VotacionesDetalles.Add(new VotacionesDetalles
                {
                    VotacionId = votacion.VotacionId,
                    TipoVehiculoId = vehiculo.TipoVehiculoId,
                    Puntuacion = vehiculo.PuntuacionVoto
                });

                if (vehiculosEnBD.TryGetValue(vehiculo.TipoVehiculoId, out var vehiculoBD))
                {
                    vehiculoBD.PuntuacionTotal += vehiculo.PuntuacionVoto;
                    vehiculoBD.PuntuacionPromedio = vehiculoBD.VotosRecibidos.Count > 0 ?
                        Math.Round(vehiculoBD.VotosRecibidos.Average(v => v.Puntuacion), 2) : 0;
                }
            }

            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<List<TipoVehiculos>> ListarConEstadisticas(Expression<Func<TipoVehiculos, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            return await contexto.TipoVehiculos
                .Where(criterio)
                .OrderByDescending(v => v.PuntuacionTotal)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> EliminarVotosPorVehiculo(int tipoVehiculoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            var votosAEliminar = await contexto.VotacionesDetalles
                .Where(vd => vd.TipoVehiculoId == tipoVehiculoId)
                .ToListAsync();

            contexto.VotacionesDetalles.RemoveRange(votosAEliminar);

            var vehiculo = await contexto.TipoVehiculos
                .FirstOrDefaultAsync(v => v.TipoVehiculoId == tipoVehiculoId);

            if (vehiculo != null)
            {
                vehiculo.PuntuacionTotal = 0;
                vehiculo.PuntuacionPromedio = 0;
            }

            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> UsuarioYaVoto(string usuarioId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Votaciones
                .AnyAsync(v => v.Id == usuarioId);
        }
    }
}
