
using System.Text.Json.Serialization;

namespace Anvil.Models;
public class PackInfo : ErrorResponse
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Creator { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<NewsItem> News { get; set; } = null;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<string> Contributors { get; set; } = null;

    public IReadOnlyDictionary<AssetType, Resource> Assets { get; set; }
    
    public IReadOnlyDictionary<VersionType, string> Latest { get; set; }
    
    public IReadOnlyDictionary<string, string> Versions { get; set; }
}