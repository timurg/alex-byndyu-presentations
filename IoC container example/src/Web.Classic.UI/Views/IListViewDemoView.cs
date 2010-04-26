using System.Collections.Generic;
using Domain.Entities;
using Web.Classic.UI.Presenters;

namespace Web.Classic.UI.Views
{
    public interface IListViewDemoView : IView<ListViewDemoPresenter>
    {
        int GetCurrentPageNumber();
        void BindProducts(IEnumerable<Product> products);
    }
}