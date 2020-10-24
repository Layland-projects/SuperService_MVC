using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SuperService_BackEnd;
using SuperService_BackEnd.ServiceUtilities;
using SuperService_MVC.api.Models;
using SuperService_MVC.Helpers;
using SuperService_BackEnd.Models;
using SuperService_MVC.Models;

namespace SuperService_MVC.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        ItemHelper _iHelper;

        public ItemsController(SuperServiceContext db)
        {
            _iHelper = new ItemHelper(new ItemService(db), new IngredientService(db));
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Item>>> GetItems()
        {
            var items = await _iHelper.GetAllItemViewModelsAsync();
            var retVal = new List<Models.Item>();
            foreach(var item in items)
            {
                retVal.Add(ConvertViewModelToApiModel(item));
            }
            return retVal;
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Item>> GetItem(int id)
        {
            var item = await _iHelper.GetItemViewModelFromIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return ConvertViewModelToApiModel(item);
        }
        Models.Item ConvertViewModelToApiModel(ItemViewModel vm)
        {
            var retVal = new Models.Item {
                ID = vm.ItemID,
                Cost = vm.Cost,
                Name = vm.Name,
            };

            var ings = new List<Models.Ingredient>();
            foreach (var ingredient in vm.ItemIngredients)
            {
                var i = ingredient.Ingredient;
                ings.Add(new Models.Ingredient
                {
                    IngredientID = i.IngredientID,
                    Name = i.Name,
                    Calories = i.Calories,
                    NumberInStock = i.NumberInStock,
                    Fat = i.Fat,
                    Protein = i.Protein,
                    Carbohydrates = i.Carbohydrates,
                    Sugar = i.Sugar,
                    Salt = i.Salt
                });
            }
            retVal.Ingredients = ings;
            return retVal;
        }
    }
}
