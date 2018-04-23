using System;
using System.Collections.Generic;
using System.Text;

namespace NGB.Domain
{
    public class ContactLog
    {
        public List<Event> Events { get; set; }
        public int Id { get; set; }
        public int CustomerId { get; set; }


    }
}
