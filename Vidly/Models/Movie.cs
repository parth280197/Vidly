using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
  public class Movie
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Display(Name = "Genre")]
    public int GenreId { get; set; }
    public virtual Genre Genre { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
    [Required]
    public DateTime? ReleasedDate { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
    [Required]
    public DateTime? AddedDate { get; set; }

    [Range(0, 20)]
    public int Stock { get; set; }
  }

  public class Genre
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}