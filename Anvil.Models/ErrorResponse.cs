
using System.Text.Json.Serialization;

namespace Anvil.Models
{
    public class ErrorResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Error { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Message { get; set; } = null;

        [JsonIgnore]
        public virtual bool HasError => !string.IsNullOrEmpty(Error) || !string.IsNullOrEmpty(Message);
    }
}