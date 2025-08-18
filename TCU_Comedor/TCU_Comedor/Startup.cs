using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TCU_Comedor.Startup))]
namespace TCU_Comedor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
