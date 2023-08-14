using MarketPlace.BFF.Api.Common;
using MarketPlace.BFF.Api.ViewModels;

namespace MarketPlace.BFF.Api.Facades.Interfaces
{
    public interface IStoreFacade
    {
        Task<CustomResponse<IEnumerable<StoreViewModel>>> GetAll();
    }
}