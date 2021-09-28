using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anvil.Database.Models
{
    public class PackNewsItem
    {
        public int Id {  get; set; }
        public string PackId {  get; set; }
        public int VersionId {  get; set; }
        public string Title {  get; set; }
        public string Description {  get; set; }
        public string Author {  get; set; }
        public string Avatar {  get; set; }
        public DateTime PostTime {  get; set; }
        public string Url {  get; set; }
        public string OnlyIn {  get; set; }
        
        public virtual Pack Pack {  get; set; }
        public virtual PackVersion Version {  get; set; }
    }
}
