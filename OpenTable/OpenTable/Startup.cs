using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenTable.Startup))]
namespace OpenTable
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
