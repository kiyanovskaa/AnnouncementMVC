using System.ComponentModel.DataAnnotations;

namespace AnnouncementMVC.Models
{
    public class CreateAnnouncementViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
