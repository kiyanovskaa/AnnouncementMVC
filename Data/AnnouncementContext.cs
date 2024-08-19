using AnnouncementMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace AnnouncementMVC.Data
{
    public class AnnouncementContext : DbContext
    {
        public DbSet<Announcement> announcements { get; set; }
        public DbSet<AnnouncementDetails> announcementsDetails { get; set; }
        public AnnouncementContext(DbContextOptions opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Id)
                      .ValueGeneratedOnAdd(); 

                entity.Property(a => a.Title)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasOne(a => a.AnnouncementDetail)
                      .WithOne(ad => ad.Announcement)
                      .HasForeignKey<Announcement>(a => a.AnnouncementDetailId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AnnouncementDetails>(entity =>
            {
                entity.HasKey(ad => ad.Id);

                entity.Property(ad => ad.Id)
                      .ValueGeneratedOnAdd();  

                entity.Property(ad => ad.DateAdded)
                      .IsRequired();

                entity.Property(ad => ad.Description)
                      .IsRequired()
                      .HasMaxLength(500);
            });

         
        }


    }
}
