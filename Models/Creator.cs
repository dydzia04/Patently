using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Patently.Models
{
    public class Creator
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Imię")]
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string SecName { get; set; }

        [Display(Name = "Wynalazki")]
        public List<Item> ItemsCreated { get; set; } = new List<Item>();

        public Creator()
        {
          ID = 0;
          Name = "Name";
          SecName = "SecName";
        }
        public Creator(int id, string name, string secName)
        {
          ID = id;
          Name = name;
          SecName = secName;
        }

        public void addItemToList(Item item)
        {
          this.ItemsCreated.Add(item);
        }

        public void removeItemFromList(int itemID)
        {
          Item itemToDelete = this.ItemsCreated.Find(item => item.ID == itemID);
          this.ItemsCreated.Remove(itemToDelete);
        }
    }
}
