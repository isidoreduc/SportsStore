using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext _dbContext;

        public EFStoreRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Product> Products => _dbContext.Products;
    }
}
