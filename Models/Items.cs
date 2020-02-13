using System;
using System.ComponentModel.DataAnnotations;

namespace Patently.Models
{
    public class Item
    {
        public int ID { get; set; }
        
        [Display(Name = "Nazwa")]
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Kiedy zostalo dodane")]
        [Required]
        public DateTime DateWhenAdded { get; set; }
        
        [Display(Name = "Twórca")]
        [Required]
        public Creator Creator { get; set; }
    }
}