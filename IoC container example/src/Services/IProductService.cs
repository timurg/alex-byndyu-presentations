using Domain.Entities;

namespace Services
{
    public interface IProductService
    {
        Product FindLastCreatedProduct();
    }
}