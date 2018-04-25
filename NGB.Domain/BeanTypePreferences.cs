using System;
using System.Collections.Generic;
using System.Text;

namespace NGB.Domain
{
    public class BeanTypePreferences
    {
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public BeanTypes BeanTypes { get; set; }
        public int BeanTypesId { get; set; }
  
    }
}
