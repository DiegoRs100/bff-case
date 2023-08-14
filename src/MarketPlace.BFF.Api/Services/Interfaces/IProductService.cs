using MarketPlace.BFF.Api.Common;
using MarketPlace.BFF.Api.ViewModels;

namespace MarketPlace.BFF.Api.Services.Interfaces
{
    public interface IProductService
    {
        Task<CustomResponse<ProductViewModel>> GetById(Guid productId);
        Task<CustomResponse<ProductViewModel>> CreateProduct(ProductViewModel product);
    }
}