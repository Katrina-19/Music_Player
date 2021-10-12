using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Player.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Name { get; set; }
        public string Singer { get; set; }
        public string Album { get; set; }
        public decimal Duration { get; set; }
    }
}