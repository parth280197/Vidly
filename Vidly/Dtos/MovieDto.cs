using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
  public class MovieDto
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public GenreDto Genre { get; set; }
    public DateTime? ReleasedDate { get; set; }
    public DateTime? AddedDate { get; set; }
    [Range(0, 20)]
    public int Stock { get; set; }
  }
}