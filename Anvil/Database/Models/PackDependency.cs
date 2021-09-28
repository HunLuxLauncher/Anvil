
namespace Anvil.Database.Models;

public class PackDependency
{
    public int Id {  get; set; }
    public string PackId {  get; set; }
    public int PackVersionId {  get; set; }
    public string ModId {  get; set; }
    public int ModVersionId {  get; set; }

    public virtual Pack Pack {  get; set; }
    public virtual PackVersion Version {  get; set; }
    public virtual Mod Mod {  get; set; }
    public virtual ModVersion ModVersion {  get; set; }
}
