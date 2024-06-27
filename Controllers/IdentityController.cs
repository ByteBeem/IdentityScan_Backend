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
        private readonly VersionRepository _versionRepository;

        public IdentityController(IdentityRepository identityRepository, VersionRepository versionRepository)
        {
            _identityRepository = identityRepository;
            _versionRepository = versionRepository;
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

        [HttpGet("appVersion")]
        public async Task<IActionResult> GetAppVersion(string currentVersion)
        
        {
            var version = await _versionRepository.GetAppVersion(currentVersion);
            if(version == null){
                return NotFound();
            }
            return Ok(version);
        }

        [HttpPost("addAppVersion")]
        public async Task<IActionResult> AddVersion([FromBody] AppVersions version)
        {
            await _versionRepository.AddVersion(version);
            return Ok(new { Message = "version added successfully" });
        }
    }
}
