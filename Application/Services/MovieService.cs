
using DataLayer;
using DataLayer.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class MovieService : IMovie
    {

        Context _context;

        public MovieService(Context context)
        {
            _context = context;
        }

        public async Task CreateMovie(CreateMovieViewModel movie)
        {
            var Movie = new Movie()
            {
                GenreId = movie.GenreId,
                DateOfMake = movie.DateOfMake,
                MovieName = movie.MovieName,
                ImageName = NameGenerator.GenerateUnique() + Path.GetExtension(movie.MovieAvatar.FileName)

            };

            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/MoviesImages", Movie.ImageName);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
               movie.MovieAvatar.CopyTo(stream);
            }

            _context.Add(Movie);

            await _context.SaveChangesAsync();

        }



        public async Task<List<Movie>> GetAllMovie()
        {

            return await _context.Movies.Include(m=>m.Genre).ToListAsync();

        }

    }


}

