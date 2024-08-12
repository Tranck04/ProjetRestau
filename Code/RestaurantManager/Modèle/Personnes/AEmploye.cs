using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle.Personnes
{
    public abstract class AEmploye : Personne
    {
        public Roles Role { get; set; }

        public void Start()
        {

        }
    }
}
