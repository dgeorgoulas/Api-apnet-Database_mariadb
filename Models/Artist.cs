using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArtWebApi.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        [Required]
        public string Name { get; set; }
        public int? GalleryId { get; set; }
       public Gallery Gallery { get; set; }
    }
}
