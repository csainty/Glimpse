using System.Collections.Generic;
using System.Threading.Tasks;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Framework;

namespace Glimpse.Owin.Middleware
{
    internal class TailMiddleware
    {
        private readonly IDataStore serverProperties;

        public TailMiddleware(IDataStore serverProperties)
        {
            this.serverProperties = serverProperties;
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            GlimpseRuntime.Instance.EndRequest(new OwinFrameworkProvider(this.serverProperties, environment));
            return Task.FromResult(0);
        }
    }
}