using MarketPlace.BFF.Api.Common;
using MarketPlace.BFF.Api.Facades.Interfaces;
using MarketPlace.BFF.Api.Services.Interfaces;
using MarketPlace.BFF.Api.ViewModels;

namespace MarketPlace.BFF.Api.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreFacade _storeFacade;

        public StoreService(IStoreFacade storeFacade)
        {
            _storeFacade = storeFacade;
        }

        public Task<CustomResponse<IEnumerable<StoreViewModel>>> GetAll()
        {
            return _storeFacade.GetAll();
        }
    }
}