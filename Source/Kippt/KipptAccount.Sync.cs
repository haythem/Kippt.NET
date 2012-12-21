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
    public partial class KipptAccount
    {
        /// <summary>
        /// Returns the logged-in user profile.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        public static KipptAccount Me(KipptClient client)
        {
            return client.Api<KipptAccount>(ApiCommand.Account, HttpMethod.Get);
        }

        /// <summary>
        /// Returns basic informations of a user.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="user">User id.</param>
        public static KipptAccount GetUser(KipptClient client, int user)
        {
            return /*client.Api<KipptAccount>(ApiCommand.User, HttpMethod.Get, null, user);*/null;
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
        /// <returns><see cref="KipptAccount"/> instance.</returns>
        public static KipptAccount Authenticate(KipptClient client, string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new KipptException("Username/Password cannot be null or empty !");
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("username", username);
            parameters.Add("password", password);

            var account = client.Api<KipptAccount>(ApiCommand.Account, HttpMethod.Get, parameters);

            client.UserName = account.UserName;
            client.ApiToken = account.ApiToken;

            return account;
        }
    }
}