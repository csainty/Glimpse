using System.Collections.Generic;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Framework;

namespace Glimpse.Owin.Framework
{
    internal class OwinServiceLocator : IServiceLocator
    {
        private readonly IDataStore serverProperties;
        private readonly IDictionary<string, object> environment;

        public OwinServiceLocator(IDataStore serverProperties, IDictionary<string, object> environment)
        {
            this.serverProperties = serverProperties;
            this.environment = environment;
        }

        public T GetInstance<T>() where T : class
        {
            if (typeof(T) == typeof(IFrameworkProvider))
            {
                return new OwinFrameworkProvider(serverProperties, environment) as T;
            }

            return null;
        }

        public ICollection<T> GetAllInstances<T>() where T : class
        {
            return null;
        }
    }
}