<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Songs.aspx.cs" Inherits="Music_Player.Pages.Admin.Songs"
    MasterPageFile="~/Pages/Admin/Admin.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="ListView1" ItemType="Music_Player.Models.Song" SelectMethod="GetSongs"
        DataKeyNames="SongId" UpdateMethod="UpdateSong" DeleteMethod="DeleteSong"
        InsertMethod="InsertSong" InsertItemPosition="LastItem" EnableViewState="false"
        runat="server">
        <LayoutTemplate>
            <div class="outerContainer">
                <table id="productsTable">
                    <tr>
                        <th>Название</th>
                        <th>Исполнитель</th>
                        <th>Альбом</th>
                        <th>Длительность</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.Name %></td>
                <td class="description"><span><%# Item.Singer %></span></td>
                <td><%# Item.Album %></td>
                <td><%# Item.Duration%></td>
                <td>
                    <asp:Button ID="Button1" CommandName="Edit" Text="Изменить" runat="server" />
                    <asp:Button ID="Button2" CommandName="Delete" Text="Удалить" runat="server" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <input name="name" value="<%# Item.Name %>" />
                    <input type="hidden" name="SongID" value="<%# Item.SongId %>" />
                </td>
                <td>
                    <input name="singer" value="<%# Item.Singer %>" /></td>
                <td>
                    <input name="album" value="<%# Item.Album %>" /></td>
                <td>
                    <input name="duration" value="<%# Item.Duration %>" /></td>
                <td>
                    <asp:Button ID="Button3" CommandName="Update" Text="Обновить" runat="server" />
                    <asp:Button ID="Button4" CommandName="Cancel" Text="Отмена" runat="server" />
                </td>
            </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
            <tr>
                <td>
                    <input name="name" />
                    <input type="hidden" name="SongID" value="0" />
                </td>
                <td>
                    <input name="singer" /></td>
                <td>
                    <input name="album" /></td>
                <td>
                    <input name="duration" /></td>
                <td>
                    <asp:Button ID="Button5" CommandName="Insert" Text="Вставить" runat="server" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>