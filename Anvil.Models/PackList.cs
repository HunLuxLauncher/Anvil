
namespace Anvil.Models;

public class PackList : ErrorResponse
{
    public PackList(Dictionary<string, string> packs, Uri repositoryUrl)
    {
        Packs = packs;
        RepositoryUrl = repositoryUrl;
    }
    public Dictionary<string, string> Packs { get; }
    public Uri RepositoryUrl { get; }
}
