using luigiDev.Market.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace luigiDev.Market.DataAccess.StoreRepository
{
    public interface IStoreService
    {
        Task<bool> CreateStore(Store store);
        Task<bool> UpdateStore(Store store);
        Task<bool> DeleteStore(Guid storeId);
        Task<IEnumerable<Store>> GetStores();
    }
}
