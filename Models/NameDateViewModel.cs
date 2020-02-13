using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Patently.Models
{
    public class NameDateViewModel
    {
        public List<Item> Items { get; set; }
        public SelectList Dates { get; set; }
        public string Date { get; set; }
        public string SearchString { get; set; }
    }
}