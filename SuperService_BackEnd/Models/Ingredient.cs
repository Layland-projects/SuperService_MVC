using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SuperService_BackEnd.Models
{
    public class Ingredient : IEquatable<Ingredient>
    {
        [Key]
        public int IngredientID { get; set; }
        [Required]
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
        public ICollection<ItemIngredients> ItemIngredients { get; set; }

        public override bool Equals(object obj)
        {
            foreach(var prop in this.GetType().GetProperties())
            {
                if (obj.GetType().GetProperties().Where(x => x.Name == prop.Name).Count() > 0)
                {
                    if ((prop.GetValue(this) == null && prop.GetValue(obj) == null) || prop.GetValue(this).Equals(prop.GetValue(obj)))
                    {
                        continue;
                    }
                }
                return false;
            }
            return true;
        }

        public bool Equals(Ingredient other)
        {
            return other != null &&
                   IngredientID == other.IngredientID &&
                   Name == other.Name &&
                   Calories == other.Calories &&
                   Protein == other.Protein &&
                   Fat == other.Fat &&
                   Sugar == other.Sugar &&
                   Carbohydrates == other.Carbohydrates &&
                   Salt == other.Salt &&
                   _numberInStock == other._numberInStock &&
                   NumberInStock == other.NumberInStock &&
                   EqualityComparer<ICollection<ItemIngredients>>.Default.Equals(ItemIngredients, other.ItemIngredients);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(IngredientID);
            hash.Add(Name);
            hash.Add(Calories);
            hash.Add(Protein);
            hash.Add(Fat);
            hash.Add(Sugar);
            hash.Add(Carbohydrates);
            hash.Add(Salt);
            hash.Add(_numberInStock);
            hash.Add(NumberInStock);
            hash.Add(ItemIngredients);
            return hash.ToHashCode();
        }
    }
}
