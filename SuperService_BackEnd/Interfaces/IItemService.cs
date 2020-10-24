using SuperService_BackEnd.Models;
using System.Collections.Generic;

namespace SuperService_BackEnd.Interfaces
{
    public interface IItemService
    {
        int AddNewItem(Item item);
        IEnumerable<Item> GetAllItems();
        Item GetItemByID(int id);
        void RemoveItem(Item item);
        void UpdateItem(Item updatedItem);
        void UpdateItemIngredientsForItemId(int itemID, IList<ItemIngredients> itemIngredients);
    }
}