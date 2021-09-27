
namespace Anvil.Database.Models;

public class PackVersions
{
    public int Id {  get; set; }
    
    public string PackId {  get; set; }
    
    public string Name {  get; set; }
    
    public DateTime UpdateTime {  get; set; }
    
    public DateTime ReleaseTime {  get; set; }

    public string Type {  get; set; }
    public string Hash {  get; set; }
    
    public virtual Packs Pack {  get; set; }
}
