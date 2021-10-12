using System;
using System.Collections.Generic;
using Music_Player.Models;
using Music_Player.Models.Repository;
using System.Linq;
using Music_Player.Pages.Helpers;
using System.Web.Routing;

namespace Music_Player.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int selectedSongId;
                if (int.TryParse(Request.Form["add"], out selectedSongId))
                {
                    Song selectedSong = repository.Songs
                        .Where(g => g.SongId == selectedSongId).FirstOrDefault();

                    if (selectedSong != null)
                    {
                        SessionHelper.GetList(Session).AddItem(selectedSong);
                        SessionHelper.Set(Session, SessionKey.RETURN_URL,
                            Request.RawUrl);

                        Response.Redirect(RouteTable.Routes
                            .GetVirtualPath(null, "cart", null).VirtualPath);
                    }
                }
            }
        }
        private Repository repository = new Repository();
        private int pageSize = 6;

        protected int CurrentPage
        {
            get
            {
                int page;
                page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                int songCount = FilterSongs().Count();
                return (int)Math.Ceiling((decimal)songCount / pageSize);
            }
        }

        private int GetPageFromRequest()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ??
                Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }

        public IEnumerable<Song> GetSongs()
        {
            return FilterSongs()
                .OrderBy(g => g.SongId)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }

        private IEnumerable<Song> FilterSongs()
        {
            IEnumerable<Song> songs = repository.Songs;
            string currentAlbum = (string)RouteData.Values["album"] ??
                Request.QueryString["album"];
            return currentAlbum == null ? songs :
                songs.Where(p => p.Album == currentAlbum);
        }

       
    }
}