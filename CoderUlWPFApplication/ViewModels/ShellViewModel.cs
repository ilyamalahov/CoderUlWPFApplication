using CoderUlWPFApplication.Context;
using CoderUlWPFApplication.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderUlWPFApplication.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        public ShellViewModel(DatabaseContext databaseContext)
        {
            dbContext = databaseContext;

            Notifications = new ObservableCollection<Notification>(dbContext.Notifications.ToList());
        }

        private readonly DatabaseContext dbContext;

        public ObservableCollection<Notification> Notifications { get; private set; }
    }
}
