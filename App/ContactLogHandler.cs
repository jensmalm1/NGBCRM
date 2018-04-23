using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NGB.Data;
using NGB.Domain;

namespace NGB.App
{
    class ContactLogHandler
    {
        public void AddNewContactlog(ContactLog contactLog)
        {
            using (var context = new BeanContext())
            {
                context.Customer.Include(x=>x.ContactLogs).(contactLog);
                context.SaveChanges();
            }
        }
    }
}
