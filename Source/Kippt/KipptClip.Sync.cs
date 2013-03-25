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
    public partial class KipptClip
    {
        #region Public Methods

        /// <summary>
        /// Creates a clip.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// 
        /// <remarks>
        ///     * Url (required).
        ///     * Title (optional).
        ///     * Notes (optional).
        ///     * Resource uri of a list (otherwise it will be saved to inbox).
        ///     * Is starred (optional).
        ///     * Is read later (optional).
        /// </remarks>
        /// 
        /// <returns>Created <see cref="KipptClip"/> object.</returns>
        public KipptClip Create(KipptClient client)
        {
            return client.Api<KipptClip>(ApiCommand.Clips, HttpMethod.Post, JsonHelper.Serialize<KipptClip>(this));
        }

        /// <summary>
        /// Updates a clip.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// 
        /// <returns>Updated <see cref="KipptClip"/> object.</returns>
        public KipptClip Update(KipptClient client)
        {
            return client.Api<KipptClip>(ApiCommand.Clip, HttpMethod.Put, JsonHelper.Serialize<KipptClip>(this), Id);
        }

        /// <summary>
        /// Deletes a clip.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        public void Delete(KipptClient client)
        {
            client.Api<KipptClip>(ApiCommand.Clip, HttpMethod.Delete, Id);
        }

        #endregion Public Methods

        /// <summary>
        /// Returns a clip by its id.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="id">Clip id.</param>
        public static KipptClip GetClip(KipptClient client, int id)
        {
            return client.Api<KipptClip>(ApiCommand.Clip, HttpMethod.Get, id);
        }

        /// <summary>
        /// Returns a collection of clips.
        /// </summary>
        /// 
        /// <remarks>
        /// Results are paginated.
        /// The default number of returned clips is 20.
        /// Pagination information are stored in the Meta property of <see cref="KipptListCollection"/> class.
        /// </remarks>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="isStarred">Filter clips by returning only starred ones.</param>
        /// <param name="isReadLater">Filter clips returning only read later ones.</param>
        /// <param name="since">Specify a start date as a filter.</param>
        public static KipptClipCollection GetClips(KipptClient client, bool isStarred = false, bool isReadLater = false, DateTime? since = null)
        {
            return GetClips(client, 0, 0, isStarred, isReadLater, since);
        }

        /// <summary>
        /// Returns a collection of clips.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="limit">End index.</param>
        /// <param name="isStarred">Filter clips by returning only starred ones.</param>
        /// <param name="isReadLater">Filter clips returning only read later ones.</param>
        /// <param name="since">Specify a start date as a filter.</param>
        public static KipptClipCollection GetClips(KipptClient client, int limit, bool isStarred = false, bool isReadLater = false, DateTime? since = null)
        {
            return GetClips(client, limit, 0, isStarred, isReadLater, since);
        }

        /// <summary>
        /// Returns a collection of clips.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="limit">End index.</param>
        /// <param name="offset">Start index.</param>
        /// <param name="isStarred">Filter clips by returning only starred ones.</param>
        /// <param name="isReadLater">Filter clips returning only read later ones.</param>
        /// <param name="since">Specify a start date as a filter.</param>
        public static KipptClipCollection GetClips(KipptClient client, int limit, int offset, bool isStarred = false, bool isReadLater = false, DateTime? since = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            if (limit > 0)      parameters.Add("limit", limit);
            if (offset > 0)     parameters.Add("offset", offset);
            if (isStarred)      parameters.Add("is_starred", "true");
            if (isReadLater)    parameters.Add("is_read_later", "true");
            if (since != null)  parameters.Add("since", Utils.ToUnixTime((DateTime)since));

            return client.Api<KipptClipCollection>(ApiCommand.Clips, HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Returns favorites clips. Both private and public.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="limit">End index.</param>
        /// <param name="offset">Start index.</param>
        /// <param name="since">Date filter.</param>
        public static KipptClipCollection GetFavoriteClips(KipptClient client, int limit = 0, int offset = 0, DateTime? since = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            if (limit > 0) parameters.Add("limit", limit);
            if (offset > 0) parameters.Add("offset", offset);
            if (since != null) parameters.Add("since", Utils.ToUnixTime((DateTime)since));

            return client.Api<KipptClipCollection>(ApiCommand.ClipFavorites, HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Add clip to favorites.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="clipId">Clip id.</param>
        public static void FavoriteClip(KipptClient client, int clipId)
        {
            client.Api<object>(ApiCommand.FavoriteClip, HttpMethod.Post, clipId);
        }

        /// <summary>
        /// Remove clip from favorites.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="clipId">Clip id.</param>
        public static void UnFavoriteClip(KipptClient client, int clipId)
        {
            client.Api<object>(ApiCommand.FavoriteClip, HttpMethod.Delete, clipId);
        }

        /// <summary>
        /// Add comment to a clip.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="clipId">Clip id.</param>
        /// <param name="commentText">Comment text.</param>
        public static KipptComment AddComment(KipptClient client, int clipId, string commentText)
        {
            var comment = new KipptComment();

            comment.Body = commentText;

            return client.Api<KipptComment>(ApiCommand.ClipComments, HttpMethod.Post, JsonHelper.Serialize<KipptComment>(comment), clipId);
        }

        /// <summary>
        /// Delete a comment.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="clipId">clip id.</param>
        /// <param name="commentId">comment id.</param>
        public static void DeleteComment(KipptClient client, int clipId, int commentId)
        {
            client.Api<object>(ApiCommand.DeleteComment, HttpMethod.Delete, clipId, commentId);
        }

        /// <summary>
        /// Like clip.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="clipId">Clip id.</param>
        public static void LikeClip(KipptClient client, int clipId)
        {
            client.Api<object>(ApiCommand.ClipLikes, HttpMethod.Post, clipId);
        }

        /// <summary>
        /// Unlike a clip.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="clipId">Clip id.</param>
        public static void UnLikeClip(KipptClient client, int clipId)
        {
            client.Api<object>(ApiCommand.ClipLikes, HttpMethod.Delete, clipId);
        }

        /// <summary>
        /// Returns a collection of clips in a specific list.
        /// </summary>
        /// 
        /// <remarks>
        /// Results are paginated.
        /// The default number of returned clips is 20.
        /// Pagination information are stored in the Meta property of <see cref="KipptListCollection"/> class.
        /// </remarks>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="list">List id.</param>
        /// <param name="isStarred">Filter clips by returning only starred ones.</param>
        /// <param name="isReadLater">Filter clips returning only read later ones.</param>
        /// <param name="since">Specify a start date as a filter.</param>
        public static KipptClipCollection GetClipsByList(KipptClient client, int list, bool isStarred = false, bool isReadLater = false, DateTime? since = null)
        {
            return GetClipsByList(client, list, 0, 0, isStarred, isReadLater, since);
        }

        /// <summary>
        /// Returns a collection of clips in a specific list.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="list">List id.</param>
        /// <param name="limit">End index.</param>
        /// <param name="isStarred">Filter clips by returning only starred ones.</param>
        /// <param name="isReadLater">Filter clips returning only read later ones.</param>
        /// <param name="since">Specify a start date as a filter.</param>
        public static KipptClipCollection GetClipsByList(KipptClient client, int list, int limit, bool isStarred = false, bool isReadLater = false, DateTime? since = null)
        {
            return GetClipsByList(client, list, limit, 0, isStarred, isReadLater, since);
        }

        /// <summary>
        /// Returns a collection of clips in a specific list.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="list">List id.</param>
        /// <param name="limit">End index.</param>
        /// <param name="offset">Start index.</param>
        /// <param name="isStarred">Filter clips by returning only starred ones.</param>
        /// <param name="isReadLater">Filter clips returning only read later ones.</param>
        /// <param name="since">Specify a start date as a filter.</param>
        public static KipptClipCollection GetClipsByList(KipptClient client, int list, int limit, int offset, bool isStarred = false, bool isReadLater = false, DateTime? since = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("list", list);

            if (limit > 0)      parameters.Add("limit", limit);
            if (offset > 0)     parameters.Add("offset", offset);
            if (isStarred)      parameters.Add("is_starred", "true");
            if (isReadLater)    parameters.Add("is_read_later", "true");
            if (since != null)  parameters.Add("since", Utils.ToUnixTime((DateTime)since));

            return client.Api<KipptClipCollection>(ApiCommand.Clips, HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Returns a collection of feed items.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        public static KipptClipCollection GetFeed(KipptClient client)
        {
            return client.Api<KipptClipCollection>(ApiCommand.Feed, HttpMethod.Get);
        }

        /// <summary>
        /// Returns a collection of feed items.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="limit"></param>
        public static KipptClipCollection GetFeed(KipptClient client, int limit)
        {
            return GetFeed(client, limit, 0);
        }

        /// <summary>
        /// Returns a collection of feed items.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="limit">End index.</param>
        /// <param name="offset">Start index.</param>
        public static KipptClipCollection GetFeed(KipptClient client, int limit, int offset)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("limit", limit);

            if (offset > 0) parameters.Add("offset", offset);

            return client.Api<KipptClipCollection>(ApiCommand.Feed, HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Returns a query filtered collection of clips.
        /// </summary>
        /// 
        /// <remarks>
        /// Results are paginated.
        /// The default number of returned clips is 20.
        /// Pagination information are stored in the Meta property of <see cref="KipptListCollection"/> class.
        /// </remarks>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="query">Query.</param>
        /// <param name="list">List id.</param>
        /// <param name="isStarred">Filter clips by returning only starred ones.</param>
        public static KipptClipCollection Search(KipptClient client, string query, int? list = null, bool isStarred = false)
        {
            return Search(client, query, 0, 0, list, isStarred);
        }

        /// <summary>
        /// Returns a query filtered collection of clips.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="query">Query.</param>
        /// <param name="limit">End index.</param>
        /// <param name="list">List id.</param>
        /// <param name="isStarred">Filter clips by returning only starred ones.</param>
        public static KipptClipCollection Search(KipptClient client, string query, int limit, int? list = null, bool isStarred = false)
        {
            return Search(client, query, limit, 0, list, isStarred);
        }

        /// <summary>
        /// Returns a query filtered collection of clips.
        /// </summary>
        /// 
        /// <param name="client"><see cref="KipptClient"/> instance.</param>
        /// <param name="query">Query.</param>
        /// <param name="limit">End index.</param>
        /// <param name="offset">Start index.</param>
        /// <param name="list">List id.</param>
        /// <param name="isStarred">Filter clips by returning only starred ones.</param>
        public static KipptClipCollection Search(KipptClient client, string query, int limit, int offset, int? list = null, bool isStarred = false)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("q", query);

            if (limit > 0)      parameters.Add("limit", limit);
            if (offset > 0)     parameters.Add("offset", offset);
            if (list != null)   parameters.Add("list", list);
            if (isStarred)      parameters.Add("is_starred", "true");

            return client.Api<KipptClipCollection>(ApiCommand.ClipSearch, HttpMethod.Get, parameters);
        }
    }
}