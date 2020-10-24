using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperService_MVC.api.Models
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Sugar { get; set; }
        public double Carbohydrates { get; set; }
        public double Salt { get; set; }
        int _numberInStock;
        public int NumberInStock
        {
            get => _numberInStock;
            set => _numberInStock = value >= 0 ? value : 0;
        }
    }
}
