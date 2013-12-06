using System;
using System.Collections.Generic;
using Glimpse.Core.Framework;

namespace Glimpse.Owin
{
    internal class OwinResourceEndpointConfiguration : ResourceEndpointConfiguration
    {
        protected override string GenerateUriTemplate(string resourceName, string baseUri, IEnumerable<Core.Extensibility.ResourceParameterMetadata> parameters, Core.Extensibility.ILogger logger)
        {
            throw new NotImplementedException();
        }
    }
}