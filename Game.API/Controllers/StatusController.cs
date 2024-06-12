using AutoMapper;
using Game.API.Models;
using Game.DB;
using Game.DB.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Game.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;

        public StatusController(
            MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoUserStatus>>> GetStatusesAsync()
        {
            var dbStatuses = await _context.GameStatuses.ToListAsync();
            return _mapper.Map<List<DtoUserStatus>>(dbStatuses);
        }

        [HttpPost]
        public async Task<ActionResult<DtoUserStatus>> PostStatusAsync(
        [FromBody] DtoUserStatus dtoStatus
)
        {
            var dbStatus = _mapper.Map<DbUserStatus>(dtoStatus);

            _context.GameStatuses.Add(dbStatus);
            await _context.SaveChangesAsync();

            dtoStatus = _mapper.Map<DtoUserStatus>(dbStatus);

            return dtoStatus;
        }
    }
}
