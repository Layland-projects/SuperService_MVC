using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperService_BackEnd;
using SuperService_BackEnd.ServiceUtilities;
using SuperService_MVC.Helpers;

namespace SuperService_MVC.Controllers
{
    public class ItemController : Controller
    {
        ItemHelper _itemHelper;
        public ItemController(SuperServiceContext db)
        {
            _itemHelper = new ItemHelper(new ItemService(db));
        }
        public IActionResult Index()
        {
            return View(_itemHelper.GetAllItemViewModels());
        }
    }
}
