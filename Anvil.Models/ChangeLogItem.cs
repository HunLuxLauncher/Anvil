using System.Text.Json.Serialization;

namespace Anvil.Models;

public class NewsItem
{
    public string Name { get; set; }

    public string Author { get; set; }

    public string Avatar { get; set; }
    
    public DateTime PostTime { get; set; }

    public string Description { get; set; }
    
    public Uri Url { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VersionType? OnlyIn { get; set; } = null;
}