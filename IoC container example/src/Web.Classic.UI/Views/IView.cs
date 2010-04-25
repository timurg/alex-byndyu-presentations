namespace Web.Classic.UI.Views
{
    public interface IView<TPresenter>
    {
        TPresenter Presenter { get; }
    }
}