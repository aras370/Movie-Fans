using Application;
using Microsoft.AspNetCore.Mvc;

namespace Presentation
{
    public class GenresViewComponenet:ViewComponent
    {
        IGenre _genre;

        public GenresViewComponenet(IGenre genre)
        {
            _genre = genre;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres=await _genre.GetAllGenres();
            return await Task.FromResult((IViewComponentResult)View("Genres",genres));
        }

    }
}
