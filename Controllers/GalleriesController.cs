using ArtWebApi.Data;
using ArtWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWebApi.Controllers
{
    [ApiController]
    [Route("api/galleries")]
    public class GalleriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GalleriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/galleries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gallery>>> GetGalleries()
        {
            var galleries = await _context.Galleries.ToListAsync();
            return Ok(galleries);
        }

        // GET: api/galleries/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Gallery>> GetGallery(int id)
        {
            var gallery = await _context.Galleries.FindAsync(id);

            if (gallery == null)
            {
                return NotFound();
            }

            return Ok(gallery);
        }

        // POST: api/galleries
        [HttpPost]
        public async Task<ActionResult<Gallery>> CreateGallery(Gallery gallery)
        {
            _context.Galleries.Add(gallery);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGallery), new { id = gallery.GalleryId }, gallery);
        }

        // PUT: api/galleries/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGallery(int id, Gallery gallery)
        {
            if (id != gallery.GalleryId)
            {
                return BadRequest();
            }

            _context.Entry(gallery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalleryExists(id))
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

        // DELETE: api/galleries/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGallery(int id)
        {
            var gallery = await _context.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }

            _context.Galleries.Remove(gallery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GalleryExists(int id)
        {
            return _context.Galleries.Any(e => e.GalleryId == id);
        }
    }
}
