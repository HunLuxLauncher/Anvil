using Anvil.Database;
using Anvil.Extensions;
using Anvil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anvil.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{apiVersion:apiVersion}/pack")]
    public class PackInfoController : ControllerBase
    {
        private readonly ILogger<PackInfoController> _logger;
        private readonly AnvilDatabaseContext _context;

        public PackInfoController(ILogger<PackInfoController> logger, AnvilDatabaseContext context)
        {
            _logger = logger;
            _context = context;
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
            var packTable = _context.Packs.Where(pack =>pack.Id.ToLower().Equals(id.ToLower())).ToList();
            var packNewsTable = _context.PackNews.Where(pack =>pack.PackId.ToLower().Equals(id.ToLower())).ToList();
            var packVersionsTable = _context.PackVersions.Where(pack =>pack.PackId.ToLower().Equals(id.ToLower())).ToList();

            if (!packTable.Any()) return NotFound(new ErrorResponse
            {
                Error = "PackNotFoundException",
                Message = "The specified pack does not exists."
            });
            var now = DateTime.Now;
            now = new(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            var data = packTable.First();
            var news = packNewsTable;
            return Ok(new PackInfo
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description,
                Creator = data.Creator,
                Contributors = data.Contributors is not null ? (data.Contributors.Contains(';') ? data.Contributors.Split(";").ToList() : new List<string> { data.Contributors }) : null,
                News = news.Count is 0 ? null: news.Select(x => new NewsItem()
                {
                    Author = x.Author,
                    Avatar = x.Avatar is null ? $"https://minotar.net/avatar/{x.Author}/64" : x.Avatar,
                    Name = x.Title,
                    Description = x.Description,
                    OnlyIn = x.OnlyIn.ToEnum<VersionType>(),
                    PostTime = x.PostTime,
                    Url = x.Url is null ? new($"https://packs.hunluxlauncher.hu/en-us/{id}/?changelog={x.Version.Name}") : new(x.Url)
                }).ToList(),
                Assets = new Dictionary<AssetType, Resource>() {
                    {
                        AssetType.Icon,
                        new Uri($"https://assets.example.com/modpack/{id}/icon.png").GetResource(data.IconAssetHash)
                    },
                    {
                        AssetType.Logo,
                        new Uri($"https://assets.example.com/modpack/{id}/logo.png").GetResource(data.LogoAssetHash)
                    },
                    {
                        AssetType.Background,
                        new Uri($"https://assets.example.com/modpack/{id}/background.png").GetResource(data.BackgroundAssetHash)
                    }
                },
                Latest = packVersionsTable.ToVersionTypeDictionary(),
                Versions = packVersionsTable.Select(pv => new KeyValuePair<string, string>(pv.Name, pv.Hash ?? pv.CalculateHash($"{Request.Scheme}://{Request.Host.Value}"))).ToDictionary(x => x.Key, x => x.Value)
            });
        }

        [HttpGet]
        [Route("{id}/{version}")]
        public IActionResult GetPackVersionInfo(string id, string version)
        {
            var packTable = _context.Packs.Where(pack => pack.Id.ToLower().Equals(id.ToLower())).ToList();
            var packVersionsTable = _context.PackVersions.Where(pack => pack.PackId.ToLower().Equals(id.ToLower()) && pack.Name.ToLower().Equals(version.ToLower())).ToList();
            var packDependenciesTable = _context.PackDependencies.Where(pack => pack.PackId.ToLower().Equals(id.ToLower()) && pack.Version.Name.ToLower().Equals(version.ToLower())).ToList();
            if (!packTable.Any()) return NotFound(new ErrorResponse
            {
                Error = "PackNotFoundException",
                Message = "The specified pack does not exists."
            });
            if (!packVersionsTable.Any()) return NotFound(new ErrorResponse
            {
                Error = "PackVersionNotFoundException",
                Message = "The specified version does not exists."
            });
            var pv = packVersionsTable.First();
            return Ok(new PackVersionInfo
            {
                Id = $"{pv.PackId}:{pv.Name}",
                UpdateTime = pv.UpdateTime,
                ReleaseTime = pv.ReleaseTime,
                Dependencies = packDependenciesTable.Count is 0 ? null:packDependenciesTable.Select(dependency => new Dependency
                {
                    Id = $"{dependency.Mod.Name}:{dependency.ModVersion.Name}",
                    Hash = $"{dependency.ModVersion.Hash}"
                }).ToList()
            });
        }
    }
}