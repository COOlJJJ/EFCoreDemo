using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo3
{
    public class Deliver
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public Order Order { get; set; }
        public long OrderId { get; set; }
    }
}
