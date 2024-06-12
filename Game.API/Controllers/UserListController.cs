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
    public class UserListController : ControllerBase
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;
        public UserListController(
            MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<List<DtoUserList>>> GetUserList(int UserId, int GameId, int StatusId)
        {
            var gameList = new List<DbUserList>();
            if (UserId > 0 && GameId > 0) {
                if (StatusId > 0)
                {
                    gameList = await _context.UserLists
                    .Include(g => g.Game.Genres)
                    .Include(g => g.Game.Platforms)
                    .Include(g => g.Game.Engines)
                    .Include(g => g.Game.Developers)
                    .Where(q => q.UserId == UserId && q.StatusId == StatusId)
                    .ToListAsync();
                }
                else {
                    gameList = await _context.UserLists
                    .Include(g => g.Game.Genres)
                    .Include(g => g.Game.Platforms)
                    .Include(g => g.Game.Engines)
                    .Include(g => g.Game.Developers)
                    .Where(q => q.UserId == UserId && q.GameId == GameId)
                    .ToListAsync();
                }
            }
            else {
                gameList = await _context.UserLists
                .Include(g => g.Game.Genres)
                .Include(g => g.Game.Platforms)
                .Include(g => g.Game.Engines)
                .Include(g => g.Game.Developers)
                .Where(q => q.UserId == UserId || q.GameId == GameId)
                .ToListAsync();
            }
                
            return _mapper.Map<List<DtoUserList>>(gameList);
        }


        [HttpPost("addgame")]
        public async Task<ActionResult<DtoUserList>> PostUserGameList(
            [FromBody] DtoUserList dtoUserList
            )
        {
            var gameList = new DtoUserList
            {
                UserId = dtoUserList.UserId,
                GameId = dtoUserList.GameId,
            };
            var dbUserGame = _mapper.Map<DbUserList>(gameList);
            var dbGame = _context.Games.First(g => g.Id == gameList.GameId);

            foreach (var i in dbGame.Genres)
            {
                var dbGenre = _context.Genres.First(g => g.Id == i.Id);

            }

            _context.UserLists.Add(dbUserGame);
            await _context.SaveChangesAsync();

            dtoUserList = _mapper.Map<DtoUserList>(dbUserGame);

            return dtoUserList;
        }

        [HttpPost("updategamestatus")]
        public async Task<ActionResult<DtoUserList>> UpdateGameStatus(int StatusId, int GameId, int UserId, DtoUserList dtoUserList)
        {
            var userList = _context.UserLists
                .Include(j => j.UserStatus)
                .First(j => j.UserId == UserId && j.GameId == GameId);

            userList.StatusId = StatusId;
            await _context.SaveChangesAsync();
            dtoUserList = _mapper.Map<DtoUserList>(userList);
            return dtoUserList;

        }

        [HttpPost("updatescore")]
        public async Task<ActionResult<DtoUserList>> UpdateGameScore(int Score, int GameId, int UserId, DtoUserList dtoUserList)
        {
            var userList = _context.UserLists
                .Include(j => j.UserStatus)
                .First(j => j.UserId == UserId && j.GameId == GameId);

            userList.UserScore = Score;
            await _context.SaveChangesAsync();
            var game = _context.Games.First(j => j.Id == GameId);
            float avgScore = (float)_context.UserLists.Where(j => j.GameId == GameId).Sum(s => s.UserScore) / _context.UserLists.Where(j => j.GameId == GameId).Count(j => j.UserScore > 0);
            game.Score = avgScore;
            game.ScoresCount = _context.UserLists.Where(j => j.GameId == GameId).Count(j => j.UserScore > 0);
            await _context.SaveChangesAsync();
            dtoUserList = _mapper.Map<DtoUserList>(userList);
            return dtoUserList;

        }


        [HttpPost("deletegame")]
        public async Task<ActionResult<DtoUserList>> DeleteUserGameList(int UserId, int GameId)
        {
            var data = await _context.UserLists.FirstOrDefaultAsync(game => game.UserId == UserId && game.GameId == GameId);

            if (data == null)
            {
                return NotFound();
            }

            _context.UserLists.Remove(data);
            await _context.SaveChangesAsync();

            return Ok("Игра успешно удалена из списка");
        }
    }
}
