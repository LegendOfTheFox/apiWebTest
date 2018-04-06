using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILesson.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILesson.Controllers
{
    [Produces("application/json")]
    [Route("api/Albums")]
    public class AlbumsController : Controller
    {
        //db
        private MusicStoreModel db;

        //constructor
        public AlbumsController(MusicStoreModel db)
        {
            this.db = db;
        }

        // GET: api/albums - return all albums
        [HttpGet]
        public IEnumerable<Album> Get()
        {
            return db.Albums.OrderBy(a => a.Title).ToList();
        }

        //Get: api/albums/400 - return a single album
        [HttpGet("{AlbumId}")]
        public IActionResult Get(int AlbumId)
        {
            var album = db.Albums.SingleOrDefault(a => a.AlbumId == AlbumId);
            
            if(album == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(album);
            }
        }

        // POST: a[i/albums - save a new album
        public IActionResult Post([FromBody] Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Albums.Add(album);
            db.SaveChanges();

            return CreatedAtAction("Get", new { AlbumId = album.AlbumId }, album);
        }


        //DELETE: api/albums/id - delete an album
        [HttpDelete("{AlbumId}")]
        public IActionResult Delete(int AlbumId)
        {
            var album = db.Albums.SingleOrDefault(a => a.AlbumId == AlbumId);

            if(album == null)
            {
                return NotFound();
            }

            db.Albums.Remove(album);
            db.SaveChanges();
            return Ok();
        }
    }
}