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
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kippt
{
    /// <summary>
    /// Lists are used to organize and categorize clips. Clips will have a list associated to them.
    /// Every user has two lists predefined, inbox and read-later, which can't be deleted.
    /// </summary>
    [DataContract]
    public class KipptList : KipptClient
    {
        #region Properties

        /// <summary>
        /// Gets list id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets list title.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets list slug.
        /// </summary>
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "created")]
        public int dateCreated;
        /// <summary>
        /// Gets the creation date of a list.
        /// </summary>
        public DateTime DateCreated
        {
            get { return Utils.FromUnixTime(dateCreated); }
        }

        [DataMember(Name = "updated")]
        public int dateUpdated;
        /// <summary>
        /// Gets the update date of a list.
        /// </summary>
        public DateTime DateUpdated
        {
            get { return Utils.FromUnixTime(dateUpdated); }
        }

        /// <summary>
        /// Gets the permalink of a list.
        /// </summary>
        [DataMember(Name = "resource_uri")]
        public string ResourceUri { get; set; }

        /// <summary>
        /// Gets the rss uri of a list.
        /// </summary>
        [DataMember(Name = "rss_url")]
        public Uri Rss { get; set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Returns a list of clips associated to the list instance.
        /// </summary>
        /// 
        /// <remarks>
        /// Results are paginated.
        /// The default number of returned clips is 20.
        /// Pagination information are stored in the Meta property of <see cref="KipptListCollection"/> class.
        /// </remarks>
        public KipptClipCollection GetClips()
        {
            return KipptClip.GetClipsByList(this.Id, 100000);
        }

        /// <summary>
        /// Creates a kippt list.
        /// </summary>
        public void Create()
        {
            KipptApi.ApiAction<KipptList>(ApiCommand.Lists, HttpMethod.Post, JsonSerializer.Serialize<KipptList>(this));
        }

        /// <summary>
        /// Updates a kippt list.
        /// </summary>
        public void Update()
        {
            KipptApi.ApiAction<KipptList>(ApiCommand.List, HttpMethod.Put, JsonSerializer.Serialize<KipptList>(this), this.Id);
        }

        /// <summary>
        /// Deletes a kippt list.
        /// </summary>
        public void Delete()
        {
            KipptApi.ApiAction<KipptList>(ApiCommand.List, HttpMethod.Delete, this.Id);
        }

        #endregion Public Methods

        #region Shared Methods

        /// <summary>
        /// Returns a list of kippt lists.
        /// </summary>
        /// 
        /// <remarks>
        /// Results are paginated.
        /// The default number of returned clips is 20.
        /// Pagination information are stored in the Meta property of <see cref="KipptListCollection"/> class.
        /// </remarks>
        public static KipptListCollection GetLists()
        {
            return KipptApi.ApiAction<KipptListCollection>(ApiCommand.Lists, HttpMethod.Get);
        }

        /// <summary>
        /// Returns a specific number of kippt lists.
        /// </summary>
        /// 
        /// <param name="limit">Number of lists.</param>
        public static KipptListCollection GetLists(int limit)
        {
            return GetLists(limit, 0);
        }

        /// <summary>
        /// Returns a range of kippt lists.
        /// </summary>
        /// 
        /// <param name="limit">End index.</param>
        /// <param name="offset">Start index.</param>
        public static KipptListCollection GetLists(int limit, int offset)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("limit", limit);

            if (offset > 0) parameters.Add("offset", offset);

            return KipptApi.ApiAction<KipptListCollection>(ApiCommand.Lists, HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Returns a kippt list by its id.
        /// </summary>
        /// 
        /// <param name="id">List id.</param>
        public static KipptList GetList(int id)
        {
            return KipptApi.ApiAction<KipptList>(ApiCommand.List, HttpMethod.Get, id);
        }

        #endregion Shared Methods
    }
}