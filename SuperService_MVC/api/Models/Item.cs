using SuperService_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperService_MVC.api.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public int Calories => Ingredients.Select(x => x.Calories).Sum();
        public double Protein => Ingredients.Select(x => x.Protein).Sum();
        public double Fat => Ingredients.Select(x => x.Fat).Sum();
        public double Sugar => Ingredients.Select(x => x.Sugar).Sum();
        public double Carbohydrates => Ingredients.Select(x => x.Carbohydrates).Sum();
        public double Salt => Ingredients.Select(x => x.Salt).Sum();
    }
}
