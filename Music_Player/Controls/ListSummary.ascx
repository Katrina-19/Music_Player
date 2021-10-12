<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListSummary.ascx.cs" 
   Inherits="Music_Player.Controls.ListSummary" %>

<div id="listSummary">
    <span class="caption">
        <b>В листе ожидания:</b>
        <span id="csQuantity" runat="server"></span> треков
        <span id="csTotal" runat="server"></span>
    </span>
    <a id="csLink" runat="server">Лист ожидания</a>
</div>