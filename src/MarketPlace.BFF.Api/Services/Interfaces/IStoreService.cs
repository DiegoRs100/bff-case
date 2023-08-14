using MarketPlace.BFF.Api.Common;
using MarketPlace.BFF.Api.ViewModels;

namespace MarketPlace.BFF.Api.Services.Interfaces
{
    public interface IStoreService
    {
        Task<CustomResponse<IEnumerable<StoreViewModel>>> GetAll();
    }
}