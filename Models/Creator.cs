using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Patently.Models
{
    public class Creator
    {
        [Display(Name = "ID")]
        public int ID { get; set; }
        
        [Display(Name = "Imię")]
        public string Name { get; set; }
        
        [Display(Name = "Nazwisko")]
        public string SecName { get; set; }
        
        [Display(Name = "Wynalazki")]
        public List<Item> ItemsCreated { get; set; }
    }
}