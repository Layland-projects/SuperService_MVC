using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SuperService_BackEnd.Models
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public virtual ICollection<ItemIngredients> ItemIngredients { get; set; }
        public virtual ICollection<OrderItems> Orders { get; set; }
    }
}
