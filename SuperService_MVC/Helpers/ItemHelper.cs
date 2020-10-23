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
        public ItemViewModel GetItemViewModelFromId(int id)
        {
            return ConvertItemToViewModel(_itemServ.GetItemByID(id));
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

        public void UpdateItemFromViewModel(ItemViewModel vm)
        {
            var updatedItem = new Item { ItemID = vm.ItemID, Cost = vm.Cost, Name = vm.Name };
            var itemIngredients = new List<ItemIngredients>();
            foreach (var itemID in vm.IngredientsSelected)
            {
                itemIngredients.Add(new ItemIngredients { ItemID = vm.ItemID, IngredientID = Convert.ToInt32(itemID) });
            }
            _itemServ.UpdateItem(updatedItem);
            _itemServ.UpdateItemIngredientsForItemId(vm.ItemID, itemIngredients);
        }

        ItemViewModel ConvertItemToViewModel(Item item)
        {
            return CommonHelpers.ConvertIngredientToViewModel<ItemViewModel>(item);
        }

        Item ConvertViewModelToItem(ItemViewModel vm)
        {
            return CommonHelpers.ConvertIngredientToViewModel<Item>(vm);
        }
    }
}
