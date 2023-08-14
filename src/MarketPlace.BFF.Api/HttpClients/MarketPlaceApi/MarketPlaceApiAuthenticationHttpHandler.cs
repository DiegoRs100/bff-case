using System.Net.Http.Headers;

namespace MarketPlace.BFF.Api.HttpClients.MarketPlaceApi
{
    public class MarketPlaceApiAuthenticationHttpHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public MarketPlaceApiAuthenticationHttpHandler(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var jwtToken = _contextAccessor.HttpContext?.Request.Headers.Authorization
                .ToString().Replace("Bearer ", "");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6IkphdmFJblVzZSIsImV4cCI6MTY5MjAyMTU3NCwiaWF0IjoxNjkyMDIxNTc0fQ.BNiPHnPyRcVwQZbDPtBjIzbHmMPhFmdVFQP_XOiL1yk");

            return base.SendAsync(request, cancellationToken);
        }
    }
}