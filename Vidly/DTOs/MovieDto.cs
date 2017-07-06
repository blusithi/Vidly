using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter movie name")]
        [StringLength(45)]
        public string Name { get; set; }
        public byte GenreId { get; set; }
        public GenreDto Genre { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }
        [Range(1, 20)]
        public int? NumberInStock { get; set; }
    }
}