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
            GlimpseRuntime.Instance.BeginRequest(new OwinFrameworkProvider(this.serverDataStore, environment));
            return Task.FromResult(0);
        }
    }
}