using NUnit.Framework;
using SuperService_MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using SuperService_BackEnd.Interfaces;
using SuperService_BackEnd.Models;
using System.Linq;

namespace SuperService_MVC.Helpers.Tests
{
    [TestFixture]
    public class ItemHelperTests
    {
        [Test]
        public void GetAllItemViewModelsTest()
        {
            var dummyIng1 = new Ingredient { IngredientID = 1, Calories = 100, Carbohydrates = 1, Protein = 1, Fat = 1, Name = "Test0", NumberInStock = 1, Salt = 1, Sugar = 1 };
            var dummyIng2 = new Ingredient { IngredientID = 2, Calories = 100, Carbohydrates = 1, Protein = 1, Fat = 1, Name = "Test1", NumberInStock = 1, Salt = 1, Sugar = 1 };
            var dummyIng3 = new Ingredient { IngredientID = 3, Calories = 100, Carbohydrates = 1, Protein = 1, Fat = 1, Name = "Test2", NumberInStock = 1, Salt = 1, Sugar = 1 };
            var dummyItem = new Item { ItemID = 1, Cost = 5.00m, Name = "TestItem" };
            var dummyItemIng1 = new ItemIngredients { ItemID = dummyItem.ItemID, Item = dummyItem, Ingredient = dummyIng1, IngredientID = dummyIng1.IngredientID };
            var dummyItemIng2 = new ItemIngredients { ItemID = dummyItem.ItemID, Item = dummyItem, Ingredient = dummyIng2, IngredientID = dummyIng2.IngredientID };
            var dummyItemIng3 = new ItemIngredients { ItemID = dummyItem.ItemID, Item = dummyItem, Ingredient = dummyIng3, IngredientID = dummyIng3.IngredientID };
            dummyItem.ItemIngredients = new List<ItemIngredients> { dummyItemIng1, dummyItemIng2, dummyItemIng3 };
            var service = new Mock<IItemService>();
            service.Setup(x => x.GetAllItems()).Returns(new List<Item> { dummyItem });
            var helper = new ItemHelper(service.Object);
            var vms = helper.GetAllItemViewModels();
            Assert.That(vms.ToList(), Has.Count.GreaterThan(0));
        }
    }
}