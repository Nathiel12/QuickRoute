using Microsoft.EntityFrameworkCore;
using QuickRoute.Data;
using QuickRoute.Data.Models;

namespace QuickRoute.Services
{
    public class UserServices(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        
    }
}
