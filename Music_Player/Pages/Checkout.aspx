<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" 
    Inherits="Music_Player.Pages.Checkout"
    MasterPageFile="~/Pages/Player.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">

        <div id="checkoutForm" class="checkout" runat="server">
            <h2>Скачать</h2>
            Пожалуйста, введите свои данные!

        <div id="errors" data-valmsg-summary="true">
            <ul>
                <li style="display:none"></li>
            </ul>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>

            <h3>Пользователь</h3>
            <div>
                <label for="name">Имя:</label>
               <SX:VInput Property="Name" runat="server" />
            </div>
            <div>
                <label for="email">Email:</label>
                <SX:VInput Property="Email" runat="server" />
            </div>
            <div>
                <label for="password">Password:</label>
                <SX:VInput Property="Password" runat="server" />
            </div>
        <p class="actionButtons">
            <button class="actionButtons" type="submit">Скачать</button>
        </p>
        </div>
        <div id="checkoutMessage" runat="server">
            <h2>Скачивание начнется через пару секунд</h2>
        </div>
    </div>
</asp:Content>