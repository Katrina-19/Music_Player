using System;
using System.Web.Routing;

namespace Music_Player.Pages.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        public string UsersUrl
        {
            get
            {
                return generateURL("admin_users");
            }
        }

        public string SongsUrl
        {
            get
            {
                return generateURL("admin_songs");
            }
        }

        private string generateURL(string routeName)
        {
            return RouteTable.Routes.GetVirtualPath(null, routeName, null).VirtualPath;
        }
    }
}