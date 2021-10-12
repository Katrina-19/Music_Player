<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" 
     Inherits="Music_Player.Pages.Admin.Users"
     MasterPageFile="~/Pages/Admin/Admin.Master" EnableViewState="false" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="outerContainer">
        <table id="ordersTable">
            <tr>
                <th>User name</th>
                <th>Email</th>
                <th>Password</th>
                <th></th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" SelectMethod="GetUsers"
                ItemType="Music_Player.Models.User">
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.Name %></td>
                        <td><%#: Item.Email %></td>
                        <td><%# Item.Password %></td>
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder1" Visible="<%# !Item.Dispatched %>" runat="server">
                                <button type="submit" name="dispatch"
                                    value="<%# Item.UserId %>">
                                    Отправить в службу поддержки</button>
                            </asp:PlaceHolder>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <!--<div id="ordersCheck">
        <asp:CheckBox ID="showDispatched" runat="server" Checked="false" AutoPostBack="true" />
        Показать отправленные в службу поддержки запросы?
    </div>-->
</asp:Content>