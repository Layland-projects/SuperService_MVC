using Microsoft.AspNetCore.Mvc.Rendering;
using SuperService_BackEnd.Interfaces;
using SuperService_BackEnd.Models;
using SuperService_BackEnd.ServiceUtilities;
using SuperService_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperService_MVC.Helpers
{
    public class ItemHelper
    {
        IItemService _itemServ;
        IngredientHelper _ingHelper;
        public ItemHelper(IItemService itemService, IIngredientService ingredientService)
        {
            _itemServ = itemService;
            _ingHelper = new IngredientHelper(ingredientService);
        }
        public IEnumerable<ItemViewModel> GetAllItemViewModels()
        {
            return _itemServ.GetAllItems().Select(x => ConvertItemToViewModel(x));
        }
        public async Task<IEnumerable<ItemViewModel>> GetAllItemViewModelsAsync()
        {
            var items = await _itemServ.GetAllItemsAsync();
            return items.Select(x => ConvertItemToViewModel(x));
        }
        public ItemViewModel GetItemViewModelFromId(int id)
        {
            return ConvertItemToViewModel(_itemServ.GetItemByID(id));
        }
        public async Task<ItemViewModel> GetItemViewModelFromIdAsync(int id)
        {
            var item = await _itemServ.GetItemByIDAsync(id);
            return ConvertItemToViewModel(item);
        }
        public IList<SelectListItem> GenerateIngredientsDropDown(IEnumerable<Ingredient> ingredients)
        {
            var list = new List<SelectListItem>();
            var allVms = _ingHelper.GetAllIngredientViewModels();
            foreach (var ing in ingredients)
            {
                list.Add(new SelectListItem
                {
                    Text = ing.Name,
                    Value = ing.IngredientID.ToString(),
                    Selected = true
                });
            }
            foreach (var vm in allVms)
            {
                if (list.Where(x => x.Value == vm.IngredientID.ToString()).Count() == 0)
                {
                    list.Add(new SelectListItem
                    {
                        Text = vm.Name,
                        Value = vm.IngredientID.ToString(),
                        Selected = false
                    });
                }
            }
            return list;
        }

        public void AddNewItemFromViewModel(ItemViewModel vm)
        {
            var itemId = _itemServ.AddNewItem(new Item { Name = vm.Name, Cost = vm.Cost });
            _itemServ.UpdateItemIngredientsForItemId(itemId, CreateItemIngredientsFromSelectList(itemId, vm.IngredientsSelected).ToList());
        }

        public void UpdateItemFromViewModel(ItemViewModel vm)
        {
            _itemServ.UpdateItem(new Item { ItemID = vm.ItemID, Name = vm.Name, Cost = vm.Cost });
            _itemServ.UpdateItemIngredientsForItemId(vm.ItemID, CreateItemIngredientsFromSelectList(vm.ItemID, vm.IngredientsSelected).ToList());
        }

        internal void DeleteItemFromID(int id)
        {
            _itemServ.RemoveItem(new Item { ItemID = id });
        }

        IList<ItemIngredients> CreateItemIngredientsFromSelectList(int itemId, IList<string> selectedIds)
        {
            var itemIngredients = new List<ItemIngredients>();
            foreach (var ingredientId in selectedIds)
            {
                itemIngredients.Add(new ItemIngredients { ItemID = itemId, IngredientID = Convert.ToInt32(ingredientId) });
            }
            return itemIngredients;
        }

        ItemViewModel ConvertItemToViewModel(Item item)
        {
            return CommonHelpers.ConvertModelToViewModel<ItemViewModel>(item);
        }

        Item ConvertViewModelToItem(ItemViewModel vm)
        {
            return CommonHelpers.ConvertModelToViewModel<Item>(vm);
        }
    }
}
