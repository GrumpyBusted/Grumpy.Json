using Newtonsoft.Json;

namespace Grumpy.Json
{
    /// <summary>
    /// Json extension methods for generic object class
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns the serialized object as Json if possible otherwise a error text, to be used in exception building
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">This object</param>
        /// <returns>Serialized object as a string</returns>
        public static string TrySerializeToJson<T>(this T obj)
        {
            try
            {
                return obj.SerializeToJson(true);
            }
            catch
            {
                return "\"Unable to serialize object to json\"";
            }
        }

        /// <summary>
        /// Returns the serialized object in Json
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">This object</param>
        /// <returns>Serialized object as a string</returns>
        public static string SerializeToJson<T>(this T obj)
        {
            return obj.SerializeToJson(true);
        }

        /// <summary>
        /// Returns the serialized object in Json
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">This object</param>
        /// <param name="formatJson">Should the Json be formatted</param>
        /// <returns>Serialized object as a string</returns>
        public static string SerializeToJson<T>(this T obj, bool formatJson)
        {
            return obj.SerializeToJson(formatJson ? Formatting.Indented : Formatting.None, new JsonSerializerSettings());
        }

        /// <summary>
        /// Returns the serialized obj in Json
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">This object</param>
        /// <param name="settings">Serialize settings</param>
        /// <returns>Serialized object as a string</returns>
        // ReSharper disable once MemberCanBePrivate.Global
        public static string SerializeToJson<T>(this T obj, JsonSerializerSettings settings)
        {
            return obj.SerializeToJson(Formatting.Indented, settings);
        }

        /// <summary>
        /// Returns the serialized obj in Json
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">This object</param>
        /// <param name="formatting">Formatting option</param>
        /// <param name="settings">Serialize settings</param>
        /// <returns>Serialized object as a string</returns>
        // ReSharper disable once MemberCanBePrivate.Global
        public static string SerializeToJson<T>(this T obj, Formatting formatting, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(obj, formatting, settings);
        }
    }
}