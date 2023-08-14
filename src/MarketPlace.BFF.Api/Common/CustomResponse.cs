namespace MarketPlace.BFF.Api.Common
{
    public class CustomResponse<TResult>
    {
        public TResult Data { get; set; } = default!;
        public IEnumerable<string> InvalidFields { get; set; } = default!;
        public IEnumerable<string> Notifications { get; set; } = default!;

        internal HttpResponseMessage ResponseMessage { get; set; }
        internal bool IsSuccess => ResponseMessage.IsSuccessStatusCode;

        public CustomResponse(HttpResponseMessage responseMessage)
        {
            ResponseMessage = responseMessage;
        }

        public void SetData(TResult data)
        {
            Data = data;
        }

        public void SetErrors(IEnumerable<string> invalidFields, IEnumerable<string> notifications)
        {
            if (invalidFields.Any())
                InvalidFields = invalidFields;

            if (notifications.Any())
                Notifications = notifications;
        }
    }
}