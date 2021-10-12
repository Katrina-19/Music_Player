using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Music_Player.Models;
using Music_Player.Models.Repository;
using Music_Player.Pages.Helpers;
using System.Web.Routing;

namespace Music_Player.Pages
{
    public partial class ListView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Repository repository = new Repository();
                int gameId;
                if (int.TryParse(Request.Form["remove"], out gameId))
                {
                    Song songToRemove = repository.Songs
                        .Where(g => g.SongId == gameId).FirstOrDefault();
                    if (songToRemove != null)
                    {
                        SessionHelper.GetList(Session).RemoveLine(songToRemove);
                    }
                }
            }
        }

        public IEnumerable<ListLine> GetListLines()
        {
            return SessionHelper.GetList(Session).Lines;
        }

        public string ReturnUrl
        {
            get
            {
                return SessionHelper.Get<string>(Session, SessionKey.RETURN_URL);
            }
        }
        public string CheckoutUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "checkout",
                    null).VirtualPath;
            }
        }
    }
}