using Owin;

namespace Glimpse.Owin.Sample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Glimpse.Owin.Provider.Enable(app.Properties);

            app.UseFunc(x => Glimpse.Owin.Provider.RequestStart);
            app.Use(typeof(TimestampMiddleware));
            app.UseWelcomePage();
            app.UseFunc(x => Glimpse.Owin.Provider.RequestEnd);
        }
    }
}