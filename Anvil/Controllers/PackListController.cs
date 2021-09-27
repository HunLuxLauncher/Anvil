using Anvil.Database;
using Anvil.Extensions;
using Anvil.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anvil.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{apiVersion:apiVersion}/packs")]
    public class PackListController : ControllerBase
    {
        private readonly ILogger<PackListController> _logger;
        private readonly AnvilDatabaseContext _context;

        public PackListController(ILogger<PackListController> logger, AnvilDatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetPackList()
        {
            var packTable = _context.Packs.Where(pack => pack.VisibleOnPublicList).ToList();
            return Ok(new PackList(packTable.ToPackListDictionary($"{Request.Scheme}://{Request.Host.Value}"), new Uri("https://anvil.example.com")));
        }

    }
}