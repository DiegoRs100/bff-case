using MarketPlace.BFF.Api.Common;
using MarketPlace.BFF.Api.ViewModels;

namespace MarketPlace.BFF.Api.Facades.Interfaces
{
    public interface IProductFacade
    {
        Task<CustomResponse<ProductViewModel>> GetById(Guid productId);
        Task<CustomResponse<ProductViewModel>> CreateProduct(ProductViewModel product);
    }
}