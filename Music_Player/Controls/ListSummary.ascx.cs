using System;
using System.Linq;
using Music_Player.Models;
using System.Web.Routing;
using Music_Player.Pages.Helpers;

namespace Music_Player.Controls
{
    public partial class ListSummary : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PlayList myList = SessionHelper.GetList(Session);
            csQuantity.InnerText = myList.Lines.Count().ToString();
            csLink.HRef = RouteTable.Routes.GetVirtualPath(null, "cart",
                null).VirtualPath;
        }
    }
}