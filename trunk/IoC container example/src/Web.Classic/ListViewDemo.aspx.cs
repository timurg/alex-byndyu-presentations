using System;
using System.Collections.Generic;
using System.Web.UI;
using Domain.Entities;
using Infrastructure;
using Web.Classic.UI.Presenters;
using Web.Classic.UI.Views;

namespace Web.Classic
{
    public partial class ListViewDemo : Page, IListViewDemoView
    {
        #region IListViewDemoView Members

        public ListViewDemoPresenter Presenter
        {
            get { return IoC.Resolve<ListViewDemoPresenter>(new {view = this}); }
        }

        public int GetCurrentPageNumber()
        {
            string page = Request.QueryString["page"];

            if (string.IsNullOrEmpty(page))
                return 0;

            return int.Parse(page);
        }

        public void BindProducts(IEnumerable<Product> products)
        {
            ProductListView.DataSource = products;
            ProductListView.DataBind();
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.SetProductList();
        }
    }
}