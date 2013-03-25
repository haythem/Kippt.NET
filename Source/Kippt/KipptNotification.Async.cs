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
    public partial class KipptNotification
    {
        /// <summary>
        /// Returns a collection of notifications.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        public static void GetNotificationsAsync(KipptClient client)
        {
            client.ApiAsync<KipptNotificationCollection>(ApiCommand.Notifications, HttpMethod.Get);
        }

        /// <summary>
        /// Returns a collection of notifications.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="limit">End index.</param>
        public static void GetNotificationsAsync(KipptClient client, int limit)
        {
            GetNotificationsAsync(client, limit, 0);
        }

        /// <summary>
        /// Returns a collection of notifications.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="limit">End index.</param>
        /// <param name="offset">Start index.</param>
        public static void GetNotificationsAsync(KipptClient client, int limit, int offset)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("limit", limit);

            if (offset > 0) parameters.Add("offset", offset);

            client.ApiAsync<KipptNotificationCollection>(ApiCommand.Notifications, HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Mark all notifications as seen.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        public static void MarkNotificationsAsSeenAsync(KipptClient client)
        {
            client.ApiAsync<object>(ApiCommand.Notifications, HttpMethod.Post, JsonHelper.Serialize<KipptAction>(new KipptAction("mark_seen")));
        }
    }
}