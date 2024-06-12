using AutoMapper;
using Game.API.Models;
using Game.DB;
using Game.DB.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Game.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;

        public GenreController(
            MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoGenre>>> GetGenresAsync()
        {
            var dbGenres = await _context.Genres
                .ToListAsync();
            return _mapper.Map<List<DtoGenre>>(dbGenres);
        }

        [HttpPost]
        public async Task<ActionResult<DtoGenre>> PostGenreAsync(
        [FromBody] DtoGenre dtoGenre)
        {
            var dbGenre = _mapper.Map<DbGenre>(dtoGenre);

            _context.Genres.Add(dbGenre);
            await _context.SaveChangesAsync();

            dtoGenre = _mapper.Map<DtoGenre>(dbGenre);

            return dtoGenre;
        }
    }
}