using SuperService_BackEnd;
using SuperService_BackEnd.Interfaces;
using SuperService_BackEnd.Models;
using SuperService_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperService_MVC.Helpers
{
    public class IngredientHelper
    {
        IIngredientService _serv;
        public IngredientHelper(IIngredientService serv)
        {
            _serv = serv;
        }

        public IList<IngredientViewModel> GetAllIngredientViewModels()
        {
            return _serv.GetAllIngredients().Select(x => ConvertIngredientToViewModel(x)).ToList();
        }

        public IngredientViewModel GetIngredientViewModel(int id)
        {
            return ConvertIngredientToViewModel(_serv.GetIngredientByID(id));
        }


        public void UpdateIngredientFromViewModel(IngredientViewModel vm)
        {
            _serv.UpdateIngredient(ConvertViewModelToIngredient(vm));
        }
        IngredientViewModel ConvertIngredientToViewModel(Ingredient ingredient)
        {
            var vm = new IngredientViewModel();
            foreach (var prop in ingredient.GetType().GetProperties())
            {
                if (prop.CanWrite && prop.CanRead)
                {
                    prop.SetValue(vm, prop.GetValue(ingredient));
                }
            }
            return vm;
        }

        Ingredient ConvertViewModelToIngredient(IngredientViewModel vm)
        {
            var ing = new Ingredient();
            foreach (var prop in ing.GetType().GetProperties())
            {
                if (prop.CanWrite && prop.CanRead)
                {
                    prop.SetValue(ing, prop.GetValue(vm));
                }
            }
            return ing;
        }
    }
}
