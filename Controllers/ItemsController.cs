using System;
using System.Collections.Generic;
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
      private readonly MvcItemContext _itemContext;
      private readonly MvcCreatorContext _creatorContext;

        public ItemsController(MvcItemContext itemContext, MvcCreatorContext creatorContext)
        {
            _itemContext = itemContext;
            _creatorContext = creatorContext;
        }
        public async Task<IActionResult> Index(string searchString, string Date)
        {
            IQueryable<string> dateQuery = from d in _itemContext.Items orderby d.DateWhenAdded select d.DateWhenAdded;
            var items = from i in _itemContext.Items select i;

            if (!string.IsNullOrEmpty(searchString))
            {
                items = items
                    .Where(s => s.Name.Contains(searchString));
            }

            if ( !string.IsNullOrEmpty(Date) )
            {
                items = items
                    .Where(s =>
                        s.DateWhenAdded.Contains(Date) );
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
        public async Task<IActionResult> Details( int? id )
        {
            if (id == null)
                return NotFound();

            var item = await _itemContext.Items.FirstOrDefaultAsync( i => i.ID == id );

            if (item == null)
                return NotFound();

            return View(item);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var item = await _itemContext.Items.FindAsync(id);
            if (item == null)
                return NotFound();

            var vm = new itemEditViewModel
            {
              ID = item.ID,
              Name = item.Name,
              Creator = item.Creator,
              DateWhenAdded = item.DateWhenAdded,
              creatorID = item.Creator.ID,
              Creators = _creatorContext.Creator.ToList()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( int? id, [Bind("ID, Name, DateWhenAdded, Creator")] Item item )//TODO: make it work
        {
            if (id != item.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                  _itemContext.Update(item);
                    await _itemContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction("Index");
            }

            return View(item as itemEditViewModel);
        }

        public ActionResult Create()
        {
            var vm = new itemEditViewModel
            {
              Creators = _creatorContext.Creator.ToList()
            };
            return View( vm );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( [Bind("ID, Name, DateWhenAdded, Creator")] Item item ) //TODO: make it work
        {
            if (ModelState.IsValid)
            {
                _itemContext.Add(item);
                await _itemContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(item as itemEditViewModel);
        }

        public async Task<IActionResult> Delete( int? id )
        {
            if (id == null)
                return NotFound();

            var item = await _itemContext.Items.FirstOrDefaultAsync(i => i.ID == id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _itemContext.Items.FindAsync(id);
            _itemContext.Remove(item);
            await _itemContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
