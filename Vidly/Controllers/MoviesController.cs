using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
  public class MoviesController : Controller
  {
    private ApplicationDbContext dbContext;

    public MoviesController()
    {
      dbContext = new ApplicationDbContext();
    }
    // GET: Movies
    public ActionResult Index()
    {
      if (User.IsInRole(RoleNames.CanManageMovies))
        return View("List");
      else
        return View("ReadOnlyList");
    }
    [Authorize(Roles = RoleNames.CanManageMovies)]
    public ActionResult Edit(int Id)
    {
      ViewBag.Action = "Update";
      var movie = dbContext.Movies.Find(Id);
      if (movie == null)
        return HttpNotFound();
      var viewModel = new MovieFormViewModel()
      {
        Movie = movie,
        Genre = dbContext.Genres.ToList()
      };
      return View("MovieForm", viewModel);
    }
    [Authorize(Roles = RoleNames.CanManageMovies)]
    public ActionResult Save()
    {
      ViewBag.Action = "Create new movie";
      var genre = dbContext.Genres.ToList();
      var viewModel = new MovieFormViewModel()
      {
        Genre = genre,
        Movie = new Movie(),
      };
      return View("MovieForm", viewModel);
    }

    [HttpPost]
    public ActionResult Save(Movie movie)
    {
      if (!ModelState.IsValid)
      {
        var ViewModel = new MovieFormViewModel()
        {
          Movie = new Movie(),
          Genre = dbContext.Genres.ToList(),
        };
        return View("MovieForm", ViewModel);
      }
      if (ModelState.IsValid)
      {
        if (movie.Id == 0)
          dbContext.Movies.Add(movie);
        else
        {
          var movieInDb = dbContext.Movies.Single(m => m.Id == movie.Id);
          movieInDb.AddedDate = movie.AddedDate;
          movieInDb.GenreId = movie.GenreId;
          movieInDb.Name = movie.Name;
          movieInDb.ReleasedDate = movie.ReleasedDate;
          movieInDb.Stock = movie.Stock;
        }
        dbContext.SaveChanges();
      }
      return RedirectToAction("Index", "Movies");
    }
  }
}