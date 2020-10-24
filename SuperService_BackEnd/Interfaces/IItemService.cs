using SuperService_BackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperService_BackEnd.Interfaces
{
    public interface IItemService
    {
        int AddNewItem(Item item);
        IEnumerable<Item> GetAllItems();
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Item GetItemByID(int id);
        Task<Item> GetItemByIDAsync(int id);
        void RemoveItem(Item item);
        void UpdateItem(Item updatedItem);
        void UpdateItemIngredientsForItemId(int itemID, IList<ItemIngredients> itemIngredients);
    }
}