using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuickRoute.Data;
using QuickRoute.Data.Models;

namespace QuickRoute.Services
{
    public class DespachosService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<bool> Guardar(Despachos despacho)
        {
            if (!await Existe(despacho.SolicitudId))
            {
                return await Insertar(despacho);
            }
            else
            {
                return await Modificar(despacho);
            }
        }

        public async Task<bool> Existe(int SolicitudId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Despachos.AnyAsync(d => d.SolicitudId == SolicitudId);
        }

        private async Task<bool> Insertar(Despachos despacho)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Despachos.Add(despacho);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Despachos despacho)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(despacho);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Despachos?> Buscar(int SolicitudId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Despachos.Include(i=>i.Impuestos).FirstOrDefaultAsync(d => d.SolicitudId == SolicitudId);
        }
 
        public async Task<bool> Eliminar(int SolicitudId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var despacho = await contexto.Despachos
                                         .Include(d => d.Impuestos) 
                                         .FirstOrDefaultAsync(d => d.SolicitudId == SolicitudId);

            if (despacho == null) return false;

            contexto.Despachos.Remove(despacho);
            return await contexto.SaveChangesAsync() > 0;

        }

        public async Task<List<Despachos>> Listar(Expression<Func<Despachos, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Despachos.Include(i=> i.Impuestos).Where(criterio).AsNoTracking().ToListAsync();
        }

        public async Task<bool> AgregarImpuestoADespachoAsync(int despachoId, Impuestos impuesto)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var despacho = await contexto.Despachos
                                         .Include(d => d.Impuestos)
                                         .FirstOrDefaultAsync(d => d.SolicitudId == despachoId);

            if (despacho == null)
                return false; // No existe el despacho

            despacho.Impuestos.Add(impuesto);
            await contexto.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarImpuestoAsync(int impuestoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var impuesto = await contexto.Impuestos.FindAsync(impuestoId);
            if (impuesto == null)
                return false;

            contexto.Impuestos.Remove(impuesto);
            await contexto.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActualizarImpuestoAsync(Impuestos impuesto)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var impuestoExistente = await contexto.Impuestos.FindAsync(impuesto.ImpuestoId);
            if (impuestoExistente == null)
                return false;

            impuestoExistente.Nombre = impuesto.Nombre;
            impuestoExistente.Monto = impuesto.Monto;
            await contexto.SaveChangesAsync();
            return true;
        }
    }
}
