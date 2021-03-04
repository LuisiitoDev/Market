using luigiDev.Market.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace luiguiDev.Market.Business.StoreBusiness
{
    public interface IStoreBusiness
    {
        Task<bool> CreateStore(Store store);
        Task<bool> UpdateStore(Store store);
        Task<bool> DeleteStore(Guid storeId);
        Task<IEnumerable<Store>> GetStores();
    }
}
