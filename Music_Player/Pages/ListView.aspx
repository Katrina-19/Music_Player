<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListView.aspx.cs" Inherits="Music_Player.Pages.ListView" MasterPageFile="~/Pages/Player.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <h2>Лист ожидания скачивания</h2>
        <table id="cartTable">
            <thead>
                <tr>
                    <th>Название</th>
                    <th>Исполнитель</th>
                    <th>Длительность</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" ItemType="Music_Player.Models.ListLine"
                    SelectMethod="GetListLines" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.Song.Name %></td>
                            <td><<!--%# Item.Song.Singer%-->></td>
                            <td><%# Item.Song.Duration%></td>
                            <td>
                            <button type="submit" class="actionButtons" name="remove"
                                    value="<%#Item.Song.SongId %>">
                                    Удалить</button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <p class="actionButtons">
            <a href="<%=ReturnUrl%>">Продолжить обзор</a>
            <a href="<%= CheckoutUrl %>">Скачать</a>
        </p>
    </div>
</asp:Content>