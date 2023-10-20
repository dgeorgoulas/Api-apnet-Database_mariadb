using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArtWebApi.Models
{
    public class Gallery
    {
        [Key]
        public int GalleryId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
