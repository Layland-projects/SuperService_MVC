using SuperService_BackEnd.Models;
using System.Collections.Generic;

namespace SuperService_BackEnd.Interfaces
{
    public interface IItemService
    {
        void AddNewItem(Item item);
        IEnumerable<Item> GetAllItems();
        Item GetItemByID(int id);
        void RemoveItem(Item item);
    }
}