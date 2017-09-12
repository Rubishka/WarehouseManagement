using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WarehouseManagement.Startup))]
namespace WarehouseManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
