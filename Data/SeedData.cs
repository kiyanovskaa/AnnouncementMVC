using AnnouncementMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementMVC.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AnnouncementContext(
            serviceProvider.GetRequiredService<DbContextOptions<AnnouncementContext>>()))
            {
                context.Database.EnsureCreated();

                if (context.announcements.Any() || context.announcementsDetails.Any())
                {
                    return;
                }

                var announcementDetails = new List<AnnouncementDetails>
                { 

                    new AnnouncementDetails { DateAdded = DateTime.Now, Description = "Details for announcement 1 with garden" },
                    new AnnouncementDetails { DateAdded = DateTime.Now, Description = "Details for announcement 2 with garden and pool" },
                    new AnnouncementDetails { DateAdded = DateTime.Now, Description = "Modern house with pool" },
                    new AnnouncementDetails { DateAdded = DateTime.Now, Description = "Cozy apartment in city center" },
                    new AnnouncementDetails { DateAdded = DateTime.Now, Description = "Spacious villa with garden" },
                    new AnnouncementDetails { DateAdded = DateTime.Now, Description = "Studio apartment with modern design" },
                    new AnnouncementDetails { DateAdded = DateTime.Now, Description = "Luxury villa with sea view" },
                    new AnnouncementDetails { DateAdded = DateTime.Now, Description = "Budget apartment near park" },
                    new AnnouncementDetails { DateAdded = DateTime.Now, Description = "Elegant house with private pool" },
                    new AnnouncementDetails { DateAdded = DateTime.Now, Description = "Charming house in the countryside" },
                    new AnnouncementDetails { DateAdded = DateTime.Now, Description = "Modern apartment with city view" },
                    new AnnouncementDetails { DateAdded = DateTime.Now, Description = "Cozy villa near the beach" },
                    new AnnouncementDetails { DateAdded = DateTime.Now, Description = "House with spacious garden and pool" },
                    new AnnouncementDetails { DateAdded = DateTime.Now, Description = "Luxury apartment in downtown" },
                    new AnnouncementDetails { DateAdded = DateTime.Now, Description = "Villa with beautiful garden" }
                };

                context.announcementsDetails.AddRange(announcementDetails);
                context.SaveChanges();

                var announcements = new List<Announcement>
                {
                    new Announcement { Title = "Garden", AnnouncementDetail = announcementDetails[0] },
                    new Announcement { Title = "Pool and Garden", AnnouncementDetail = announcementDetails[1] },
                    new Announcement { Title = "Pool House", AnnouncementDetail = announcementDetails[2] },
                    new Announcement { Title = "Cozy Apartment", AnnouncementDetail = announcementDetails[3] },
                    new Announcement { Title = "Villa with Garden", AnnouncementDetail = announcementDetails[4] },
                    new Announcement { Title = "Modern Studio", AnnouncementDetail = announcementDetails[5] },
                    new Announcement { Title = "Luxury Villa", AnnouncementDetail = announcementDetails[6] },
                    new Announcement { Title = "Budget Apartment", AnnouncementDetail = announcementDetails[7] },
                    new Announcement { Title = "Elegant House", AnnouncementDetail = announcementDetails[8] },
                    new Announcement { Title = "Countryside House", AnnouncementDetail = announcementDetails[9] },
                    new Announcement { Title = "Modern Apartment", AnnouncementDetail = announcementDetails[10] },
                    new Announcement { Title = "Beach Villa", AnnouncementDetail = announcementDetails[11] },
                    new Announcement { Title = "Garden and Pool", AnnouncementDetail = announcementDetails[12] },
                    new Announcement { Title = "Luxury Downtown Apartment", AnnouncementDetail = announcementDetails[13] },
                    new Announcement { Title = "Beautiful Garden Villa", AnnouncementDetail = announcementDetails[14] }
                };

                context.announcements.AddRange(announcements);
                context.SaveChanges();
            }
        }
    }
}
