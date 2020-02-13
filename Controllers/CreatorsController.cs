using System;
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
        public async Task<IActionResult> Index() // TODO: fetch data from DB
        {
            return View(await _context.Creators.ToListAsync());
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
        public IActionResult New() // TODO: add data to DB
        {
            return null;
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
                    throw;
                }

                return RedirectToAction("Index");
            }

            return View(creator);
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