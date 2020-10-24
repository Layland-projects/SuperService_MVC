using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperService_BackEnd;
using SuperService_BackEnd.Models;
using SuperService_BackEnd.ServiceUtilities;
using SuperService_MVC.Helpers;
using SuperService_MVC.Models;

namespace SuperService_MVC.Controllers
{
    public class ItemsController : Controller
    {
        ItemHelper _itemHelper;
        IngredientHelper _ingHelper;
        public ItemsController(SuperServiceContext db)
        {
            _itemHelper = new ItemHelper(new ItemService(db), new IngredientService(db));
            _ingHelper = new IngredientHelper(new IngredientService(db));
        }
        public IActionResult Index()
        {
            return View(_itemHelper.GetAllItemViewModels());
        }
        public IActionResult Edit(int id)
        {
            var model = _itemHelper.GetItemViewModelFromId(id);
            var ingredients = model.ItemIngredients.Select(x => x.Ingredient.IngredientID.ToString()).ToList();
            model.IngredientsDropDown = _itemHelper.GenerateIngredientsDropDown(model.ItemIngredients.Select(x => x.Ingredient));
            model.IngredientsSelected = ingredients;
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ItemViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            _itemHelper.UpdateItemFromViewModel(vm);
            return RedirectToRoute("Items");
        }
        public IActionResult New()
        {
            var model = new ItemViewModel { ItemIngredients = new List<ItemIngredients>() };
            var ingredients = model.ItemIngredients.Select(x => x.Ingredient.IngredientID.ToString()).ToList();
            model.IngredientsDropDown = _itemHelper.GenerateIngredientsDropDown(model.ItemIngredients.Select(x => x.Ingredient));
            model.IngredientsSelected = ingredients;
            return View(model);
        }
        [HttpPost]
        public IActionResult New(ItemViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            _itemHelper.AddNewItemFromViewModel(vm);
            return RedirectToRoute("Items");
        }
    }
}
