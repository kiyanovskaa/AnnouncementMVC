using AnnouncementMVC.Data;
using AnnouncementMVC.Models.Entities;
using AnnouncementMVC.Models;
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAnnouncementViewModel model)
        {
            if (ModelState.IsValid)
            {
                var announcementDetail = new AnnouncementDetails
                {
                    DateAdded = DateTime.Now,
                    Description = model.Description
                };

                var announcement = new Announcement
                {
                    Title = model.Title,
                    AnnouncementDetail = announcementDetail
                };

                _context.announcements.Add(announcement);
                _context.announcementsDetails.Add(announcementDetail);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
