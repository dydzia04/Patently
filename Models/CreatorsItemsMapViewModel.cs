using System.Collections.Generic;

namespace Patently.Models
{
  public class CreatorsItemsMapViewModel
  {
    public List<Item> Items { get; set; }
    public List<Creator> Creators { get; set; }

    public CreatorsItemsMapViewModel(List<Item> items, List<Creator> creators)
    {
      Items = items;
      Creators = creators;

      Creators.ForEach( elem =>
        elem.addItemToList(
          Items.Find( item =>
            item.Creator.ID.Equals( elem.ID )
          ) ) );
    }
  }
}
