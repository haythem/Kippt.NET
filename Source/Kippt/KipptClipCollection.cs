using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kippt
{
    /// <summary>
    /// Represents a collection of <see cref="KipptClip"/> objects.
    /// </summary>
    [DataContract]
    public class KipptClipCollection
    {
        /// <summary>
        /// Gets the pagination informations.
        /// </summary>
        [DataMember(Name = "meta")]
        public KipptMeta Meta { get; set; }

        /// <summary>
        /// Gets the list of <see cref="KipptClip"/> objects.
        /// </summary>
        [DataMember(Name = "objects")]
        public List<KipptClip> Clips { get; set; }
    }
}