using ArtWebApi.Data;
using ArtWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWebApi.Controllers
//Check the Namespace that it has to be the same 
{
    [ApiController]
    [Route("api/Artists")]
    public class ArtistsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ArtistsController(AppDbContext context)
        {
            _context=context;
        }
        //GET: api/artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            var artists= await _context.Artists.ToListAsync();
            return Ok(artists);
        }
        //Get : api/artists/{id}
        [HttpGet("{id}")]
        public async  Task<ActionResult<IEnumerable<Artist>>> GetArtist(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            
            if (artist == null)
            {
                return NotFound();
            }
            return Ok(artist);
        }


        //PUT :api/artists
        [HttpPost]
        public async Task<ActionResult<Artist>> CreateArtist(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArtist),new {id=artist.ArtistId},artist);


        }

        //PUT: api/artists/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(int id,Artist artist)
        {
            if (id != artist.ArtistId)
            {
                return BadRequest();
            }
            _context.Entry(artist).State=EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if(!ArtistExistes(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return NoContent();
        }


        //DELETE : api/artists/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist= await _context.Artists.FindAsync(id);
            if (artist==null)
            {
                return NotFound();
            }
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool ArtistExistes(int id)
        {
            return _context.Artists.Any(e => e.ArtistId ==id);
        }

        


    }
}