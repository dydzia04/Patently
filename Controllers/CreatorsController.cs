using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Patently.Data;
using Patently.Models;

namespace Patently.Controllers
{
    public class CreatorsController : Controller
    {
        private readonly MvcCreatorContext _context;
        public CreatorsController(MvcCreatorContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString) // TODO: fetch data from DB
        {
            var creators = from c in _context.Creators select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                creators = creators
                    .Where(s => s.Name.Contains(searchString) || s.SecName.Contains(searchString));
            }

            return View(await creators.ToListAsync());
        }
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
        public async Task<IActionResult> Details( int? id )
        {
            if (id == null)
                return NotFound();

            var creator = await _context.Creators.FirstOrDefaultAsync(c => c.ID == id);

            if (creator == null)
                return NotFound();

            return View(creator);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var creator = await _context.Creators.FindAsync(id);
            if (creator == null)
                return NotFound();

            return View(creator);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( int? id , [Bind("ID, Name, SecName, ItemsCreated")] Creator creator)
        {
            if (id != creator.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if ( creator.ID != -1 ) //TODO
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(creator);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( [Bind("ID, Name, SecName")] Creator creator )
        {
            if (ModelState.IsValid)
            {
                _context.Add(creator);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(creator);
        }

        public async Task<IActionResult> Delete( int? id )
        {
            if (id == null)
                return NotFound();

            var creator = await _context.Creators.FirstOrDefaultAsync(i => i.ID == id);
            if (creator == null)
                return NotFound();

            return View(creator);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creator = await _context.Creators.FindAsync(id);
            _context.Remove(creator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}