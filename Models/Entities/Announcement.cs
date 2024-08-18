using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementMVC.Data.Entities
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AnnouncementDetailId { get; set; }
        public AnnouncementDetails AnnouncementDetail { get; set; }

    }
}
