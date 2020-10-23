using SuperService_BackEnd.Interfaces;
using SuperService_BackEnd.Models;
using SuperService_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperService_MVC.Helpers
{
    public class ItemHelper
    {
        IItemService _serv;
        public ItemHelper(IItemService service)
        {
            _serv = service;
        }
        public IEnumerable<ItemViewModel> GetAllItemViewModels()
        {
            return _serv.GetAllItems().Select(x => ConvertItemToViewModel(x));
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
