using System.Collections.Generic;
using MVC_Project.Models;

namespace MVC_Project.VievModels
{
    public class CreatorViewModel
    {
        public Creator Creator { get; set; }
        public List<Item> Items { get; set; }
    }
}