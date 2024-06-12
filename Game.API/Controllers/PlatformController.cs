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
    public class PlatformController : ControllerBase
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;

        public PlatformController(
            MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoPlatform>>> GetPlatformsAsync()
        {
            var dbPlatforms = await _context.Platforms.ToListAsync();
            return _mapper.Map<List<DtoPlatform>>(dbPlatforms);
        }

        [HttpPost]
        public async Task<ActionResult<DtoPlatform>> PostPlatformAsync(
        [FromBody] DtoPlatform dtoPlatform
)
        {
            var dbPlatform = _mapper.Map<DbPlatform>(dtoPlatform);

            _context.Platforms.Add(dbPlatform);
            await _context.SaveChangesAsync();

            dtoPlatform = _mapper.Map<DtoPlatform>(dbPlatform);

            return dtoPlatform;
        }
    }
}