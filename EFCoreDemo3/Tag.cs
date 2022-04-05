using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo3
{
    public class Tag
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<PostTag> PostTags { get; set; }
    }
}
