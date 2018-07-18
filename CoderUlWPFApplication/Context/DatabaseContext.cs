using CoderUlWPFApplication.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CoderUlWPFApplication.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DatabaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-To-Many (Notification <-> NotificationType)
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.NotificationType)
                .WithMany(nt => nt.Notifications)
                .HasForeignKey(n => n.NotificationTypeId);

            // Many-To-Many (Notification <-> NotificationLocation <-> Location)
            modelBuilder.Entity<NotificationLocation>()
                .HasKey(nl => new { nl.LocationId, nl.NotificationId });

            modelBuilder.Entity<NotificationLocation>()
                .HasOne(nl => nl.Notification)
                .WithMany(n => n.NotificationLocations)
                .HasForeignKey(nl => nl.NotificationId);

            modelBuilder.Entity<NotificationLocation>()
                .HasOne(nl => nl.Location)
                .WithMany(n => n.NotificationLocations)
                .HasForeignKey(nl => nl.LocationId);

            // Seed data
            var notificationType1 = new NotificationType
            {
                Id = 1,
                Name = "Протечка воды",
                ImageName = "Alert_type_water_leak.png"
            };
            var notificationType2 = new NotificationType
            {
                Id = 2,
                Name = "Температура",
                ImageName = "Alert_type_temperature.png"
            };
            var notificationType3 = new NotificationType
            {
                Id = 3,
                Name = "Пожарная сигнализация",
                ImageName = "Alert_type_fire.png"
            };

            modelBuilder.Entity<NotificationType>().HasData(notificationType1, notificationType2, notificationType3);

            var notification1 = new Notification
            {
                Id = 1,
                Message = "Тестовое напоминание 1",
                NotificationTypeId = notificationType1.Id
            };
            var notification2 = new Notification
            {
                Id = 2,
                Message = "Тестовое напоминание 2",
                NotificationTypeId = notificationType1.Id
            };
            var notification3 = new Notification
            {
                Id = 3,
                Message = "Тестовое напоминание 3",
                NotificationTypeId = notificationType2.Id
            };
            var notification4 = new Notification
            {
                Id = 4,
                Message = "Тестовое напоминание 4",
                NotificationTypeId = notificationType3.Id
            };

            modelBuilder.Entity<Notification>().HasData(notification1, notification2, notification3, notification4);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
