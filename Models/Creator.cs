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
        [RegularExpression(@"\w\D")]
        public string Name { get; set; }
        
        [Display(Name = "Nazwisko")]
        [Required]
        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"\w\D")]
        public string SecName { get; set; }
        
        [Display(Name = "Wynalazki")]
        public List<Item> ItemsCreated { get; set; }
    }
}