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
    /// <summary>
    /// Represents the base class used for executing api requests.
    /// </summary>
    public partial class KipptClient : IDisposable
    {
        /// <summary>
        /// Gets or sets username.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets api token.
        /// </summary>
        public string ApiToken { get; set; }

        /// <summary>
        /// Represents the set of endpoints.
        /// </summary>
        private Dictionary<ApiCommand, Uri> Endpoints = new Dictionary<ApiCommand, Uri>()
        {
            { ApiCommand.Feed,          new Uri("https://kippt.com/api/feed/?include_data=list,user,via")},
            { ApiCommand.Account,       new Uri("https://kippt.com/api/account/") },
            { ApiCommand.User,          new Uri("https://kippt.com/api/users/{0}/") },
            { ApiCommand.Lists,         new Uri("https://kippt.com/api/lists/") },
            { ApiCommand.List,          new Uri("https://kippt.com/api/lists/{0}/") },
            { ApiCommand.Clips,         new Uri("https://kippt.com/api/clips/?include_data=list,user,via") },
            { ApiCommand.Clip,          new Uri("https://kippt.com/api/clips/{0}/?include_data=list,user,via") },
            { ApiCommand.Search,        new Uri("https://kippt.com/api/search/clips/?include_data=list,user,via") },
            { ApiCommand.Notifications, new Uri("https://kippt.com/api/notifications/?include_data=list,user,via") },
            { ApiCommand.Logout,        new Uri("https://logout@kippt.com/api/account/") },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="KipptClient"/> class.
        /// </summary>
        public KipptClient() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="KipptClient"/> class.
        /// </summary>
        public KipptClient(string userName, string apiToken)
        {
            UserName = userName;
            ApiToken = apiToken;
        }

        ~KipptClient()
        {
            Dispose(false);
        }

        #region Events

        /// <summary>
        /// Occurs when an api action is requested.
        /// </summary>
        public event EventHandler<KipptEventArgs> Started;

        private void OnStarted(KipptEventArgs e)
        {
            if (Started != null)
            {
                Started(null, e);
            }
        }

        /// <summary>
        /// Occurs when an api action is completed.
        /// </summary>
        public event EventHandler<KipptEventArgs> Completed;

        private void OnCompleted(KipptEventArgs e)
        {
            if (Completed != null)
            {
                Completed(null, e);
            }
        }

        #endregion Events

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        #endregion IDisposable
    }
}