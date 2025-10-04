using JournalApp.Data;
using JournalApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JournalApp.Controllers
{
    public class JournalController : Controller
    {
        private readonly AppDbContext _context;

        public JournalController(AppDbContext context)
        {
            _context = context;
        }

        // List all entries with search functionality
        public async Task<IActionResult> Index(string searchString, string moodFilter, string tagFilter)
        {
            var entries = _context.JournalEntries.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                entries = entries.Where(e => (e.Title != null && e.Title.Contains(searchString)) || 
                                           (e.Content != null && e.Content.Contains(searchString)) ||
                                           (e.Location != null && e.Location.Contains(searchString)));
            }

            if (!string.IsNullOrEmpty(moodFilter))
            {
                entries = entries.Where(e => e.Mood == moodFilter);
            }

            if (!string.IsNullOrEmpty(tagFilter))
            {
                entries = entries.Where(e => e.Tags != null && e.Tags.Contains(tagFilter));
            }

            var result = await entries.OrderByDescending(e => e.CreatedAt).ToListAsync();

            // Pass search parameters to view
            ViewBag.SearchString = searchString;
            ViewBag.MoodFilter = moodFilter;
            ViewBag.TagFilter = tagFilter;

            return View(result);
        }

        // View details
        public async Task<IActionResult> Details(int id)
        {
            var entry = await _context.JournalEntries.FindAsync(id);
            if (entry == null) return NotFound();
            return View(entry);
        }

        // Create - GET
        public IActionResult Create()
        {
            return View();
        }


        // Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JournalEntry entry)
        {
            if (ModelState.IsValid)
            {
                entry.CreatedAt = DateTime.Now;
                _context.Add(entry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entry);
        }

        // Edit
        public async Task<IActionResult> Edit(int id)
        {
            var entry = await _context.JournalEntries.FindAsync(id);
            if (entry == null) return NotFound();
            return View(entry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, JournalEntry entry)
        {
            if (id != entry.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    entry.UpdatedAt = DateTime.Now;
                    _context.Update(entry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JournalEntryExists(entry.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(entry);
        }

        private bool JournalEntryExists(int id)
        {
            return _context.JournalEntries.Any(e => e.Id == id);
        }

        // Delete
        public async Task<IActionResult> Delete(int id)
        {
            var entry = await _context.JournalEntries.FindAsync(id);
            if (entry == null) return NotFound();
            return View(entry);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entry = await _context.JournalEntries.FindAsync(id);
            if (entry != null)
            {
                _context.JournalEntries.Remove(entry);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
