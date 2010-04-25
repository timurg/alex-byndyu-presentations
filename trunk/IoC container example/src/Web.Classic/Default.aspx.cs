using System;
using System.Web.UI;
using Infrastructure;
using Web.Classic.UI.Presenters;
using Web.Classic.UI.Views;

namespace Web.Classic
{
    public partial class Default : Page, IProductView
    {
        #region IProductView Members

        public ProductPresenter Presenter
        {
            get { return IoC.Resolve<ProductPresenter>(new {view = this}); }
        }

        public void SetProductName(string name)
        {
            ProductNameLabel.Text = name;
        }

        public void SetShowCount(int showCount)
        {
            ShowCountLabel.Text = showCount.ToString();
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.ShowLastProduct();
        }
    }
}