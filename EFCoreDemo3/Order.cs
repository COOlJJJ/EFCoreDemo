using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo3
{
    public class Order
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Deliver Deliver { get; set; }
    }
}
