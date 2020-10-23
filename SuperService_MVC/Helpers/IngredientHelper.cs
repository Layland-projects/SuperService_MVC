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
        public void AddIngredientFromViewModel(IngredientViewModel vm)
        {
            _serv.AddNewIngredient(ConvertViewModelToIngredient(vm));
        }
        internal void DeleteIngredienFromId(int id)
        {
            _serv.DeleteIngredient(id);
        }
        IngredientViewModel ConvertIngredientToViewModel(Ingredient ingredient)
        {
            var vm = CommonHelpers.ConvertIngredientToViewModel<IngredientViewModel>(ingredient);
            return vm;
        }

        Ingredient ConvertViewModelToIngredient(IngredientViewModel vm)
        {
            var ing = CommonHelpers.ConvertIngredientToViewModel<Ingredient>(vm);
            return ing;
        }

    }
}
