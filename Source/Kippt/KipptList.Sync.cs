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
        public KipptList Create(KipptClient client)
        {
            return client.Api<KipptList>(ApiCommand.Lists, HttpMethod.Post, JsonHelper.Serialize<KipptList>(this));
        }

        /// <summary>
        /// Updates a list.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// 
        /// <returns>Updated <see cref="KipptList"/> instance.</returns>
        public KipptList Update(KipptClient client)
        {
            return client.Api<KipptList>(ApiCommand.List, HttpMethod.Put, JsonHelper.Serialize<KipptList>(this), this.Id);
        }

        /// <summary>
        /// Deleted a list.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        public void Delete(KipptClient client)
        {
            client.Api<KipptList>(ApiCommand.List, HttpMethod.Delete, this.Id);
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
        public static KipptListCollection GetLists(KipptClient client)
        {
            return client.Api<KipptListCollection>(ApiCommand.Lists, HttpMethod.Get);
        }

        /// <summary>
        /// Returns a collection of lists.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="limit">End index.</param>
        /// <param name="scopes">List of scopes.</param>
        public static KipptListCollection GetLists(KipptClient client, int limit)
        {
            return GetLists(client, limit, 0);
        }

        /// <summary>
        /// Returns a collection of lists.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="limit">End index.</param>
        /// <param name="offset">Start index.</param>
        /// <param name="scopes">List of scopes.</param>
        public static KipptListCollection GetLists(KipptClient client, int limit, int offset)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("limit", limit);
            if (offset > 0) parameters.Add("offset", offset);

            return client.Api<KipptListCollection>(ApiCommand.Lists, HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Returns lists of a user
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="userId">User id.</param>
        /// <param name="limit">End index.</param>
        /// <param name="offset">Start index.</param>
        public static KipptListCollection GetUserLists(KipptClient client, int userId, int limit = 0, int offset = 0)
        {
            var parameters = new Dictionary<string, object>();

            if (limit > 0) parameters.Add("limit", limit);
            if (offset > 0) parameters.Add("offset", offset);

            return client.Api<KipptListCollection>(ApiCommand.UserLists, HttpMethod.Get, parameters, userId);
        }

        /// <summary>
        /// Returns a list by its id.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="id">List id.</param>
        /// <param name="scopes">List of scopes.</param>
        public static KipptList GetList(KipptClient client, int id)
        {
            return client.Api<KipptList>(ApiCommand.List, HttpMethod.Get, id);
        }

        /// <summary>
        /// Returns list of users following a list.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="listId">List id.</param>
        /// <param name="limit">End index.</param>
        /// <param name="offset">Start index.</param>
        public static KipptUserCollection GetListFollowings(KipptClient client, int listId, int limit = 0, int offset = 0)
        {
            var parameters = new Dictionary<string, object>();

            if (limit > 0) parameters.Add("limit", limit);
            if (offset > 0) parameters.Add("offset", offset);

            return client.Api<KipptUserCollection>(ApiCommand.ListFollowings, HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Checks whether the logged in user is following a list.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="listId">List id.</param>        
        public static bool IsFollowing(KipptClient client, int listId)
        {
            var relationship = client.Api<KipptRelationship>(ApiCommand.ListRelationship, HttpMethod.Get, listId);

            return relationship.Following;
        }

        /// <summary>
        /// Follow a list.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="listId">List id.</param>
        public static void FollowList(KipptClient client, int listId)
        {
            client.Api<KipptRelationship>(ApiCommand.ListRelationship, HttpMethod.Post, JsonHelper.Serialize<KipptAction>(new KipptAction("follow")), listId);
        }

        /// <summary>
        /// Unfollow a list.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="listId">List id.</param>
        public static void UnFollowList(KipptClient client, int listId)
        {
            client.Api<KipptRelationship>(ApiCommand.ListRelationship, HttpMethod.Post, JsonHelper.Serialize<KipptAction>(new KipptAction("unfollow")), listId);
        }

        /// <summary>
        /// Search for a list.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="query">Query.</param>
        /// <param name="limit">End index.</param>
        /// <param name="offset">Start index.</param>
        public static KipptListCollection Search(KipptClient client, string query, int limit = 0, int offset = 0)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("q", query);

            if (limit > 0) parameters.Add("limit", limit);
            if (offset > 0) parameters.Add("offset", offset);

            return client.Api<KipptListCollection>(ApiCommand.ListSearch, HttpMethod.Get, parameters);
        }

        #endregion Shared Methods
    }
}