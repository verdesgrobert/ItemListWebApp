using System.Collections.Generic;

namespace ItemListWebApp.Models
{
    public class ItemList
    {
        public List<string> Items { get; set; }

        public ItemList()
        {
            Items = new List<string>();
        }
    }
}