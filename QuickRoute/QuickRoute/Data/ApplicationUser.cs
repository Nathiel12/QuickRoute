using Microsoft.AspNetCore.Identity;
using QuickRoute.Data.Models;

namespace QuickRoute.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Traslados> Traslados { get; set; }
<<<<<<< HEAD
        public ICollection<Despachos> Despachos { get; set; }
        public ICollection<Declaraciones> Declaraciones { get; set; }
        public ICollection<Carros?> Carros { get; set; }
=======
>>>>>>> b94356f9e1ad664e1da4fce755a941b590e8ae27
    }

}
