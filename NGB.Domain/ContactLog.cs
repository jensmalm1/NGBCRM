using System;
using System.Collections.Generic;
using System.Text;

namespace NGB.Domain
{
    public class ContactLog
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateTime { get; set; }
        public string FullContent { get; set; }
        public string SummaryContent { get; set; }

    }
}
