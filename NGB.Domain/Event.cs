using System;
using System.Collections.Generic;
using System.Text;

namespace NGB.Domain
{
    class Event
    {
        public int Id { get; set; }
        public int ContactLogId { get; set; }
        public DateTime DateTime { get; set; }
        public string FullContent { get; set; }
        public string SummaryContent { get; set; }
    }
}
