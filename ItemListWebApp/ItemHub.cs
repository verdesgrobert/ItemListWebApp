using ItemListWebApp.Controllers;
using Microsoft.AspNet.SignalR;

namespace ItemListWebApp
{
    public class ItemHub : Hub
    {
        public void AddItem(string item)
        {
            ItemListController.AddItem(item);
            var items = ItemListController.GetItems();
            Clients.All.ItemListUpdated(items);
        }

        public void DeleteItem(string item)
        {
            ItemListController.DeleteItem(item);
            var items = ItemListController.GetItems();
            Clients.All.ItemListUpdated(items);
        }

        public string[] GetItems()
        {
            var items = ItemListController.GetItems();
            return items;
        }
    }
}