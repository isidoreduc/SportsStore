﻿using System;
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

        public void CreateProduct(Product p)
        {
            _dbContext.Add(p);
            _dbContext.SaveChanges();
        }
        public void DeleteProduct(Product p)
        {
            _dbContext.Remove(p);
            _dbContext.SaveChanges();
        }
        public void SaveProduct(Product p)
        {
            _dbContext.SaveChanges();
        }

    }
}
