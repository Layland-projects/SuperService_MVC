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
    public class IngredientHelperTests
    {
        [Test]
        public void GetAllIngredientViewModelsTest()
        {
            var service = new Mock<IIngredientService>();
            service.Setup(s => s.GetAllIngredients()).Returns(new List<Ingredient> { new Ingredient { IngredientID = 1, Calories = 100, Carbohydrates = 1, Protein = 1, Fat = 1, Name = "Test", NumberInStock = 1, Salt = 1, Sugar = 1 } });
            var helper = new IngredientHelper(service.Object);
            var sut = helper.GetAllIngredientViewModels();
            Assert.That(sut[0].IngredientID, Is.EqualTo(1));
            Assert.That(sut[0].Calories, Is.EqualTo(100));
            Assert.That(sut[0].Carbohydrates, Is.EqualTo(1));
            Assert.That(sut[0].Protein, Is.EqualTo(1));
            Assert.That(sut[0].Fat, Is.EqualTo(1));
            Assert.That(sut[0].Name, Is.EqualTo("Test"));
            Assert.That(sut[0].NumberInStock, Is.EqualTo(1));
            Assert.That(sut[0].Salt, Is.EqualTo(1));
            Assert.That(sut[0].Sugar, Is.EqualTo(1));
        }
    }
}