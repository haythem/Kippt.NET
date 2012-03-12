using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kippt
{
    /// <summary>
    /// Clips are items stored to Kippt.
    /// </summary>
    [DataContract]
    public class KipptClip
    {
        #region Properties

        /// <summary>
        /// Gets clip id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets clip title.
        /// </summary>
        /// 
        /// <remarks>
        /// Title will be fetched automatically if it's not provided.
        /// </remarks>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets clip notes.
        /// </summary>
        [DataMember(Name = "notes")]
        public string Notes { get; set; }

        [DataMember(Name = "created")]
        public int dateCreated;
        /// <summary>
        /// Gets clip creation date.
        /// </summary>
        public DateTime DateCreated
        {
            get { return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(dateCreated * 1000L); }
        }

        [DataMember(Name = "updated")]
        public int dateUpdated;
        /// <summary>
        /// Gets clip update date.
        /// </summary>
        public DateTime DateUpdated
        {
            get { return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(dateUpdated * 1000L); }
        }

        [DataMember(Name = "list")]
        private string list;
        /// <summary>
        /// Gets or sets list id containing the clip.
        /// </summary>
        /// 
        /// <remarks>
        /// If the list is not defined, clip will be saved to user's Inbox.
        /// </remarks>
        public int List
        {
            get { return int.Parse(list.Substring(list.IndexOf("/api/lists/"), list.Length - list.IndexOf("/api/lists/"))); }
            set { list = string.Format("/api/lists/{0}/", value); }
        }
        
        /// <summary>
        /// Gets or sets clip url.
        /// </summary>
        [DataMember(Name = "url")]
        public Uri Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "resource_uri")]
        public string ResourceUri { get; set; }

        /// <summary>
        /// Gets clip url domain.
        /// </summary>
        [DataMember(Name = "url_domain")]
        public string UrlDomain { get; set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Creates a clip.
        /// </summary>
        public void Create()
        {
            KipptApi.ApiAction<KipptClip>(ApiCommand.Clips, HttpMethod.Post, JsonSerializer.Serialize<KipptClip>(this));
        }

        /// <summary>
        /// Updates a list.
        /// </summary>
        /// 
        /// <remarks>
        /// Properties that can be updated :
        ///     * Title
        ///     * Notes
        ///     * List
        ///     * Url
        /// </remarks>
        public void Update()
        {
            KipptApi.ApiAction<KipptClip>(ApiCommand.Clip, HttpMethod.Put, JsonSerializer.Serialize<KipptClip>(this), this.Id);
        }

        /// <summary>
        /// Deletes a clip.
        /// </summary>
        public void Delete()
        {
            KipptApi.ApiAction<KipptClip>(ApiCommand.Clip, HttpMethod.Delete, this.Id);
        }

        #endregion Public Methods

        #region Shared Methods

        /// <summary>
        /// Returns a list of clips.
        /// </summary>
        /// 
        /// <remarks>
        /// Results are paginated.
        /// The default number of returned clips is 20.
        /// Pagination information are stored in the Meta property of <see cref="KipptListCollection"/> class.
        /// </remarks>
        public static KipptClipCollection GetClips()
        {
            return KipptApi.ApiAction<KipptClipCollection>(ApiCommand.Clips, HttpMethod.Get);
        }

        /// <summary>
        /// Returns a specific number of lists.
        /// </summary>
        /// 
        /// <param name="limit">Number of clips.</param>
        public static KipptClipCollection GetClips(int limit)
        {
            return GetClips(limit, 0);
        }

        /// <summary>
        /// Returns a range of clips.
        /// </summary>
        /// 
        /// <param name="limit">End index.</param>
        /// <param name="offset">Start index.</param>
        public static KipptClipCollection GetClips(int limit, int offset)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("limit", limit);

            if (offset > 0) parameters.Add("offset", offset);

            return KipptApi.ApiAction<KipptClipCollection>(ApiCommand.Clips, HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Returns the clips associated to a specific list.
        /// </summary>
        /// 
        /// <remarks>
        /// Results are paginated.
        /// The default number of returned clips is 20.
        /// Pagination information are stored in the Meta property of <see cref="KipptListCollection"/> class.
        /// </remarks>
        /// 
        /// <param name="listId">List id.</param>
        public static KipptClipCollection GetClipsByList(int listId)
        {
            return GetClipsByList(listId, 0, 0);
        }

        /// <summary>
        /// Returns a specific number of clips associated to a list.
        /// </summary>
        /// 
        /// <param name="listId">List id.</param>
        /// <param name="limit">Number of clips.</param>
        public static KipptClipCollection GetClipsByList(int listId, int limit)
        {
            return GetClipsByList(listId, limit, 0);
        }

        /// <summary>
        /// Returns a range of clips associated to a list.
        /// </summary>
        /// 
        /// <param name="listId">List id.</param>
        /// <param name="limit">End index.</param>
        /// <param name="offset">Start index.</param>
        public static KipptClipCollection GetClipsByList(int listId, int limit, int offset)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("list", listId);

            if (limit > 0) parameters.Add("limit", limit);
            if (offset > 0) parameters.Add("offset", offset);

            return KipptApi.ApiAction<KipptClipCollection>(ApiCommand.Clips, HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Returns a clip by its id.
        /// </summary>
        /// 
        /// <remarks>
        /// Results are paginated.
        /// The default number of returned clips is 20.
        /// Pagination information are stored in the Meta property of <see cref="KipptListCollection"/> class.
        /// </remarks>
        /// 
        /// <param name="id">Clip id.</param>
        public static KipptClip GetClip(int id)
        {
            return KipptApi.ApiAction<KipptClip>(ApiCommand.Clip, HttpMethod.Get, id);
        }

        /// <summary>
        /// Returns a query filtered list of clips.
        /// </summary>
        /// 
        /// <remarks>
        /// Results are paginated.
        /// The default number of returned clips is 20.
        /// Pagination information are stored in the Meta property of <see cref="KipptListCollection"/> class.
        /// </remarks>
        /// 
        /// <param name="query">Query.</param>
        public static KipptClipCollection Search(string query)
        {
            return Search(query, 0, 0);
        }

        /// <summary>
        /// Returns a query filtered list of clips.
        /// </summary>
        /// 
        /// <remarks>
        /// Results are limited.
        /// </remarks>
        /// 
        /// <param name="query">Query.</param>
        /// <param name="limit">Number of clips.</param>
        public static KipptClipCollection Search(string query, int limit)
        {
            return Search(query, limit, 0);
        }

        /// <summary>
        /// Returns a query filtered list of clips.
        /// </summary>
        /// 
        /// <param name="query">Query.</param>
        /// <param name="limit">End index.</param>
        /// <param name="offset">Start index.</param>
        public static KipptClipCollection Search(string query, int limit, int offset)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("q", query);

            if (limit > 0) parameters.Add("limit", limit);
            if (offset > 0) parameters.Add("offset", offset);

            return KipptApi.ApiAction<KipptClipCollection>(ApiCommand.Search, HttpMethod.Get, parameters);
        }

        #endregion Shared Methods
    }
}