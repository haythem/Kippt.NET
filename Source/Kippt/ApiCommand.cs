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

namespace Kippt
{
    /// <summary>
    /// Enumerates the list of api commands.
    /// </summary>
    public enum ApiCommand
    {
        Account,

        User,

        UserFollowings,

        UserFollowers,

        UserRelationship,

        UserLists,

        UserList,

        UserClips,

        UserFavoriteClips,

        UserLikeClips,

        UserSearch,

        Lists,

        List,

        ListFollowings,

        ListRelationship,

        ListClips,

        ListSearch,

        Clips,

        ClipFavorites,

        Clip,

        FavoriteClip,

        ClipComments,

        DeleteComment,

        ClipLikes,

        ClipSearch,

        Feed,

        Notifications,
    }
}