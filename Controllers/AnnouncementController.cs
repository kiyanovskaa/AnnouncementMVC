using AnnouncementMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementMVC.Controllers
{
    public class AnnouncementController : Controller
    {
        private AnnouncementContext _context;
        public AnnouncementController(AnnouncementContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var items = _context.announcements.ToList();
            return View(items);
        }
    }
}
