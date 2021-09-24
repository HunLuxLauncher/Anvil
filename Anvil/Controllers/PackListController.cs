using Anvil.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anvil.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{apiVersion:apiVersion}/packs")]
    public class PackListController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPackList()
        {

            return Ok(new PackList(new Dictionary<string, string>()
                {
                    {"test-pack", "thisisarandomhash" },
                    {"vanilla", "thisisarandomhash" }
                }, new Uri("https://anvil.example.com")));
        }

    }
}