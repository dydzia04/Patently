using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Patently.Data;
using Patently.Models;

namespace Patently.Controllers
{
    public class ItemsController : Controller
    {
        private readonly MvcItemContext _context;

        public ItemsController(MvcItemContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            IQueryable<DateTime> dateQuery = from d in _context.Items orderby d.DateWhenAdded select d.DateWhenAdded;
            var items = from i in _context.Items select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                items = items
                    .Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                items = items
                    .Where(s => s.DateWhenAdded.ToString().Contains(searchString));
            }

            var NameDateViewModel = new NameDateViewModel
            {
                Dates = new SelectList(await dateQuery.Distinct().ToListAsync()),
                Items = await items.ToListAsync()
            };

            return View(NameDateViewModel);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
        public async Task<IActionResult> Details( int? id ) //TODO: show item from DB with selected ID
        {
            if (id == null)
                return NotFound();

            var item = await _context.Items.FirstOrDefaultAsync( i => i.ID == id );

            if (item == null)
                return NotFound();

            return View(item);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var item = await _context.Items.FindAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( int? id, [Bind("ID, Name, DateWhenAdded, Creator")] Item item )
        {
            if (id != item.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( [Bind("ID, Name, DateWhenAdded, Creator")] Item item )
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        public async Task<IActionResult> Delete( int? id )
        {
            if (id == null)
                return NotFound();

            var item = await _context.Items.FirstOrDefaultAsync(i => i.ID == id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}