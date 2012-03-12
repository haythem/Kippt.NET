using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

namespace Kippt
{
    /// <summary>
    /// Serializes or deserializes a json result.
    /// </summary>
    public class JsonSerializer
    {
        /// <summary>
        /// Converts an object to a json format.
        /// </summary>
        /// 
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// 
        /// <returns>Serialized object.</returns>
        public static string Serialize<T>(T obj)
        {
            MemoryStream stream = new MemoryStream();

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));

            serializer.WriteObject(stream, obj);

            byte[] bytes = stream.ToArray();

            string result = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

            return result;
        }

        /// <summary>
        /// Converts json format to an object.
        /// </summary>
        /// 
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// 
        /// <returns>Deserialized object.</returns>
        public static T Deserialize<T>(string json)
        {
            MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json));

            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));

            T result = (T)deserializer.ReadObject(stream);

            return result;
        }
    }
}