using System.ComponentModel.DataAnnotations;

namespace AnnouncementMVC.Models
{
    public class CreateAnnouncementViewModel
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
