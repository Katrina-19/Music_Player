<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="Music_Player.Pages.Listing"
    MasterPageFile="~/Pages/Player.Master" %>
<%@ Import Namespace="System.Web.Routing" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <asp:Repeater ItemType="Music_Player.Models.Song"
            SelectMethod="GetSongs" runat="server">
            <ItemTemplate>
                <div class="item">
                    <h3>Название: <%# Item.Name %></h3>
                    Исполнитель: <%# Item.Singer %>
                    <h4>Длительность: <%# Item.Duration %></h4>
                    <button name="add" type="submit" value="<%# Item.SongId %>">
                        Добавить в лист ожидания
                    </button>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="pager">
        <%
            for (int i = 1; i <= MaxPage; i++)
            {
                string album = (string)Page.RouteData.Values["album"]
                    ?? Request.QueryString["album"];
                
                string path = RouteTable.Routes.GetVirtualPath(null, null,
                    new RouteValueDictionary() { {"album", album}, { "page", i } }).VirtualPath;
                Response.Write(
                    String.Format("<a href='{0}' {1}>{2}</a>",
                        path, i == CurrentPage ? "class='selected'" : "", i));
            }
        %>
    </div>
</asp:Content>