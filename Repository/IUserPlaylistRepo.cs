using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserPlaylistApi.Models;

namespace UserPlaylistApi.Repository
{
    public interface IUserPlaylistRepo
    {
        IEnumerable<PlaylistDetails> GetPlaylistDetails();

        PlaylistDetails GetPlaylistDetailsById(int id);

        Task<PlaylistDetails> UpdatePlaylist(int id, PlaylistDetails playlist);

        Task<PlaylistDetails> PostPlaylist(PlaylistDetails playlist);

        Task<PlaylistDetails> DeletePlaylist(int id);
    }
}
