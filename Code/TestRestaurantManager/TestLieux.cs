using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantManager.Modèle.Lieux;

namespace TestRestaurantManager
{
    [TestClass]
    public class TestLieux
    {
        [TestMethod]
        public void RestaurantSingleton()
        {
            Restaurant restaurant1 = Restaurant.Instance;
            Restaurant restaurant2 = Restaurant.Instance;
            Assert.IsNotNull(restaurant1);
            Assert.AreEqual(restaurant1, restaurant2);
        }

        [TestMethod]

        public void CuisineSingleton()
        {
            Cuisine cuisine1 = Cuisine.Instance;
            Cuisine cuisine2 = Cuisine.Instance;
            Assert.IsNotNull(cuisine1);
            Assert.AreEqual(cuisine1, cuisine2);
        }
    }
}
