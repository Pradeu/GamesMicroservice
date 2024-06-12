using AutoMapper;
using Game.API.Models;
using Game.DB;
using Microsoft.EntityFrameworkCore;
using Game.DB.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Game.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;

        public GameController(
            MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoGame>>> GetGamesAsync()
        {
            var dbGames = await _context.Games
                .Include(g => g.GenreGames)
                .ThenInclude(genres => genres.Genre)
                .Include(g => g.PlatformGames)
                .ThenInclude(platforms => platforms.Platform)
                .Include(g => g.EngineGames)
                .ThenInclude(engines => engines.Engine)
                .Include(g => g.DeveloperGames)
                .ThenInclude(developers => developers.Developer)
                .Include(g => g.UserLists).ToListAsync();
            return _mapper.Map<List<DtoGame>>(dbGames);
        }

        [HttpGet("query")]
        public async Task<IActionResult> GetQueryGamesAsync(string? s, string? sort, int? page)
        {

            var query = from games in _context.Games select games;
            int perPage = 30;
            int queryPage = page.GetValueOrDefault(1) == 0 ? 1 : page.GetValueOrDefault(1);
            
            if (!string.IsNullOrEmpty(s))
            {
                query = query.Where(p => p.Name.ToLower().Contains(s.ToLower()) || p.Description.ToLower().Contains(s.ToLower()));
            }

            if (sort == "asc")
            {
                query = query.OrderBy(p => p.Name);
            }
            else if (sort == "desc")
            {
                query = query.OrderByDescending(p => p.Name);
            }

            int total = query.Count();

            var dbGames = await query
                .Skip((queryPage - 1) * perPage)
                .Take(perPage)
                .Include(g => g.GenreGames)
                .ThenInclude(genres => genres.Genre)
                .Include(g => g.PlatformGames)
                .ThenInclude(platforms => platforms.Platform)
                .Include(g => g.EngineGames)
                .ThenInclude(engines => engines.Engine)
                .Include(g => g.DeveloperGames)
                .ThenInclude(developers => developers.Developer)
                .Include(g => g.UserLists).ToListAsync();

            var data = _mapper.Map<List<DtoGame>>(dbGames);
            return Ok(new { data,
                            queryPage,
                            total,
                            last_page = total / perPage});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DtoGame>> GetGamesByIdAsync(int id)
        {
            var dbGame = await _context.Games
                .Include(g => g.GenreGames)
                .ThenInclude(genres => genres.Genre)
                .Include(g => g.PlatformGames)
                .ThenInclude(platforms => platforms.Platform)
                .Include(g => g.EngineGames)
                .ThenInclude(engines => engines.Engine)
                .Include(g => g.DeveloperGames)
                .ThenInclude(developers => developers.Developer)
                .Include(g => g.UserLists)
                .FirstOrDefaultAsync(g => g.Id == id);
            if (dbGame == null)
            {
                return NotFound();
            }

            return _mapper.Map<DtoGame>(dbGame);


        }

        [HttpPost]

        public async Task<ActionResult<DtoGame>> PostGameAsync(
            [FromBody] DtoGame dtoGame
        )
        {
            var dbGame = _mapper.Map<DbGame>(dtoGame);

            _context.Games.Add(dbGame);
            await _context.SaveChangesAsync();

            dtoGame = _mapper.Map<DtoGame>(dbGame);

            return dtoGame;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            var data = await _context.Games.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            _context.Games.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}