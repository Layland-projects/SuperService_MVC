using Microsoft.EntityFrameworkCore;
using SuperService_BackEnd.Interfaces;
using SuperService_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SuperService_BackEnd.ServiceUtilities
{
    public class ItemService : IItemService
    {
        SuperServiceContext _db = new SuperServiceContext();
        public ItemService() { }
        public ItemService(SuperServiceContext db)
        {
            _db = db;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _db.Items.Include(x => x.ItemIngredients).ThenInclude(x => x.Ingredient).AsNoTracking().ToList();
        }

        public Item GetItemByID(int id)
        {
            return GetAllItems().Where(x => x.ItemID == id).FirstOrDefault();
        }

        public int AddNewItem(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return item.ItemID;
        }

        public void RemoveItem(Item item)
        {
            var itemInDb = _db.Items.Where(x => x.ItemID == item.ItemID);
            _db.Items.RemoveRange(itemInDb);
            _db.SaveChanges();
        }

        public void UpdateItem(Item updatedItem)
        {
            var itemInDb = _db.Items.Where(x => x.ItemID == updatedItem.ItemID).FirstOrDefault();
            if (itemInDb == null)
            {
                throw new ArgumentException("Item does not exist in db");
            }
            itemInDb.Cost = updatedItem.Cost;
            itemInDb.Name = updatedItem.Name;
            _db.SaveChanges();
        }

        public void UpdateItemIngredientsForItemId(int itemID, IList<ItemIngredients> itemIngredients)
        {
            _db.ItemIngredients.RemoveRange(_db.ItemIngredients.Where(x => x.ItemID == itemID));
            _db.SaveChanges();
            _db.ItemIngredients.AddRange(itemIngredients);
            _db.SaveChanges();
        }
    }
}
