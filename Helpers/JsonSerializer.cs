using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using nopCommerceApi.Models;


namespace nopCommerceApi.Helpers
{
    public static class JsonSerializeHelper
    {
        /// <summary>
        /// Serialize an object to JSON while ignoring any circular references in the object.
        /// </summary>
        public static string JsonSerializeReferenceLoopHandlingIgnore(this IBaseDto obj)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.SerializeObject(obj, settings);
        }
        
    }
}
