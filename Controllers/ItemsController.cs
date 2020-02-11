using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using MVC_Project.VievModels;

namespace MVC_Project.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Items()
        {
            Item item = new Item("Coś", DateTime.Now, new Creator("Jan", "Kowalski"));

            var viewModel = new ItemViewModel
            {
                Item = item
            };

            return View(viewModel);
        }
        public IActionResult Items( string name )
        {
            Item item = new Item( name, DateTime.Now );

            var viewModel = new ItemViewModel
            {
                Item = item
            };

            return View(viewModel);
        }

        public IActionResult ItemsList()
        {
            List<Item> items = new List<Item>
            {
                new Item("Coś", DateTime.Now),
                new Item("Coś2", DateTime.Now),
                new Item("Coś3", DateTime.Now)
            };
            
            var viewModel = new ItemsViewModel
            {
                Items = items
            };

            return View(viewModel);
        }

        public IActionResult NewItem()
        {
            throw new NotImplementedException();
        }

        public IActionResult New()
        {
            return View(new NewItem());
        }
    }
}