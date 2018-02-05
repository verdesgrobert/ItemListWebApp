using ItemListWebApp.Models;

namespace ItemListWebApp.Controllers
{
    public class ItemListController
    {
        private static readonly ItemList ItemNames = new ItemList();
        private static readonly object ItemNamesLock = new object();

        public static void AddItem(string itemName)
        {
            lock (ItemNamesLock)
            {
                if (!itemName.Contains(itemName))
                {
                    ItemNames.Items.Add(itemName);
                }
            }
        }

        public static void DeleteItem(string itemName)
        {
            lock (ItemNamesLock)
            {
                if (itemName.Contains(itemName))
                {
                    ItemNames.Items.Remove(itemName);
                }
            }
        }

        public static string[] GetItems()
        {
            lock (ItemNamesLock)
            {
                return ItemNames.Items.ToArray();
            }
        }
    }
}