using Anvil.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anvil.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{apiVersion:apiVersion}/pack")]
    public class PackInfoController : ControllerBase
    {
        private readonly ILogger<PackInfoController> _logger;

        public PackInfoController(ILogger<PackInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetPackRoot()
        {
            return Ok(new ErrorResponse
            {
                Error = "PackNotFoundException",
                Message = "The specified pack does not exists."
            });
        }

        [HttpGet]
        [Route("{id}/")]
        public IActionResult GetPackInfo(string id)
        {
            if (!id.Equals("test-pack", StringComparison.OrdinalIgnoreCase)) return Ok(new ErrorResponse
            {
                Error = "PackNotFoundException",
                Message = "The specified pack does not exists."
            });
            return Ok(new PackInfo
            {
                Id = id,
                Name = "Test pack",
                Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptate amet adipisci a sint architecto quisquam vero quis earum ex in voluptas et odio, voluptatum eius totam molestiae? Dignissimos, suscipit consequuntur?\nLorem ipsum dolor sit amet consectetur adipisicing elit. Vel assumenda qui nam optio ipsa? Libero atque numquam incidunt perferendis cum molestias ullam odio vero aspernatur id? Fuga libero impedit quis.\nLorem, ipsum dolor sit amet consectetur adipisicing elit. Ut vero hic est, dolor eum vitae quas earum voluptatibus sit error aliquid sint quam unde ex excepturi quasi atque. Natus, nesciunt!\nLorem ipsum dolor sit amet consectetur adipisicing elit. Sapiente ab reprehenderit dolore ipsum maxime iure, unde iusto voluptatem officiis natus fugit sed? Perferendis consequuntur dicta vero? Excepturi nulla quisquam fugiat.",
                Author = "Czompi",
                Contributors = null,
                Assets = new Dictionary<AssetType, Resource>() {
                    {
                        AssetType.Icon,
                        new Resource {
                            Url= new Uri("https://assets.example.com/path/to/icon.png"),
                            Hash = "hash-for-icon",
                        }
                    },
                    {
                        AssetType.Logo,
                        new Resource
                        {
                            Url = new Uri("https://assets.example.com/path/to/logo.png"),
                            Hash = "hash-for-background",
                        }
                    },
                    {
                        AssetType.Background, new Resource
                        {

                            Url = new Uri("https://assets.example.com/path/to/background.png"),
                            Hash = "hash-for-background",
                        }
                    }
                },
                Latest = new Dictionary<VersionType, string>()
                {
                    {VersionType.Release, "1.0.0" },
                    {VersionType.Snapshot, "1.0.1-Pre2" } // it will be null if the release the latest version
                },
                Versions = new Dictionary<string, string>()
                {
                    {"1.0.1-Pre2", "hash-of-version-response"}, // hash is required for checking local data
                    {"1.0.1-Pre1", "hash-of-version-response"},
                    {"1.0.0", "hash-of-version-response"},
                    {"1.0.0-Pre5", "hash-of-version-response"},
                    {"1.0.0-Pre4", "hash-of-version-response"},
                    {"1.0.0-Pre3", "hash-of-version-response"},
                    {"1.0.0-Pre2", "hash-of-version-response"},
                    {"1.0.0-Pre1", "hash-of-version-response"}

                }
            });
        }

        [HttpGet]
        [Route("{id}/{version}")]
        public IActionResult GetPackVersionInfo(string id, string version)
        {
            if (!id.Equals("test-pack", StringComparison.OrdinalIgnoreCase)) return Ok(new ErrorResponse
            {
                Error = "PackNotFoundException",
                Message = "The specified pack does not exists."
            });
            if (!version.Equals("1.0.0", StringComparison.OrdinalIgnoreCase)) return Ok(new ErrorResponse
            {
                Error = "PackVersionNotFoundException",
                Message = "The specified version does not exists."
            });
            var now = DateTime.Now;
            return Ok(new PackVersionInfo
            {
                Id = $"{id}:{version}",
                UpdateTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second),
                ReleaseTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second).AddDays(-1),
                Dependencies = new List<Dependency>()
                {
                    new Dependency
                    {
                        Id ="net.minecraftforge:forge:1.16.5-36.2.5",
                        Hash= "hash-of-forge"
                    }
                }
            });
        }
    }
}