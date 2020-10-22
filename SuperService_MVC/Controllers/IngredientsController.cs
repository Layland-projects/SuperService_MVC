using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperService_BackEnd;
using SuperService_BackEnd.ServiceUtilities;
using SuperService_MVC.Helpers;

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
            return View(_helper.GetAllIngredientViewModels()); 
        }
        public IActionResult Edit(int id)
        {
            return View(_helper.GetIngredientViewModel(id));
        }
    }
}
