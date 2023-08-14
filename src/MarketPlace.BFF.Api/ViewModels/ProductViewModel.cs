namespace MarketPlace.BFF.Api.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ProductViewModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}