using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo3
{
    public class Article
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        //集合导航属性
        public List<Comment> comments { get; set; } = new List<Comment>();
    }
}
