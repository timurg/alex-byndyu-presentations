using BusinessLogic.Services;
using Domain.Entities;
using Domain.Repositories;
using Moq;
using Xunit;

namespace BusinessLogic.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public void IfProductExistsReturnProduct()
        {
            var repository = new Mock<IProductRepository>();
            repository.Setup(x => x.GetLastProduct())
                .Returns(new Product {Id = 1});

            var service = new ProductService(repository.Object);

            Product product = service.FindLastCreatedProduct();

            Assert.Equal(1, product.Id);
        }
    }
}