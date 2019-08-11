﻿using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModel
{
  public class MovieFormViewModel
  {
    public Movie Movie { get; set; }
    public IEnumerable<Genre> Genre { get; set; }
  }
}