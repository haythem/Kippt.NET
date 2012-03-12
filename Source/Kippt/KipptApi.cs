using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Kippt
{
    /// <summary>
    /// Handles api queries execution.
    /// </summary>
    class KipptApi : KipptClient
    {
        #region Endpoints

        /// <summary>
        /// Represents the set of endpoints.
        /// </summary>
        private static Dictionary<ApiCommand, Uri> Endpoints = new Dictionary<ApiCommand, Uri>()
        {
            { ApiCommand.Lists,     new Uri("https://kippt.com/api/lists/") },
            { ApiCommand.List,      new Uri("https://kippt.com/api/lists/{0}/") },
            { ApiCommand.Clips,     new Uri("https://kippt.com/api/clips/") },
            { ApiCommand.Clip,      new Uri("https://kippt.com/api/clips/{0}/") },
            { ApiCommand.Search,    new Uri("https://kippt.com/api/search/clips/") },
        };

        #endregion Endpoints

        #region Shared Methods

        /// <summary>
        /// Executes an api query.
        /// </summary>
        ///
        /// <param name="command">Api command.</param>
        /// <param name="method">Http method.</param>
        public static T ApiAction<T>(ApiCommand command, HttpMethod method)
        {
            return ApiAction<T>(Endpoints[command], method, null, null, null);
        }

        /// <summary>
        /// Executes an api query.
        /// </summary>
        ///
        /// <param name="command">Api command.</param>
        /// <param name="method">Http method.</param>
        /// <param name="data">Data to be passed in the request stream.</param>
        public static T ApiAction<T>(ApiCommand command, HttpMethod method, string data)
        {
            return ApiAction<T>(Endpoints[command], method, data, null, null);
        }

        /// <summary>
        /// Executes an api query.
        /// </summary>
        /// 
        /// <param name="command">Api command.</param>
        /// <param name="method">Http method.</param>
        /// <param name="data">Data to be passed in the request stream.</param>
        /// <param name="segments">Uri segments.</param>
        public static T ApiAction<T>(ApiCommand command, HttpMethod method, string data, params object[] segments)
        {
            return ApiAction<T>(Endpoints[command], method, data, null, segments);
        }

        /// <summary>
        /// Executes an api query.
        /// </summary>
        /// 
        /// <param name="command">Api command.</param>
        /// <param name="method">Http method.</param>
        /// <param name="parameters"></param>
        public static T ApiAction<T>(ApiCommand command, HttpMethod method, Dictionary<string, object> parameters)
        {
            return ApiAction<T>(Endpoints[command], method, null, parameters, null);
        }

        /// <summary>
        /// Executes an api query.
        /// </summary>
        /// 
        /// <param name="command">Api command.</param>
        /// <param name="method">Http method.</param>
        /// <param name="segments">Uri segments.</param>
        public static T ApiAction<T>(ApiCommand command, HttpMethod method, params object[] segments)
        {
            return ApiAction<T>(Endpoints[command], method, null, null, segments);
        }

        #if (SILVERLIGHT || WINDOWS_PHONE)

        /// <summary>
        /// Executes an api query.
        /// </summary>
        /// 
        /// <param name="uri">Api endpoint.</param>
        /// <param name="data">Data to be passed in the request stream.</param>
        /// <param name="method">Http method.</param>
        /// <param name="parameters">Query strings dictionary.</param>
        /// <param name="segments">Uri segments.</param>
        public static T ApiAction<T>(Uri uri, HttpMethod method, string data, Dictionary<string, object> parameters, params object[] segments)
        {
            if (segments != null)
            {
                uri = Utils.FormatToUri(uri, segments);
            }

            if (parameters != null)
            {
                uri = Utils.AddParametersToUri(uri, parameters);
            }

            var deserializedObject = default(T);

            string json = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            request.Method = method.ToString().ToUpper();

            request.Headers["X-Kippt-Username"] = Session.UserName;
            request.Headers["X-Kippt-API-Token"] = Session.Token;

            if (method == HttpMethod.Post || method == HttpMethod.Put)
            {
                request.BeginGetRequestStream(new AsyncCallback(result =>
                {
                    HttpWebRequest req = (HttpWebRequest)result.AsyncState;

                    using (StreamWriter writer = new StreamWriter(req.EndGetRequestStream(result)))
                    {
                        writer.Write(data);
                    }

                    request.BeginGetResponse(new AsyncCallback(ResponseHandler<T>), request);
                }), request);
            }
            else
                request.BeginGetResponse(new AsyncCallback(ResponseHandler<T>), request);

            return deserializedObject;
        }

        private static void ResponseHandler<T>(IAsyncResult result)
        {
            var json = string.Empty;

            HttpWebRequest httpRequest = (HttpWebRequest)result.AsyncState;

            KipptEventArgs args = new KipptEventArgs();

            try
            {
                HttpWebResponse response = (HttpWebResponse)httpRequest.EndGetResponse(result);

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    json = reader.ReadToEnd();

                    args.Result = JsonSerializer.Deserialize<T>(json);
                }
            }
            catch
            {
                args.Error = new KipptException("An error has occured !");
            }

            // Raise the event
            OnOperationExecuted(args);
        }

        #else

        /// <summary>
        /// Executes an api query.
        /// </summary>
        /// 
        /// <param name="uri">Api endpoint.</param>
        /// <param name="data">Data to be passed in the request stream.</param>
        /// <param name="method">Http method.</param>
        /// <param name="parameters">Query strings dictionary.</param>
        /// <param name="segments">Uri segments.</param>
        public static T ApiAction<T>(Uri uri, HttpMethod method, string data, Dictionary<string, object> parameters, params object[] segments)
        {
            if (segments != null)
            {
                uri = Utils.FormatToUri(uri, segments);
            }

            if (parameters != null)
            {
                uri = Utils.AddParametersToUri(uri, parameters);
            }

            string json = string.Empty;

            WebRequest request = WebRequest.Create(uri);

            request.Method = method.ToString().ToUpper();
            request.ContentType = "application/json";

            request.Headers.Add("X-Kippt-Username", Session.UserName);
            request.Headers.Add("X-Kippt-API-Token", Session.Token);

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

                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                {
                    Stream stream = response.GetResponseStream();

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        json = reader.ReadToEnd();
                    }

                    return JsonSerializer.Deserialize<T>(json);
                }
                else
                {
                    throw new KipptException(string.Format("{0} : {1}", response.StatusCode, response.StatusDescription));
                }
            }
            catch
            {
                throw new KipptException("An error has occured !");
            }
        }

        #endif

        #endregion Shared Methods
    }
}