using Microsoft.EntityFrameworkCore;
using QuickRoute.Data;

namespace QuickRoute.Services
{
    public class ImpuestosService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
    }
}
