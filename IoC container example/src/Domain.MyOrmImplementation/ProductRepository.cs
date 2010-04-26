using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure;

namespace Domain.MyOrmImplementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataContext dataContext;

        public ProductRepository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        #region IProductRepository Members

        public Product Get(int id)
        {
            return dataContext.Get<Product>(id);
        }

        public void Save(Product entity)
        {
            dataContext.Save(entity);
        }

        public void Delete(Product entity)
        {
            dataContext.Delete(entity);
        }

        public Product GetLastProduct()
        {
            return dataContext.Query<Product>()
                .OrderByDescending(p => p.DateCreate)
                .FirstOrDefault();
        }

        public IEnumerable<Product> GetProducts(int startNumber, int count)
        {
            return new List<Product>
                       {
                           new Product
                               {
                                   Id = 1,
                                   Name = "Product1",
                                   ShowCount = 12
                               },
                           new Product
                               {
                                   Id = 2,
                                   Name = "Product2",
                                   ShowCount = 42
                               },
                           new Product
                               {
                                   Id = 3,
                                   Name = "Product3",
                                   ShowCount = 4
                               },
                       };
        }

        #endregion
    }
}