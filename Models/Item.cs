using System;

namespace MVC_Project.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateWhenAdded { get; set; }
        public Creator Creator { get; set; }

        public Item(string name, DateTime dateWhenAdded, Creator creator)
        {
            Name = name;
            DateWhenAdded = dateWhenAdded;
            Creator = creator;
        }

        public Item(string name, DateTime dateWhenAdded)
        {
            Name = name;
            DateWhenAdded = dateWhenAdded;
        }

        public Item(int id, string name, DateTime dateWhenAdded, Creator creator)
        {
            ID = id;
            Name = name;
            DateWhenAdded = dateWhenAdded;
            Creator = creator;
        }
    }
}