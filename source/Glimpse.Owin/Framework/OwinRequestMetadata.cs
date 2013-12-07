using System.Collections.Generic;
using System.Linq;
using Glimpse.Core.Framework;

namespace Glimpse.Owin.Framework
{
    internal class OwinRequestMetadata : IRequestMetadata
    {
        private readonly IDictionary<string, object> environment;

        public OwinRequestMetadata(IDictionary<string, object> environment)
        {
            this.environment = environment;
        }

        public string RequestUri
        {
            get { return (string)this.environment["owin.RequestMethod"]; }
        }

        public string RequestHttpMethod
        {
            get { return (string)this.environment["owin.RequestPath"]; }
        }

        public int ResponseStatusCode
        {
            get
            {
                return this.environment.ContainsKey("owin.ResponseStatusCode") ?
                    (int)this.environment["owin.ResponseStatusCode"]
                    : 0;
            }
        }

        public string ResponseContentType
        {
            get { return ResponseHeaders.ContainsKey("Content-Type") ? ResponseHeaders["Content-Type"].FirstOrDefault() : ""; }
        }

        public string IpAddress
        {
            get
            {
                // TODO: Support client address
                return "";
            }
        }

        public bool RequestIsAjax
        {
            get
            {
                // TODO: Support Ajax check
                return false;
            }
        }

        public string ClientId
        {
            get
            {
                // TODO: Support client id
                return "";
            }
        }

        public string GetCookie(string name)
        {
            // TODO: Support cookies
            return "";
        }

        public string GetHttpHeader(string name)
        {
            return RequestHeaders.ContainsKey(name) ? RequestHeaders[name].FirstOrDefault() : "";
        }

        private IDictionary<string, string[]> RequestHeaders
        {
            get { return (IDictionary<string, string[]>)this.environment["owin.RequestHeaders"]; }
        }

        private IDictionary<string, string[]> ResponseHeaders
        {
            get { return (IDictionary<string, string[]>)this.environment["owin.ResponseHeaders"]; }
        }
    }
}