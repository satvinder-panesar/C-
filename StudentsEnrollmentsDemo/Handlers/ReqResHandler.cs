using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace StudentsEnrollmentsDemo.Handlers
{
    public class ReqResHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            System.Diagnostics.Debug.Print("Token can be checked here, for now, it is assumed valid");
            System.Diagnostics.Debug.Print("Request ========> " + request.RequestUri);
            var response = await base.SendAsync(request, cancellationToken);
            System.Diagnostics.Debug.Print("Response ========> " + response.ToString());
            return response;
        }
    }
}