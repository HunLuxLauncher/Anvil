
namespace Anvil.Models;

public class PackList : ErrorResponse
{
    public PackList(IReadOnlyDictionary<string, string> packs, Uri repositoryUrl)
    {
        Packs = packs;
        RepositoryUrl = repositoryUrl;
    }
    public IReadOnlyDictionary<string, string> Packs { get; }
    public Uri RepositoryUrl { get; }
}
