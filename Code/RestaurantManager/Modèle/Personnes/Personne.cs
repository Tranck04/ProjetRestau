using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle.Personnes
{
    public abstract class Personne
    {
        public string Nom { get; set; }
        public int PosX { get; set; } = 0;
        public int PosY { get; set; } = 0;
    }
}
