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
    public class EngineController : ControllerBase
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;

        public EngineController(
            MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoEngine>>> GetEnginesAsync()
        {
            var dbEngines = await _context.Engines.ToListAsync();
            return _mapper.Map<List<DtoEngine>>(dbEngines);
        }

        [HttpPost]
        public async Task<ActionResult<DtoEngine>> PostEngineAsync(
        [FromBody] DtoEngine dtoEngine
)
        {
            var dbEngine = _mapper.Map<DbEngine>(dtoEngine);

            _context.Engines.Add(dbEngine);
            await _context.SaveChangesAsync();

            dtoEngine = _mapper.Map<DtoEngine>(dbEngine);

            return dtoEngine;
        }
    }
}
