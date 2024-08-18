using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementMVC.Models.Entities
{
    public class AnnouncementDetails
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Description { get; set; }
        public Announcement Announcement { get; set; }
    }
}
