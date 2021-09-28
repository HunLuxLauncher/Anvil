namespace Anvil.Database.Models
{
    public class ModVersion
    {
        public int Id {  get; set; }
        public string ModId {  get; set; }
        public string Name {  get; set; }
        public string GameVersion {  get; set; }
        public DateTime ReleaseTime {  get; set; }
        public string Type { get; set; }
        public string Hash {  get; set; }
    }
}