/*
    Kippt.NET Library for consuming Kippt APIs.
    Copyright (C) 2012-2013 Haythem Tlili
    
    Library : https://github.com/Haythem/Kippt.NET
    Documentation : http://haythem.github.com/Kippt.NET/

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
using System.Net;
using System.Collections.Generic;

namespace Kippt
{
    public partial class KipptClient
    {
        /// <summary>
        /// Executes an api request.
        /// </summary>
        /// 
        /// <param name="command">Api command.</param>
        /// <param name="method">Http method.</param>
        public T Api<T>(ApiCommand command, HttpMethod method)
        {
            return Api<T>(Endpoints[command], method, null, null, null, null);
        }

        /// <summary>
        /// Executes an api request.
        /// </summary>
        ///         
        /// <param name="command">Api command.</param>
        /// <param name="method">Http method.</param>
        /// <param name="segments">Uri segments.</param>
        public T Api<T>(ApiCommand command, HttpMethod method, params object[] segments)
        {
            return Api<T>(Endpoints[command], method, null, null, segments);
        }

        /// <summary>
        /// Executes an api request.
        /// </summary>
        ///         
        /// <param name="command">Api command.</param>
        /// <param name="method">Http method.</param>
        /// <param name="data">Data to be passed in the request stream.</param>
        public T Api<T>(ApiCommand command, HttpMethod method, string data)
        {
            return Api<T>(Endpoints[command], method, data, null, null, null);
        }

        /// <summary>
        /// Executes an api request.
        /// </summary>
        /// 
        /// <param name="command">Api command.</param>
        /// <param name="method">Http method.</param>
        /// <param name="data">Data to be passed in the request stream.</param>
        /// <param name="segments">Uri segments.</param>
        public T Api<T>(ApiCommand command, HttpMethod method, string data, params object[] segments)
        {
            return Api<T>(Endpoints[command], method, data, null, segments);
        }

        /// <summary>
        /// Executes an api request.
        /// </summary>
        /// 
        /// <param name="command">Api command.</param>
        /// <param name="method">Http method.</param>
        /// <param name="parameters">Query strings dictionary.</param>        
        public T Api<T>(ApiCommand command, HttpMethod method, Dictionary<string, object> parameters)
        {
            return Api<T>(Endpoints[command], method, null, parameters, null, null);
        }

        /// <summary>
        /// Executes an api request.
        /// </summary>
        /// 
        /// <param name="command">Api command.</param>
        /// <param name="method">Http method.</param>
        /// <param name="parameters">Query strings dictionary.</param>
        /// <param name="segments">Uri segments.</param>
        public T Api<T>(ApiCommand command, HttpMethod method, Dictionary<string, object> parameters, params object[] segments)
        {
            return Api<T>(Endpoints[command], method, null, null, segments);
        }

        /// <summary>
        /// Executes an api request.
        /// </summary>
        /// 
        /// <param name="uri">Api endpoint.</param>
        /// <param name="method">Http method.</param>
        /// <param name="data">Data to be passed in the request stream.</param>
        /// <param name="parameters">Query strings dictionary.</param>
        /// <param name="segments">Uri segments.</param>
        public T Api<T>(Uri uri, HttpMethod method, string data, Dictionary<string, object> parameters, params object[] segments)
        {
            if (segments != null)
            {
                uri = Utils.FormatToUri(uri, segments);
            }

            if (parameters != null)
            {
                uri = Utils.UriBuilder(uri, parameters);
            }

            string json = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            // Authentication Process
            if (uri.AbsolutePath == Endpoints[ApiCommand.Account].AbsolutePath && parameters != null)
            {
                request.Credentials = new NetworkCredential(parameters["username"].ToString(), parameters["password"].ToString());
            }
            else // Api Request
            {
                request.Headers.Add("X-Kippt-Username", UserName);
                request.Headers.Add("X-Kippt-API-Token", ApiToken);
                request.Headers.Add("X-Kippt-Client", "Kippt.NET, haythem.tlili@live.com, http://haythem.github.com/Kippt.NET/");
            }

            if (method == HttpMethod.Post || method == HttpMethod.Put)
            {
                StreamWriter writer = new StreamWriter(request.GetRequestStream());

                writer.Write(data);
                writer.Close();
            }

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.NoContent)
                {
                    Stream stream = response.GetResponseStream();

                    using (var reader = new StreamReader(stream))
                    {
                        json = reader.ReadToEnd();
                    }

                    return JsonHelper.Deserialize<T>(json);
                }
                else
                {
                    throw new KipptException(string.Format("{0} : {1}", response.StatusCode, response.StatusDescription));
                }
            }
            catch (Exception e)
            {
                throw new KipptException(e.Message);
            }
        }
    }
}