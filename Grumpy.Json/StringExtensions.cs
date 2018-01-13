using Newtonsoft.Json;

namespace Grumpy.Json
{
    /// <summary>
    /// Json extension methods for string class
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Deserialize from a json string to a object
        /// </summary>
        /// <typeparam name="T">Type of return type</typeparam>
        /// <param name="json">Json string to deserialize</param>
        /// <returns>The object</returns>
        public static T DeserializeFromJson<T>(this string json)
        {
            return json.DeserializeFromJson<T>(new JsonSerializerSettings());
        }

        /// <summary>
        /// Deserialize from a json string to a object
        /// </summary>
        /// <typeparam name="T">Type of return type</typeparam>
        /// <param name="json">Json string to deserialize</param>
        /// <param name="settings">Settings for the serializer</param>
        /// <returns>The object</returns>
        public static T DeserializeFromJson<T>(this string json, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(json, settings);
        }
    }
}