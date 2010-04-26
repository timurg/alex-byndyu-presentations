using System.Collections.Generic;
using Domain.Entities;

namespace Services
{
    public interface IProductService
    {
        Product FindLastCreatedProduct();
        IEnumerable<Product> FindProducts(int pageNumber);
    }
}