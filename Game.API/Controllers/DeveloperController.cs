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
    public class DeveloperController : ControllerBase
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;

        public DeveloperController(
            MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoDeveloper>>> GetDevelopersAsync()
        {
            var dbDevelopers = await _context.Developers.ToListAsync();
            return _mapper.Map<List<DtoDeveloper>>(dbDevelopers);
        }

        [HttpPost]
        public async Task<ActionResult<DtoDeveloper>> PostDeveloperAsync(
        [FromBody] DtoDeveloper dtoDeveloper
)
        {
            var dbDeveloper = _mapper.Map<DbDeveloper>(dtoDeveloper);

            _context.Developers.Add(dbDeveloper);
            await _context.SaveChangesAsync();

            dtoDeveloper = _mapper.Map<DtoDeveloper>(dbDeveloper);

            return dtoDeveloper;
        }
    }
}
