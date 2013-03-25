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
using System.Runtime.Serialization;

namespace Kippt
{
    /// <summary>
    /// Pagination informations.
    /// </summary>
    [DataContract]
    public class KipptMeta
    {
        /// <summary>
        /// Gets the query limit.
        /// </summary>
        [DataMember(Name = "limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Gets the query offset.
        /// </summary>
        [DataMember(Name = "offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets the next page resource uri.
        /// </summary>
        [DataMember(Name = "next")]
        public string Next { get; set; }

        /// <summary>
        /// Gets the previous page resource uri.
        /// </summary>
        [DataMember(Name = "previous")]
        public string Previous { get; set; }

        /// <summary>
        /// Gets the total count of results affected by the query.
        /// </summary>
        [DataMember(Name = "total_count", IsRequired = false)]
        public int TotalCount { get; set; }
    }
}