using System.Collections.Generic;
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

        public IEnumerable<Product> FindProducts(int pageNumber)
        {
            // в живом проекте все константы нужно брать из конфигурации
            return productRepository.GetProducts(pageNumber*10, 30);
        }

        #endregion
    }
}