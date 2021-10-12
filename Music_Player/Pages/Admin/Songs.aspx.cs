using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Music_Player.Models;
using Music_Player.Models.Repository;
using System.Web.ModelBinding;

namespace Music_Player.Pages.Admin
{
    public partial class Songs : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Song> GetSongs()
        {
            return repository.Songs;
        }

        public void UpdateSong(int SongID)
        {
            Song mySong = repository.Songs
                .Where(p => p.SongId == SongID).FirstOrDefault();
            if (mySong != null && TryUpdateModel(mySong,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveSong(mySong);
            }
        }

        public void DeleteSong(int SongID)
        {
            Song mySong = repository.Songs
                .Where(p => p.SongId == SongID).FirstOrDefault();
            if (mySong != null)
            {
                repository.DeleteSong(mySong);
            }
        }

        public void InsertSong()
        {
            Song mySong = new Song();
            if (TryUpdateModel(mySong,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveSong(mySong);
            }
        }
    }
}