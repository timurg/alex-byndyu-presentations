using System.Collections.Generic;
using Domain.Entities;
using Services;
using Web.Classic.UI.Views;

namespace Web.Classic.UI.Presenters
{
    public class ListViewDemoPresenter
    {
        private readonly IProductService productService;
        private readonly IListViewDemoView view;

        public ListViewDemoPresenter(IListViewDemoView view, IProductService productService)
        {
            this.view = view;
            this.productService = productService;
        }

        public void SetProductList()
        {
            IEnumerable<Product> products = productService.FindProducts(view.GetCurrentPageNumber());
            view.BindProducts(products);
        }
    }
}