using MarketPlace.BFF.Api.Common;
using MarketPlace.BFF.Api.Facades;
using MarketPlace.BFF.Api.Facades.Interfaces;
using MarketPlace.BFF.Api.Services.Interfaces;
using MarketPlace.BFF.Api.ViewModels;

namespace MarketPlace.BFF.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductFacade _productFacade;

        public ProductService(IProductFacade productFacade)
        {
            _productFacade = productFacade;
        }

        public async Task<CustomResponse<ProductViewModel>> CreateProduct(ProductViewModel product)
        {
            var existingProduct = await GetById(product.Id);

            if (existingProduct.IsSuccess) 
            {
                // Gerar notification indicando que o produto informado já existe.
                return null!;
            }

            return await _productFacade.CreateProduct(product);
        }

        public Task<CustomResponse<ProductViewModel>> GetById(Guid productId)
        {
            return _productFacade.GetById(productId);
        }
    }
}