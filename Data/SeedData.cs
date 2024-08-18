using AnnouncementMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace AnnouncementMVC.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AnnouncementContext(
            serviceProvider.GetRequiredService<DbContextOptions<AnnouncementContext>>()))
            {
                if (context.announcements.Any() || context.announcementsDetails.Any())
                {
                    return; 
                }

                var announcementDetail1 = new AnnouncementDetails
                {
                    DateAdded = DateTime.Now,
                    Description = "Details for announcement 1"
                };
                var announcementDetail2 = new AnnouncementDetails
                {
                    DateAdded = DateTime.Now,
                    Description = "Details for announcement 2"
                };

                context.announcementsDetails.AddRange(announcementDetail1, announcementDetail2);
                context.SaveChanges();

                var announcement1 = new Announcement
                {
                    Title = "Announcement 1",
                    AnnouncementDetail = announcementDetail1
                };
                var announcement2 = new Announcement
                {
                    Title = "Announcement 2",
                    AnnouncementDetail = announcementDetail2
                };

                context.announcements.AddRange(announcement1, announcement2);
                context.SaveChanges();
            }
        }
        }
}
