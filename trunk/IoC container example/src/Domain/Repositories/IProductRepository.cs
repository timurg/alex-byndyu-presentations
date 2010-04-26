using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(int id);
        void Save(Product entity);
        void Delete(Product entity);
        Product GetLastProduct();
        IEnumerable<Product> GetProducts(int startNumber, int count);
    }
}