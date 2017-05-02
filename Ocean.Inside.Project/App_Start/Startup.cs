using Microsoft.Owin;
using Ocean.Inside.Project;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Ocean.Inside.Project
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
