using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Framework;
using Glimpse.Owin.Middleware;

namespace Glimpse.Owin
{
    public static class Provider
    {
        private static IDataStore serverStore;

        public static void Enable(IDictionary<string, object> properties)
        {
            serverStore = new DictionaryDataStoreAdapter(properties as IDictionary);
            var config = new GlimpseConfiguration(new OwinResourceEndpointConfiguration(), new ApplicationPersistenceStore(serverStore));
            config.DefaultRuntimePolicy = RuntimePolicy.On;

            GlimpseRuntime.Initialize(config);
            GlimpseRuntime.Instance.Initialize();
        }

        public static Task RequestStart(IDictionary<string, object> environment)
        {
            return new HeadMiddleware(serverStore).Invoke(environment);
        }

        public static Task RequestEnd(IDictionary<string, object> environment)
        {
            return new TailMiddleware().Invoke(environment);
        }
    }
}