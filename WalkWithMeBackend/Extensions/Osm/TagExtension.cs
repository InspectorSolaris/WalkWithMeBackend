using OsmSharp.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Extensions.Osm
{
    public static class TagExtension
    {
        public static bool InTags(
            this Tag tag,
            IDictionary<string, IEnumerable<string>> tags)
        {
            return tags.ContainsKey(tag.Key) && tags[tag.Key].Contains(tag.Value);
        }
    }
}
