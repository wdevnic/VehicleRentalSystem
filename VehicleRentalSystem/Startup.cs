using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VehicleRentalSystem.Startup))]
namespace VehicleRentalSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
