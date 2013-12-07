using Owin;

namespace Glimpse.Owin.Sample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // TODO: Clean this up, UseFunc is awful and UseWelcomePage is aborting the chain?
            Glimpse.Owin.Provider.Enable(app.Properties);
            app.UseErrorPage();
            app.UseFunc(x => async y => { await Glimpse.Owin.Provider.RequestStart(y); await x(y); });
            app.Use(typeof(TimestampMiddleware));
            app.UseFunc(x => async y => { await Glimpse.Owin.Provider.RequestEnd(y); await x(y); });
            app.UseWelcomePage();
        }
    }
}