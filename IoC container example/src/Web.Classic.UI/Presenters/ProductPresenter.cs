using Domain.Entities;
using Services;
using Web.Classic.UI.Views;

namespace Web.Classic.UI.Presenters
{
    public class ProductPresenter
    {
        private readonly IProductService productService;
        private readonly IProductView view;

        public ProductPresenter(IProductView view, IProductService productService)
        {
            this.view = view;
            this.productService = productService;
        }

        public void ShowLastProduct()
        {
            Product product = productService.FindLastCreatedProduct();

            view.SetProductName(product.Name);
            view.SetShowCount(product.ShowCount);
        }
    }
}