using System;
using System.ComponentModel.DataAnnotations;

namespace Patently.Models
{
    public class Item
    {
        public int ID { get; set; }
        
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Kiedy zostalo dodane")]
        public DateTime DateWhenAdded { get; set; }
        
        [Display(Name = "Twórca")]
        public Creator Creator { get; set; }
    }
}