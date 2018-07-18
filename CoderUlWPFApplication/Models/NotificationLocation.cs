using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderUlWPFApplication.Models
{
    public class NotificationLocation
    {
        public int NotificationId { get; set; }

        public Notification Notification { get; set; }


        public int LocationId { get; set; }

        public Location Location { get; set; }
    }
}
