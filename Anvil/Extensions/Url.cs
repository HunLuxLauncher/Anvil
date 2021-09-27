using Anvil.Database.Models;
using Anvil.Models;
using CzomPack.Network;
using System.Security.Cryptography;

namespace Anvil.Extensions
{
    public static class UrlExtensions
    {
        public static Stream GetStreamFromUrl(this Uri @this) => NetHandler.GetStream(@this);
        public static string GetHashFromUrl(this Uri @this)
        {
            var stream = @this.GetStreamFromUrl();
            if(stream == null) return null;
            return BitConverter.ToString(SHA1.Create().ComputeHash(stream)).Replace("-","").ToLower();
        }
        public static Resource GetResource(this Uri @this,string hash = null) => new()
        {
            Url = @this,
            Hash = hash ?? GetHashFromUrl(@this)
        };
        public static bool EqualsWithEnum<T>(this string @this, T value2)
        {
            try
            {
                T value1 = (T)Enum.Parse(typeof(T), @this, true);
                return value1.Equals(value2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        
        public static string CalculateHash(this PackVersions @this, string baseUrl)=>new Uri($"{baseUrl.TrimEnd('/')}/v1/pack/{@this.Pack.Id}/{@this.Name}").GetHashFromUrl();
        
        public static KeyValuePair<VersionType, string> ToVersionTypeKeyValuePair(this ICollection<PackVersions> @this, VersionType type)
        {
            try
            {
                return new(type, @this.Where(x => x.Type.EqualsWithEnum(type)).Select(pv => pv.Name).First());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new(type, null);
            }
        }
        public static Dictionary<VersionType, string> ToVersionTypeDictionary(this ICollection<PackVersions> @this) => new List<KeyValuePair<VersionType, string>>
        {
            @this.ToVersionTypeKeyValuePair(VersionType.Stable),
            @this.ToVersionTypeKeyValuePair(VersionType.Preview)
        }.ToDictionary(x => x.Key, x => x.Value);

        public static Dictionary<string, string> ToPackListDictionary(this ICollection<Packs> @this, string baseUrl) => @this.Select(x=>new KeyValuePair<string, string>(x.Id, new Uri($"{baseUrl.TrimEnd('/')}/v1/pack/{x.Id}").GetHashFromUrl())).ToDictionary(x => x.Key, x => x.Value);
    }
}
