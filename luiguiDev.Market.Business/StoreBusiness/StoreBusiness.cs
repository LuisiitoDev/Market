using luigiDev.Market.DataAccess.StoreRepository;
using luigiDev.Market.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace luiguiDev.Market.Business.StoreBusiness
{
    public class StoreBusiness : IStoreBusiness
    {
        IStoreService storeService;
        public StoreBusiness(IStoreService storeService)
        {
            this.storeService = storeService;
        }
        public async Task<bool> CreateStore(Store store)
        {
            try
            {
                return await storeService.CreateStore(store);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteStore(Guid storeId)
        {
            try
            {
                return await storeService.DeleteStore(storeId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Store>> GetStores()
        {
            try
            {
                return await storeService.GetStores();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateStore(Store store)
        {
            try
            {
                return await storeService.UpdateStore(store);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
