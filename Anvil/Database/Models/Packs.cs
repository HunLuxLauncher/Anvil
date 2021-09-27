
namespace Anvil.Database.Models;

public class Packs
{
    public string Id { get; set; }

    public string Name { get; set; }
    
    public string Description { get; set; }

    public string Creator { get; set; }

    public string Contributors { get; set; }

    public string IconAssetUrl { get; set; }

    public string IconAssetHash { get; set; }

    public string LogoAssetUrl { get; set; }

    public string LogoAssetHash { get; set; }

    public string BackgroundAssetUrl { get; set; }

    public string BackgroundAssetHash { get; set; }

    public bool VisibleOnPublicList { get; set; }

}