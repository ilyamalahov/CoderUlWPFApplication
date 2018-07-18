using CoderUlWPFApplication.Context;
using CoderUlWPFApplication.Models;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CoderUlWPFApplication.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        public ShellViewModel(DatabaseContext databaseContext)
        {
            dbContext = databaseContext;

            var notifications = dbContext.Notifications.Include(n => n.NotificationType).ToList();

            Notifications = new ObservableCollection<Notification>(notifications);

            QuitCommand = new DelegateCommand(QuitApplication, () => { return true; });
        }

        private void QuitApplication()
        {
            Application.Current.Shutdown();
        }

        public DelegateCommand QuitCommand { get; private set; }

        private readonly DatabaseContext dbContext;

        public ObservableCollection<Notification> Notifications { get; private set; }
    }
}
