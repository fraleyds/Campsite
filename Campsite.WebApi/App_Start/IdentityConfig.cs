using System.Threading.Tasks;
using Campsite.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Campsite.WebApi.Models;

namespace Campsite.WebApi
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class CampsiteUserManager : UserManager<CampsiteUser>
    {
        public CampsiteUserManager(IUserStore<CampsiteUser> store)
            : base(store)
        {
        }

        public static CampsiteUserManager Create(IdentityFactoryOptions<CampsiteUserManager> options, IOwinContext context)
        {
            var manager = new CampsiteUserManager(new UserStore<CampsiteUser>(context.Get<CampsiteDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<CampsiteUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<CampsiteUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
