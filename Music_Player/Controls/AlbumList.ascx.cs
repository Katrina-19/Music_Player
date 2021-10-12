using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using Music_Player.Models.Repository;

namespace Music_Player.Controls
{
    public partial class AlbumList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected IEnumerable<string> GetAlbums()
        {
            return new Repository().Songs
                .Select(p => p.Album)
                .Distinct()
                .OrderBy(x => x);
        }

        protected string CreateHomeLinkHtml()
        {
            string path = RouteTable.Routes.GetVirtualPath(null, null).VirtualPath;
            return string.Format("<a href='{0}'>Главная</a>", path);
        }

        protected string CreateLinkHtml(string album)
        {

            string selectedAlbum = (string)Page.RouteData.Values["album"]
                ?? Request.QueryString["album"];

            string path = RouteTable.Routes.GetVirtualPath(null, null,
                new RouteValueDictionary() { { "album", album },
                    {"page", "1"} }).VirtualPath;

            return string.Format("<a href='{0}' {1}>{2}</a>",
                path, album == selectedAlbum ? "class='selected'" : "", album);
        }
    }
}