using System.Text.Json.Serialization;

namespace Anvil.Models;

public class Resource
{
    public Uri Url { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Hash { get; set; } = null;
}
