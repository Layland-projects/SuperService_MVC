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
    }
}
