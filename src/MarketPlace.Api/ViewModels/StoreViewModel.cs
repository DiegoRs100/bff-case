namespace MarketPlace.Api.ViewModels
{
    public class StoreViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public StoreViewModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}