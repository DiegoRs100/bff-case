namespace MarketPlace.BFF.Api.HttpClients.MarketPlaceApi
{
    public class MarketPlaceApiLogHttpHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Logar request

            var responseMessage = await base.SendAsync(request, cancellationToken);

            // Logar response

            return responseMessage;
        }
    }
}