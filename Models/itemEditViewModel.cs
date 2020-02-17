using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Patently.Models
{
  public class itemEditViewModel : Item
  {
    public int creatorID { get; set; }
    public List<Creator> Creators { get; set; }

    public Item itemToSend()
    {
      return new Item
      {
        Name = this.Name,
        DateWhenAdded = this.DateWhenAdded,
        ID = this.ID,
        Creator = Creators.Find( obj => obj.ID.Equals(creatorID))
      };
    }
  }
}
