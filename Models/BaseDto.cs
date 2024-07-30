using System.Text.Json.Serialization;

namespace nopCommerceApi.Models
{
    public interface IBaseDto
    {
        Dictionary<string, object> UnexpectedProperties { get; set; }
    }

    public class BaseDto : IBaseDto
    {
        /// <value>
        /// <c>UnexpectedProperties</c> is a dictionary that holds any properties that are not defined in the model.
        /// It is load when deserialize a JSON pauload into an object.
        /// </value>
        /// [System.Text.Json.Serialization.JsonIgnore]
        /// [Newtonsoft.Json.JsonIgnore]        
        [JsonExtensionData]
        public Dictionary<string, object> UnexpectedProperties { get; set; } = new Dictionary<string, object>();
    }
}
