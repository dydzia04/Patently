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
        [Display(Name = "Kiedy zostalo dodane")]
        [Required]
        public string DateWhenAdded { get; set; }

        [Display(Name = "Twórca")]
        [Required]
        public Creator Creator { get; set; } = new Creator( 0, "Name", "SecName" );

        public Item()
        {
          this.Creator.addItemToList(this); //adds this item to list of its creator
        }
    }
}
