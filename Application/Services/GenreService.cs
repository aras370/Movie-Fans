using Application.Interfaces;
using DataLayer;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GenreService : IGenre
    {

        Context _context;

        public GenreService(Context context)
        {
            _context = context;
        }


        public async Task<List<Genre>> GetAllGenres()
        {
            return await _context.Genres.ToListAsync();
        }
    }
}
