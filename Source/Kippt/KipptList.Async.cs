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
using System.Collections.Generic;

namespace Kippt
{
    public partial class KipptList
    {
        #region Public Methods

        /// <summary>
        /// Creates a list.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// 
        /// <remarks>
        ///     * Title (required).
        /// </remarks>
        /// 
        /// <returns>Created <see cref="KipptList"/> instance.</returns>
        public void CreateAsync(KipptClient client)
        {
            client.ApiAsync<KipptList>(ApiCommand.List, HttpMethod.Post, JsonHelper.Serialize<KipptList>(this));
        }

        /// <summary>
        /// Updates a list.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// 
        /// <returns>Updated <see cref="KipptList"/> instance.</returns>
        public void UpdateAsync(KipptClient client)
        {
            client.ApiAsync<KipptList>(ApiCommand.List, HttpMethod.Put, JsonHelper.Serialize<KipptList>(this));
        }

        /// <summary>
        /// Deleted a list.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        public void DeleteAsync(KipptClient client)
        {
            client.ApiAsync<KipptList>(ApiCommand.List, HttpMethod.Delete, Id);
        }

        #endregion Public Methods

        #region Shared Methods

        /// <summary>
        /// Returns a collection of lists.
        /// </summary>
        /// 
        /// <remarks>
        /// Results are paginated.
        /// The default number of returned lists is 20.
        /// Pagination information are stored in the Meta property of <see cref="KipptListCollection"/> class.
        /// </remarks>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="scopes">List of scopes.</param>
        public static void GetListsAsync(KipptClient client)
        {
            client.ApiAsync<KipptListCollection>(ApiCommand.Lists, HttpMethod.Get);
        }

        /// <summary>
        /// Returns a collection of lists.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="limit">Page size.</param>
        /// <param name="scopes">List of scopes.</param>
        public static void GetListsAsync(KipptClient client, int limit)
        {
            GetListsAsync(client, limit, 0);
        }

        /// <summary>
        /// Returns a collection of lists.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="limit">Page size.</param>
        /// <param name="offset">Start index.</param>
        /// <param name="scopes">List of scopes.</param>
        public static void GetListsAsync(KipptClient client, int limit, int offset)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("limit", limit);
            if (offset > 0) parameters.Add("offset", offset);

            client.ApiAsync<KipptListCollection>(ApiCommand.Lists, HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Returns a list by its id.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="id">List id.</param>
        /// <param name="scopes">List of scopes.</param>
        public static void GetListAsync(KipptClient client, int id)
        {
            client.ApiAsync<KipptList>(ApiCommand.List, HttpMethod.Get, id);
        }

        #endregion Shared Methods
    }
}