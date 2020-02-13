using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
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
        public IActionResult New() // TODO: add data to DB
        {
            return null;
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

        public IActionResult Create()
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete( int? id )
        {
            throw new NotImplementedException();
        }
    }
}