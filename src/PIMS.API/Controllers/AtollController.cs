using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PIMS.API.Data;

namespace PIMS.API.Controllers
{
    [ApiController]
    [Route("api/atolls")]
    public class AtollController : ControllerBase
    {
        private readonly PIMSContext _context;
        private readonly ILogger _logger;

        public AtollController(PIMSContext context, ILogger<AtollController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var atolls = await _context.Atolls.ToListAsync();

            return Ok(atolls);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAtoll(int id)
        {
            try
            {
               var atoll = await _context.Atolls.Where(a => a.Id == id).Include(a => a.Islands).FirstOrDefaultAsync();
                
                return Ok(atoll);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
