namespace MarketPlace.Api.Common
{
    public class ApiResult<TResult>
    {
        public TResult Data { get; set; } = default!;
        public List<string> InvalidFields { get; set; } = new();
        public List<string> Notifications { get; set; } = new();

        public ApiResult()
        { }

        public ApiResult(TResult data)
        {
            Data = data;
        }
    }
}