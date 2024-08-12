using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantManager.Modèle.Personnes;

namespace TestRestaurantManager
{
    /// <summary>
    /// Description résumée pour UnitTest1
    /// </summary>
    [TestClass]
    public class TestPersonnesFabrique
    {

        private FabriquePersonne _fabrique;

        public TestPersonnesFabrique()
        {
            _fabrique = new FabriquePersonne();
            Assert.IsNotNull(_fabrique);
        }


        [TestMethod]
        public void PersonneFactory()
        {
            Object[] paramCli = { "Test", Caractere.Lent, Gouts.Salé, true,  };
            Object[] paramEmp = { "Jacque" };

            var newPersonne = _fabrique.CreatePersonne(TypeP.Client, Roles.Client, paramCli);
            var newEmploye = _fabrique.CreatePersonne(TypeP.Employe, Roles.ChefDeCuisine, paramEmp );

            Assert.Equals();
        }
    }
}
