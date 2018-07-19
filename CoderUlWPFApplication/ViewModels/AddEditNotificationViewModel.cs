using CoderUlWPFApplication.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderUlWPFApplication.ViewModels
{
    public class AddEditNotificationViewModel : BindableBase
    {
        public List<NotificationType> NotificationTypes { get; set; }

        public List<Location> Locations { get; set; }

        public Notification CreateNotification()
        {
            return new Notification
            {
                Message = "",
                NotificationTypeId = 0
            };
        }
    }
}
