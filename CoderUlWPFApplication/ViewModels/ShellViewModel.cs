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

            var notifications = dbContext.Notifications
                .Include(n => n.NotificationType)
                .ToList();

            Notifications = new ObservableCollection<Notification>(notifications);

            QuitCommand = new DelegateCommand(QuitApplication, () => { return true; });
            ChangeScreenModeCommand = new DelegateCommand(() => { }, () => { return true; });

            PreviousCommand = new DelegateCommand(GoPrevious, CanGoPrevious);
            NextCommand = new DelegateCommand(GoNext, CanGoNext);

            PrintCommand = new DelegateCommand(PrintNotification, CanPrintNotification);

            AddCommand = new DelegateCommand(AddNotification, CanAddNotification);
            DeleteCommand = new DelegateCommand(DeleteNotification, CanDeleteNotification);
            EditCommand = new DelegateCommand(EditNotification, CanEditNotification);
        }

        private bool CanEditNotification()
        {
            return false;
        }

        private void EditNotification()
        {
            throw new NotImplementedException();
        }

        private bool CanDeleteNotification()
        {
            return false;
        }

        private void DeleteNotification()
        {
            throw new NotImplementedException();
        }

        private bool CanAddNotification()
        {
            return true;
        }

        private void AddNotification()
        {
        }

        private bool CanPrintNotification()
        {
            return false;
        }

        private void PrintNotification()
        {
            throw new NotImplementedException();
        }

        private bool CanGoNext()
        {
            return false;
        }

        private void GoNext()
        {
            throw new NotImplementedException();
        }

        private bool CanGoPrevious()
        {
            return false;
        }

        private void GoPrevious()
        {
            throw new NotImplementedException();
        }

        private void QuitApplication()
        {
            Application.Current.Shutdown();
        }

        public DelegateCommand QuitCommand { get; private set; }
        public DelegateCommand ChangeScreenModeCommand { get; private set; }

        public DelegateCommand PreviousCommand { get; private set; }
        public DelegateCommand NextCommand { get; private set; }

        public DelegateCommand PrintCommand { get; private set; }

        public DelegateCommand DeleteCommand { get; private set; }
        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand EditCommand { get; private set; }

        private readonly DatabaseContext dbContext;

        public ObservableCollection<Notification> Notifications { get; private set; }
    }
}
