<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Domain.Entities.Product>" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Последний добавленный продукт: <b><%=Model.Name%></b>.
    </p>
    <p>
        Показан: <b><%=Model.ShowCount%></b> раз.
    </p>
</asp:Content>