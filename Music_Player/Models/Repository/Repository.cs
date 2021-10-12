using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Music_Player.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Song> Songs
        {
            get { return context.Songs; }
        }
        public IEnumerable<User> Users
        {
            get
            {
                return context.Users
                    .Include(o => o.UserLines.Select(ol => ol.Song));
            }
        }
        public IEnumerable<UserLine> UserLines
        {
            get { return context.UserLines; }
        }
        public void SaveSong(Song song)
        {
            if (song.SongId == 0)
            {
                song = context.Songs.Add(song);
            }
            else
            {
                Song dbSong = context.Songs.Find(song.SongId);
                if (dbSong != null)
                {
                    dbSong.Name = song.Name;
                    dbSong.Singer = song.Singer;
                    dbSong.Album = song.Album;
                    dbSong.Duration = song.Duration;
                }
            }
            context.SaveChanges();
        }

        public void DeleteSong(Song song)
        {
            IEnumerable<User> users = context.Users
                .Include(o => o.UserLines.Select(ol => ol.Song))
                .Where(o => o.UserLines
                    .Count(ol => ol.Song.SongId == song.SongId) > 0)
                .ToArray();

            foreach (User user in users)
            {
                context.Users.Remove(user);
            }
            context.Songs.Remove(song);
            context.SaveChanges();
        }
        public void SaveUsers(User user)
        {
            if (user.UserId == 0)
            {
                user = context.Users.Add(user);

                foreach (UserLine line in user.UserLines)
                {
                    context.Entry(line.Song).State
                        = EntityState.Modified;
                }

            }
            else
            {
                User dbUser = context.Users.Find(user.UserId);
                if (dbUser != null)
                {
                    dbUser.Name = user.Name;
                    dbUser.Email = user.Email;
                    dbUser.Password = user.Password;
                    dbUser.Dispatched = user.Dispatched;
                }
            }
            context.SaveChanges();
        }

        public void DeleteUserSong(UserLine userSong)
        {
            IEnumerable<UserLine> userLine = context.UserLines
                .ToArray();

            foreach (UserLine usersong in userLine)
            {
                context.UserLines.Remove(usersong);
            }
            context.SaveChanges();
        }
    }
}