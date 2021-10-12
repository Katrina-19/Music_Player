using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Player.Models
{
    public class PlayList
    {
        private List<ListLine> lineCollection = new List<ListLine>();


        public void AddItem(Song song)
        {
            ListLine line = lineCollection
                .Where(p => p.Song.SongId == song.SongId)
                .FirstOrDefault();
                lineCollection.Add(new ListLine
                {
                    Song = song,
                });
        }

        public void RemoveLine(Song song)
        {
            lineCollection.RemoveAll(l => l.Song.SongId == song.SongId);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<ListLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class ListLine
    {
        public Song Song { get; set; }
    }
}