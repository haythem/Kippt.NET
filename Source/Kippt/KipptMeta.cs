using System;
using System.Runtime.Serialization;

namespace Kippt
{
    /// <summary>
    /// Provides pagination information of executed query.
    /// </summary>
    [DataContract]
    public class KipptMeta
    {
        /// <summary>
        /// The number of returned items.
        /// </summary>
        [DataMember(Name = "limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Next page link.
        /// </summary>
        [DataMember(Name = "next")]
        public string Next { get; set; }

        /// <summary>
        /// Start index.
        /// </summary>
        [DataMember(Name = "offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Previous page link.
        /// </summary>
        [DataMember(Name = "previous")]
        public string Previous { get; set; }

        /// <summary>
        /// Number of rows affected by the query.
        /// </summary>
        [DataMember(Name = "total_count")]
        public int TotalCount { get; set; }
    }
}