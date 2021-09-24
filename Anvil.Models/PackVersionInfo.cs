
namespace Anvil.Models;
public class PackVersionInfo : ErrorResponse
{
    public string Id { get; set; }
    public DateTime UpdateTime { get; set; }
    public DateTime ReleaseTime { get; set; }
    public List<Dependency> Dependencies { get; set; }
}