/*
    Kippt.NET Library for consuming Kippt APIs.
    Copyright (C) 2012 Haythem Tlili

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

        http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
 */

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