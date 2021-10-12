<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlbumList.ascx.cs" 
   Inherits="Music_Player.Controls.AlbumList" %>

<%= CreateHomeLinkHtml() %>

<% foreach (string album in GetAlbums()) {
       Response.Write(CreateLinkHtml(album));       
}%>