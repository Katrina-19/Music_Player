using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Music_Player
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(null, "list/{category}/{page}", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "list/{page}", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "list", "~/Pages/Listing.aspx");
            routes.MapPageRoute("cart", "cart", "~/Pages/ListView.aspx");
            routes.MapPageRoute("checkout", "checkout", "~/Pages/Checkout.aspx");
            routes.MapPageRoute("admin_users", "admin/users", "~/Pages/Admin/Users.aspx");
            routes.MapPageRoute("admin_songs", "admin/songs", "~/Pages/Admin/Songs.aspx");
            routes.MapPageRoute("user_songs", "user/songs", "~/Pages/UserPL/UserPlL.aspx");
        }
    }
}