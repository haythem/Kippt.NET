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
        /// <param name="parameters">Dictionnary of^parameters to add.</param>
        public static Uri AddParametersToUri(Uri baseUri, Dictionary<string, object> parameters)
        {
            StringBuilder sb = new StringBuilder(baseUri.ToString());

            foreach (KeyValuePair<string, object> pair in parameters)
            {
                sb.AppendFormat("&{0}={1}", pair.Key, pair.Value);
            }

            return new Uri(sb.ToString());
        }

        #endregion Uri
    }
}
