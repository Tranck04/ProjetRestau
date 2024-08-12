using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle.Commande
{
    public class Commande
    {
        private int IdClient { get; set; }
        private int Etat { get; set; }

        private List<string> Entree;
        private List<string> Plats;
        private List<string> Desserts;

        public Commande(int idClient)
        {
            IdClient = idClient;
            Etat = 1;
        }

        public int IncrementEtat()
        {
            Etat++;
            return Etat;
        }
    }
}
