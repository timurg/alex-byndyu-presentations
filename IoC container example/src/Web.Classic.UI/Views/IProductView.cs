using Web.Classic.UI.Presenters;

namespace Web.Classic.UI.Views
{
    public interface IProductView : IView<ProductPresenter>
    {
        void SetProductName(string name);
        void SetShowCount(int showCount);
    }
}