using System;
using System.Collections.Generic;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Framework;

namespace Glimpse.Owin.Middleware
{
    public class OwinFrameworkProvider : IFrameworkProvider
    {
        private readonly IDataStore serverProperties;
        private readonly IDictionary<string, object> environment;

        public OwinFrameworkProvider(IDataStore serverProperties, IDictionary<string, object> environment)
        {
            this.serverProperties = serverProperties;
            this.environment = environment;
        }

        public IDataStore HttpRequestStore
        {
            get
            {
                const string key = "glimpse.requestStore";

                if (environment.ContainsKey(key))
                {
                    return (IDataStore)environment[key];
                }

                var result = new DictionaryDataStoreAdapter(new Dictionary<string, object>());
                environment.Add(key, result);
                return result;
            }
        }

        public IDataStore HttpServerStore
        {
            get
            {
                return this.serverProperties;
            }
        }

        public object RuntimeContext
        {
            get { return environment; }
        }

        public IRequestMetadata RequestMetadata { get; private set; }

        public void SetHttpResponseHeader(string name, string value)
        {
            throw new NotImplementedException();
        }

        public void SetHttpResponseStatusCode(int statusCode)
        {
            throw new NotImplementedException();
        }

        public void SetCookie(string name, string value)
        {
            throw new NotImplementedException();
        }

        public void InjectHttpResponseBody(string htmlSnippet)
        {
            throw new NotImplementedException();
        }

        public void WriteHttpResponse(byte[] content)
        {
            throw new NotImplementedException();
        }

        public void WriteHttpResponse(string content)
        {
            throw new NotImplementedException();
        }
    }
}