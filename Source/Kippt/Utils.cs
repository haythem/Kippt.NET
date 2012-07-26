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
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Kippt
{
    /// <summary>
    /// Common helpers.
    /// </summary>
    class Utils
    {
        #region Uri

        /// <summary>
        /// Returns an Uri after replacement of the format item with the corresponding string representation.
        /// </summary>
        /// 
        /// <param name="uri">Input Uri.</param>
        /// <param name="keys">Format items.</param>
        public static Uri FormatToUri(Uri uri, params object[] keys)
        {
            return new Uri(string.Format(uri.ToString(), keys));
        }

        /// <summary>
        /// Adds query strings to a given uri.
        /// </summary>
        /// 
        /// <param name="baseUri">Input uri.</param>
        /// <param name="parameters">Dictionnary of parameters to add.</param>
        public static Uri AddParametersToUri(Uri baseUri, Dictionary<string, object> parameters)
        {
            StringBuilder sb = new StringBuilder(baseUri.ToString());

            sb.Append("?");
            sb.Append(string.Join("&", parameters.Select(p => string.Format("{0}={1}", p.Key, p.Value.ToString()))));

            return new Uri(sb.ToString());
        }

        #endregion Uri

        #region Date

        /// <summary>
        /// Converts a date to Unix time format.
        /// </summary>
        /// 
        /// <seealso cref="http://en.wikipedia.org/wiki/Unix_time" />
        /// 
        /// <param name="date">Date to convert.</param>
        public static int ToUnixTime(DateTime date)
        {
            return (date - new DateTime(1970, 1, 1, 0, 0, 0)).Milliseconds;
        }

        /// <summary>
        /// Converts unix time format to a date.
        /// </summary>
        /// 
        /// <param name="date">Unix time date.</param>
        public static DateTime FromUnixTime(int date)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(date * 1000L);
        }

        #endregion Date
    }
}