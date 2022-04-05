using System;
using System.Collections.Generic;
using System.Text;

namespace Demo1
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime PubTime { get; set; }
        public double Price { get; set; }

        public string AuthorName { get; set; }
    }
}
