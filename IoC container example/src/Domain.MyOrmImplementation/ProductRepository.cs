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

        #endregion
    }
}