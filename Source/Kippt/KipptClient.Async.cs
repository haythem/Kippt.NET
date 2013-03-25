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
        public void ApiAsync<T>(ApiCommand command, HttpMethod method)
        {
            ApiAsync<T>(Endpoints[command], method, null, null, null, null);
        }

        /// <summary>
        /// Executes an api request.
        /// </summary>
        ///         
        /// <param name="command">Api command.</param>
        /// <param name="method">Http method.</param>
        /// <param name="segments">Uri segments.</param>
        public void ApiAsync<T>(ApiCommand command, HttpMethod method, params object[] segments)
        {
            ApiAsync<T>(Endpoints[command], method, null, null, segments);
        }

        /// <summary>
        /// Executes an api request.
        /// </summary>
        ///         
        /// <param name="command">Api command.</param>
        /// <param name="method">Http method.</param>
        /// <param name="data">Data to be passed in the request stream.</param>
        public void ApiAsync<T>(ApiCommand command, HttpMethod method, string data)
        {
            ApiAsync<T>(Endpoints[command], method, data, null, null, null);
        }

        /// <summary>
        /// Executes an api request.
        /// </summary>
        /// 
        /// <param name="command">Api command.</param>
        /// <param name="method">Http method.</param>
        /// <param name="data">Data to be passed in the request stream.</param>
        /// <param name="segments">Uri segments.</param>
        public void ApiAsync<T>(ApiCommand command, HttpMethod method, string data, params object[] segments)
        {
            ApiAsync<T>(Endpoints[command], method, data, null, segments);
        }

        /// <summary>
        /// Executes an api request.
        /// </summary>
        /// 
        /// <param name="command">Api command.</param>
        /// <param name="method">Http method.</param>
        /// <param name="parameters">Query strings dictionary.</param>        
        public void ApiAsync<T>(ApiCommand command, HttpMethod method, Dictionary<string, object> parameters)
        {
            ApiAsync<T>(Endpoints[command], method, null, parameters, null, null);
        }

        /// <summary>
        /// Executes an api request.
        /// </summary>
        /// 
        /// <param name="command">Api command.</param>
        /// <param name="method">Http method.</param>
        /// <param name="parameters">Query strings dictionary.</param>
        /// <param name="segments">Uri segments.</param>
        public void ApiAsync<T>(ApiCommand command, HttpMethod method, Dictionary<string, object> parameters, params object[] segments)
        {
            ApiAsync<T>(Endpoints[command], method, null, null, segments);
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
        public void ApiAsync<T>(Uri uri, HttpMethod method, string data, Dictionary<string, object> parameters, params object[] segments)
        {
            if (segments != null)
            {
                uri = Utils.FormatToUri(uri, segments);
            }

            if (parameters != null)
            {
                uri = Utils.UriBuilder(uri, parameters);
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            request.Method = method.ToString().ToUpper();

            // Authentication Process
            if (uri.AbsolutePath == Endpoints[ApiCommand.Account].AbsolutePath && parameters != null)
            {
                request.Credentials = new NetworkCredential(parameters["username"].ToString(), parameters["password"].ToString());
            }
            else // Api Request
            {
                request.Headers["X-Kippt-Username"] = UserName;
                request.Headers["X-Kippt-API-Token"] = ApiToken;
                request.Headers["X-Kippt-Client"] = "Kippt.NET, haythem.tlili@live.com, http://haythem.github.com/Kippt.NET/";
            }

            if (method == HttpMethod.Post || method == HttpMethod.Put)
            {
                request.BeginGetRequestStream(new AsyncCallback(result =>
                    {
                        HttpWebRequest req = (HttpWebRequest)result.AsyncState;

                        using (var writer = new StreamWriter(req.EndGetRequestStream(result)))
                        {
                            writer.Write(data);
                        }

                        req.BeginGetResponse(new AsyncCallback(ResponseHandler<T>), req);

                    }), request);
            }
            else
            {
                request.BeginGetResponse(new AsyncCallback(ResponseHandler<T>), request);
            }
        }

        private void ResponseHandler<T>(IAsyncResult result)
        {
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;

            var args = new KipptEventArgs();

            string json = string.Empty;

            try
            {
                // Raise Started Event
                OnStarted(args);

                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);

                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.NoContent)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        json = reader.ReadToEnd();

                        args.Result = JsonHelper.Deserialize<T>(json);
                        args.RawResponse = json;
                    }
                }
                else
                {
                    args.Error = new KipptException(string.Format("{0} : {1}", response.StatusCode, response.StatusDescription));
                }

                // Set Http Status Code
                args.HttpStatusCode = response.StatusCode;
            }
            catch (Exception e)
            {
                args.Error = new KipptException(e.Message);
            }

            // Raise Completed Event
            OnCompleted(args);
        }
    }
}