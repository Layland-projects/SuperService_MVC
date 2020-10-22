using SuperService_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperService_MVC.Models
{
    public class IngredientViewModel : Ingredient
    {
        public bool IsInStock => NumberInStock > 0;
        public int deleteMe { get; set; }
    }
}
