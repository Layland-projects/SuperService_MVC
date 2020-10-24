using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperService_BackEnd;
using SuperService_BackEnd.ServiceUtilities;
using SuperService_MVC.Helpers;
using SuperService_MVC.Models;

namespace SuperService_MVC.Controllers
{
    public class IngredientsController : Controller
    {
        readonly SuperServiceContext _context;
        IngredientHelper _helper;
        public IngredientsController(SuperServiceContext context)
        {
            _context = context;
            _helper = new IngredientHelper(new IngredientService(_context));
        }
        public IActionResult Index() 
        {
            return View(_helper.GetAllIngredientViewModels().OrderByDescending(x => x.IsInStock)); 
        }
        public IActionResult Edit(int id)
        {
            return View(_helper.GetIngredientViewModel(id));
        }
        [HttpPost]
        public IActionResult Edit(IngredientViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            _helper.UpdateIngredientFromViewModel(vm);
            return RedirectToRoute("Ingredients");
        }
        public IActionResult New()
        {
            return View(new IngredientViewModel());
        }
        [HttpPost]
        public IActionResult New(IngredientViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            _helper.AddIngredientFromViewModel(vm);
            return RedirectToRoute("Ingredients");
        }
        public IActionResult Delete(int id)
        {
            _helper.DeleteIngredienFromId(id);
            return RedirectToRoute("Ingredients");
        }
    }
}
