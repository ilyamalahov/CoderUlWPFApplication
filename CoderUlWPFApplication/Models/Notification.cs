using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderUlWPFApplication.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(655)]
        public string Message { get; set; }

        public int NotificationTypeId { get; set; }

        public NotificationType NotificationType { get; set; }

        public ICollection<NotificationLocation> NotificationLocations { get; set; }
    }
}
