using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using MVC_Project.VievModels;

namespace MVC_Project.Controllers
{
    public class CreatorsController : Controller
    {
        public IActionResult Creators()
        {
            Creator creator = new Creator("Jan", "Kowalski");
            
            List<Item> items = new List<Item>
            {
                new Item("Coś", DateTime.Now, creator),
                new Item("Coś2", DateTime.Now, creator),
                new Item("Coś3", DateTime.Now, creator)
            };

            creator.ItemsCreated = items;
            
            var viewModel = new CreatorViewModel
            {
                Creator = creator
            };
            
            return View(viewModel);
        }
        
        public IActionResult Creators(string name, string secname)
        {
            Creator creator = new Creator( name, secname );
            
            List<Item> items = new List<Item>
            {
                new Item("Coś", DateTime.Now, creator),
                new Item("Coś2", DateTime.Now, creator),
                new Item("Coś3", DateTime.Now, creator)
            };

            creator.ItemsCreated = items;
            
            var viewModel = new CreatorViewModel
            {
                Creator = creator
            };
            
            return View(viewModel);
        }

        public IActionResult CreatorsList()
        {
            List<Creator> creator = new List<Creator>
            {
                new Creator("A", "B"),
                new Creator("C", "D")
            };
            
            var viewModel = new CreatorsViewModel
            {
                Creators = creator
            };
            
            return View(viewModel);
        }

        public IActionResult New()
        {
            return View(new NewCreator());
        }
    }
}