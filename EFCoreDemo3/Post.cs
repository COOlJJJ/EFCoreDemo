using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo3
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<PostTag> PostTags { get; set; }

    }
}
