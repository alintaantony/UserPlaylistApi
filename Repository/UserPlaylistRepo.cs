using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserPlaylistApi.Models;

namespace UserPlaylistApi.Repository
{
    public class UserPlaylistRepo : IUserPlaylistRepo
    {
        private readonly SpotifyDemoDbContext _context;

        public UserPlaylistRepo(SpotifyDemoDbContext context)
        {
            _context = context;
        }
        public async Task<PlaylistDetails> DeletePlaylist(int id)
        {
            PlaylistDetails playlistdata = await _context.PlaylistDetails.FindAsync(id);
            if (playlistdata == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                _context.PlaylistDetails.Remove(playlistdata);
                await _context.SaveChangesAsync();
            }
            return playlistdata;
        }

        public IEnumerable<PlaylistDetails> GetPlaylistDetails()
        {
            return _context.PlaylistDetails.ToList();
        }

        public PlaylistDetails GetPlaylistDetailsById(int id)
        {
            PlaylistDetails playlistdata = _context.PlaylistDetails.Find(id);
            return playlistdata;
        }

        public async Task<PlaylistDetails> PostPlaylist(PlaylistDetails playlist)
        {
            PlaylistDetails playlistdata = null;
            if (playlist == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                playlistdata = new PlaylistDetails() {Playlistname=playlist.Playlistname,Userid=playlist.Userid,Songid=playlist.Songid,Addeddate=playlist.Addeddate,Usersongplaycounter=playlist.Usersongplaycounter};
                await _context.PlaylistDetails.AddAsync(playlistdata);
                await _context.SaveChangesAsync();

            }
            return playlistdata;
        }

        public async Task<PlaylistDetails> UpdatePlaylist(int id, PlaylistDetails playlist)
        {
            PlaylistDetails playlistdata = await _context.PlaylistDetails.FindAsync(id);
            playlistdata.Songid = playlist.Songid;

            await _context.SaveChangesAsync();
            return playlistdata;
        }
    }
}
