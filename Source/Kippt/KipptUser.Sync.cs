﻿/*
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
    public partial class KipptUser
    {
        /// <summary>
        /// Returns the logged-in user profile.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        public static KipptUser Me(KipptClient client)
        {
            return client.Api<KipptUser>(ApiCommand.Account, HttpMethod.Get);
        }

        /// <summary>
        /// Returns basic informations of a user.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="user">User id.</param>
        public static KipptUser GetUser(KipptClient client, int userId)
        {
            return client.Api<KipptUser>(ApiCommand.User, HttpMethod.Get, userId);
        }

        /// <summary>
        /// Returns a list of user's followers.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="userId">User in question.</param>
        /// <param name="limit">End index.</param>
        /// <param name="offset">Start index.</param>        
        public static KipptUserCollection GetUserFollowers(KipptClient client, int userId, int limit = 0, int offset = 0)
        {
            var parameters = new Dictionary<string, object>();

            if (limit > 0) parameters.Add("limit", limit);
            if (offset > 0) parameters.Add("offset", offset);

            return client.Api<KipptUserCollection>(ApiCommand.UserFollowers, HttpMethod.Get, parameters, userId);
        }

        /// <summary>
        /// Get users who user follows.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="userId">User in question.</param>
        /// <param name="limit">End index.</param>
        /// <param name="offset">Start index.</param>
        public static KipptUserCollection GetUserFollowings(KipptClient client, int userId, int limit = 0, int offset = 0)
        {
            var parameters = new Dictionary<string, object>();

            if (limit > 0) parameters.Add("limit", limit);
            if (offset > 0) parameters.Add("offset", offset);

            return client.Api<KipptUserCollection>(ApiCommand.UserFollowings, HttpMethod.Get, parameters, userId);
        }

        /// <summary>
        /// Checks whether the logged-in user is following another.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="userId">User id to check against.</param>
        public static bool IsFollowing(KipptClient client, int userId)
        {
            var relationship = client.Api<KipptRelationship>(ApiCommand.UserRelationship, HttpMethod.Get, userId);

            return relationship.Following;
        }

        /// <summary>
        /// Follow a user.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="userId">User to follow.</param>
        public static void FollowUser(KipptClient client, int userId)
        {
            client.Api<KipptRelationship>(ApiCommand.UserRelationship, HttpMethod.Post, JsonHelper.Serialize<KipptAction>(new KipptAction("follow")), userId);
        }

        /// <summary>
        /// Unfollow a user.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="userId">User to unfollow.</param>
        public static void UnFollowUser(KipptClient client, int userId)
        {
            client.Api<KipptRelationship>(ApiCommand.UserRelationship, HttpMethod.Post, JsonHelper.Serialize<KipptAction>(new KipptAction("unfollow")), userId);
        }

        /// <summary>
        /// Search users with keywords. Index is build out of username, description and social profiles.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="query">Query to match with.</param>
        /// <param name="limit">End index.</param>
        /// <param name="offset">Start index.</param>
        public static KipptUserCollection Search(KipptClient client, string query, int limit = 0, int offset = 0)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("q", query);

            if (limit > 0) parameters.Add("limit", limit);
            if (offset > 0) parameters.Add("offset", offset);

            return client.Api<KipptUserCollection>(ApiCommand.UserSearch, HttpMethod.Get, parameters);
        }

        /// <summary>
        /// HTTP basic authentication.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// 
        /// <exception cref="KipptException">Empty parameters or wrong credentials.</exception>
        /// 
        /// <returns><see cref="KipptUser"/> instance.</returns>
        public static KipptUser Authenticate(KipptClient client, string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Username/Password cannot be null or empty !");
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("username", username);
            parameters.Add("password", password);

            var account = client.Api<KipptUser>(ApiCommand.Account, HttpMethod.Get, parameters);

            client.UserName = account.UserName;
            client.ApiToken = account.ApiToken;

            return account;
        }
    }
}