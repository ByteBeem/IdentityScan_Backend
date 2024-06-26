using IdentityScan_Server.Models;
using IdentityScan_Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityScan_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IdentityRepository _identityRepository;

        public IdentityController(IdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddIdentity([FromBody] Identity identity)
        {
            await _identityRepository.AddIdentity(identity);
            return Ok(new { Message = "Identity added successfully" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdentity(string id)
        {
            var identity = await _identityRepository.GetIdentity(id);
            if (identity == null)
            {
                return NotFound();
            }
            return Ok(identity);
        }
    }
}
