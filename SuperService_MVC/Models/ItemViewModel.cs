using Microsoft.AspNetCore.Mvc.Rendering;
using SuperService_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperService_MVC.Models
{
    public class ItemViewModel : Item
    {
        public IList<SelectListItem> IngredientsDropDown { get; set; }
        public IList<string> IngredientsSelected { get; set; }
        public string CostAsCurrency => Cost.ToString("C");
        public string FormattedCalories => $"{Calories}kcal";
        public string FormattedProtein => $"{Math.Round(Protein, 2)}g";
        public string FormattedFat => $"{Math.Round(Fat, 2)}g";
        public string FormattedSugar => $"{Math.Round(Sugar, 2)}g";
        public string FormattedCarbs => $"{Math.Round(Carbohydrates, 2)}g";
        public string FormattedSalt => $"{Math.Round(Salt, 2)}g";
        public bool CanOrder => ItemIngredients.Where(x => x.Ingredient.NumberInStock > 0).Count() == ItemIngredients.Count();
        public int Calories => ItemIngredients.GroupBy(x => x.Item.ItemID).Select(x => x.Sum(x => x.Ingredient.Calories)).Sum();
        public double Protein => ItemIngredients.GroupBy(x => x.Item.ItemID).Select(x => x.Sum(x => x.Ingredient.Protein)).Sum();
        public double Fat => ItemIngredients.GroupBy(x => x.Item.ItemID).Select(x => x.Sum(x => x.Ingredient.Fat)).Sum();
        public double Sugar => ItemIngredients.GroupBy(x => x.Item.ItemID).Select(x => x.Sum(x => x.Ingredient.Sugar)).Sum();
        public double Carbohydrates => ItemIngredients.GroupBy(x => x.Item.ItemID).Select(x => x.Sum(x => x.Ingredient.Carbohydrates)).Sum();
        public double Salt => ItemIngredients.GroupBy(x => x.Item.ItemID).Select(x => x.Sum(x => x.Ingredient.Salt)).Sum();
    }
}
