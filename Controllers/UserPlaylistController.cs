using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserPlaylistApi.Models;
using UserPlaylistApi.Repository;

namespace UserPlaylistApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPlaylistController : ControllerBase
    {
        private readonly IUserPlaylistRepo _userplaylistrepo;

        public UserPlaylistController(IUserPlaylistRepo userPlaylistRepo)
        {
            _userplaylistrepo = userPlaylistRepo;
        }

        [HttpGet]
        public IEnumerable<PlaylistDetails> GetAllPlaylistDetails()
        {
            return _userplaylistrepo.GetPlaylistDetails();
        }

        [HttpGet("{id}")]
        public IActionResult GetPlaylistById(int id)
        {
            try
            {
                var playlist = _userplaylistrepo.GetPlaylistDetailsById(id);
                if (playlist == null)
                {
                    return NotFound();
                }
                return Ok(playlist);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostPlaylist(PlaylistDetails playlist)
        {
            try
            {
                var addplaylist = await _userplaylistrepo.PostPlaylist(playlist);
                return Ok(addplaylist);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdatePlaylist(int id, PlaylistDetails playlist)
        {
            try
            {
                var updateplaylist = await _userplaylistrepo.UpdatePlaylist(id, playlist);
                return Ok(updateplaylist);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            try
            {
                var deleteplaylist = await _userplaylistrepo.DeletePlaylist(id);
                return Ok(deleteplaylist);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
