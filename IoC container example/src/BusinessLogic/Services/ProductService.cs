using Domain.Entities;
using Domain.Repositories;
using Services;

namespace BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        #region IProductService Members

        public Product FindLastCreatedProduct()
        {
            Product product = productRepository.GetLastProduct();

            if (product == null)
                throw new ProductException();

            product.ShowCount++;

            productRepository.Save(product);

            return product;
        }

        #endregion
    }
}