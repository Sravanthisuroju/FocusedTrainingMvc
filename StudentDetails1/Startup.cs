using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentDetails1.Startup))]
namespace StudentDetails1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
