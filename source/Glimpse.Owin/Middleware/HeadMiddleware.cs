using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Framework;

namespace Glimpse.Owin.Middleware
{
    internal class HeadMiddleware
    {
        private readonly IDataStore serverDataStore;

        public HeadMiddleware(IDataStore serverDataStore)
        {
            this.serverDataStore = serverDataStore;
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            var provider = new OwinFrameworkProvider(this.serverDataStore, environment);
            GlimpseRuntime.Instance.BeginRequest(provider);

            var requestPath = (string)environment["owin.RequestPath"];
            var queryString = (string)environment["owin.RequestQueryString"];
            if (requestPath.StartsWith(GlimpseRuntime.Instance.Configuration.EndpointBaseUri))
            {
                // TODO: Handle resource names
                GlimpseRuntime.Instance.ExecuteDefaultResource(provider);
            }

            return Task.FromResult(0);
        }
    }
}