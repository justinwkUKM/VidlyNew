﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyNew.Models;
using System.Data.Entity;
using VidlyNew.ViewModels;

namespace VidlyNew.Controllers
//{
//    public class MoviesController : Controller
//    {
//        //// GET: Movies
//        //public ActionResult Index(int? pageIndex, string sortBy)
//        //{
//        //    if (!pageIndex.HasValue) {
//        //        pageIndex = 1;
//        //    }

//        //    if (String.IsNullOrWhiteSpace(sortBy)) {
//        //        sortBy = "Name";
//        //    }

//        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));


//        //}

//        // GET: Movies
//        public ViewResult Index()
//        {
//            var movies = GetMovies();
//            return View(movies);
//        }

//        private IEnumerable<Movie> GetMovies()
//        {
//            return new List<Movie>
//            {
//                new Movie { Id = 1, Name = "Shrek" },
//                new Movie { Id = 2, Name = "Wall-e" }
//            };
//        }

//        // GET: Movies/Random
//        public ActionResult Random()
//        {
//            var movie = new Movie() { Name = "Anabelle!" };
//            var customers = new List<Customer> {
//                new Customer {Name = "Nurhazarifah" },
//                new Customer {Name = "Asra Khalid" }
//            };

//            var viewModel = new RandomMovieViewModel {
//                Movie = movie,
//                Customers = customers
//            };


//            //ViewData["Movie"] = movie;
//            //ViewBag.Movie = movie;    

//            //*similar to Bundle in android
//            //var viewResult = new ViewResult();
//            //viewResult.ViewData.Model;

//            return View(viewModel);

//            //return Content("Hi");
//            //return HttpNotFound();
//            //return new HttpNotFoundResult();
//            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name", filterBy = "electronics" });
//        }

//        // GET: Movies/Edit/id

//        public ActionResult Edit(int id)
//        {

//            return Content("id=" + id);
//        }

//        // GET: Movies/released/year/month
//        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
//        public ActionResult ByReleaseDate(int year, int month)
//        {

//            return Content(year + "/" + month);
//        }
//    }
//}

//namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }




        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }


        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }




        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

    }




}