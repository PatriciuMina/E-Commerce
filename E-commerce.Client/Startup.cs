using Microsoft.Owin;
using Owin;


namespace E_commerce.Client
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
