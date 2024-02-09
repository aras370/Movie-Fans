using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IMovie
    {

        Task<List<Movie>> GetAllMovie();

        Task CreateMovie(CreateMovieViewModel movie);

    }
}
