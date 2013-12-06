using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Glimpse.Owin.Middleware
{
    internal class TailMiddleware
    {
        public Task Invoke(IDictionary<string, object> environment)
        {
            return Task.FromResult(0);
        }
    }
}