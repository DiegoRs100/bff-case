namespace MarketPlace.BFF.Api.HttpClients.MarketPlaceApi
{
    public class MarketPlaceApiResponse<TResult>
    {
        public TResult Data { get; set; } = default!;
        public List<string> InvalidFields { get; set; } = new();
        public List<string> Notifications { get; set; } = new();
    }
}