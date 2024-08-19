using AnnouncementMVC.Data;
using AnnouncementMVC.Models.Entities;
using AnnouncementMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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

        public IActionResult Delete(int id)
        {
            var customer = _context.announcements.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                _context.announcements.Remove(customer);
                _context.SaveChanges();
            }
            return View("Index", _context.announcements);
        }
        public IActionResult View(int id)
        {
            var announcement = _context.announcements.Include(a => a.AnnouncementDetail).FirstOrDefault(a => a.Id == id);
            
            if (announcement != null)
            {
                return View(announcement);
            }
            return View("NotExists");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var announcement = await _context.announcements
                .Include(a => a.AnnouncementDetail) // Завантаження деталей
                .FirstOrDefaultAsync(a => a.Id == id);

            if (announcement == null)
            {
                return NotFound();
            }

            var model = new CreateAnnouncementViewModel
            {
                Title = announcement.Title,
                Description = announcement.AnnouncementDetail.Description
            };

            return View(model);
        }

        // POST: Announcement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateAnnouncementViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var announcement = await _context.announcements
                    .Include(a => a.AnnouncementDetail)
                    .FirstOrDefaultAsync(a => a.Id == id);

                if (announcement == null)
                {
                    return NotFound();
                }

                announcement.Title = model.Title;
                announcement.AnnouncementDetail.Description = model.Description;

                // Оновлюємо дату додавання тільки якщо це потрібно
                // announcement.AnnouncementDetail.DateAdded = DateTime.Now;

                _context.Update(announcement);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        public IActionResult ShowSimilar(int id)
        {
            var currentAnnouncement = _context.announcements
                .Include(a => a.AnnouncementDetail)
                .FirstOrDefault(a => a.Id == id);

            if (currentAnnouncement == null)
            {
                return NotFound();
            }

            var wordPattern = @"\b\w+\b";

            var currentWords = new HashSet<string>(
                Regex.Matches(currentAnnouncement.Title + " " + currentAnnouncement.AnnouncementDetail.Description, wordPattern)
                .Cast<Match>()
                .Select(m => m.Value.ToLower())
            );

            var similarAnnouncements = _context.announcements
                .Include(a => a.AnnouncementDetail)
                .ToList()
                .Where(a =>
                {
                    var words = new HashSet<string>(
                        Regex.Matches(a.Title + " " + a.AnnouncementDetail.Description, wordPattern)
                        .Cast<Match>()
                        .Select(m => m.Value.ToLower())
                    );

                    return words.Overlaps(currentWords);
                })
                .Take(3)
                .ToList();

            return View(similarAnnouncements);
        }
    }
}
