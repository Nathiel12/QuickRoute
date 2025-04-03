using Microsoft.AspNetCore.Identity;
using QuickRoute.Data.Models;

namespace QuickRoute.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Traslados> Traslados { get; set; }
        public ICollection<Despachos> Despachos { get; set; }
        public ICollection<Declaraciones> Declaraciones { get; set; }
        public ICollection<Carros?> Carros { get; set; }
    }

}
