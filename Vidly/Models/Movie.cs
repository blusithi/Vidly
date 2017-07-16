using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set;}
        [Required(ErrorMessage ="Please enter movie name")]
        [StringLength(45)]
        public string Name { get; set;}
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        [Display(Name = "Date Added")]
        public DateTime? DateAdded{ get; set; }
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }
        [Display(Name = "Number Available")]
        [Range(1, 20)]
        public int? NumberAvailable { get; set; }

    }
}