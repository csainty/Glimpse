using System.Collections.Generic;
using System.IO;
using System.Text;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Framework;

namespace Glimpse.Owin.Middleware
{
    public class OwinFrameworkProvider : IFrameworkProvider
    {
        private readonly IDataStore serverDataStore;
        private readonly IDataStore requestDataStore;
        private readonly IDictionary<string, object> environment;

        public OwinFrameworkProvider(IDataStore serverProperties, IDictionary<string, object> environment)
        {
            this.environment = environment;
            this.serverDataStore = serverProperties;
            this.requestDataStore = FetchOrCreateRequestDataStore();
            this.RequestMetadata = new OwinRequestMetadata(this.environment);
        }

        public IDataStore HttpRequestStore { get { return this.requestDataStore; } }

        public IDataStore HttpServerStore { get { return this.serverDataStore; } }

        public object RuntimeContext { get { return this.environment; } }

        public IRequestMetadata RequestMetadata { get; private set; }

        public void SetHttpResponseHeader(string name, string value)
        {
            this.ResponseHeaders[name] = new[] { value };
        }

        public void SetHttpResponseStatusCode(int statusCode)
        {
            this.environment["owin.ResponseStatusCode"] = statusCode;
        }

        public void SetCookie(string name, string value)
        {
            // TODO: Support cookies
        }

        public void InjectHttpResponseBody(string htmlSnippet)
        {
            this.environment["owin.ResponseBody"] = new PreBodyTagInsertionStream(htmlSnippet, (Stream)this.environment["owin.ResponseBody"], Encoding.UTF8);
        }

        public void WriteHttpResponse(byte[] content)
        {
            ((Stream)this.environment["owin.ResponseBody"]).Write(content, 0, content.Length);
        }

        public void WriteHttpResponse(string content)
        {
            this.WriteHttpResponse(Encoding.UTF8.GetBytes(content));
        }

        private IDictionary<string, string[]> ResponseHeaders
        {
            get { return (IDictionary<string, string[]>)this.environment["owin.ResponseHeaders"]; }
        }

        private IDataStore FetchOrCreateRequestDataStore()
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
}