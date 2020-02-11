using System.Collections.Generic;

namespace MVC_Project.Models
{
    public class Creator
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SecName { get; set; }
        public List<Item> ItemsCreated { get; set; }

        public Creator(string name, string secName)
        {
            Name = name;
            SecName = secName;
        }

        public Creator(int id, string name, string secName, List<Item> itemsCreated)
        {
            ID = id;
            Name = name;
            SecName = secName;
            ItemsCreated = itemsCreated;
        }
    }
}