using RestaurantManager.Modèle.Lieux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle.Personnes.Salle
{
    public class MaitreDHotel : AEmploye
    {
        public MaitreDHotel()
        {
            PosX = 1;
        }

        public void AssignToTable (Lieux.Salle salle, List<Client> clients)
        {
            foreach (Table[][] carres in salle.Tables)
            {
                foreach (Table[] rangs in carres)
                {
                    foreach (Table table in rangs)
                    {
                        if (table.Clients.Count == 0)
                        {
                            table.AddClient(clients);
                            salle.Restaurant.CallConsole(String.Format("Le maitre d'hôtel à installé les {0} clients à la table ({1},{2})", clients.Count, table.PosX, table.PosY));
                            return;
                        }
                    }
                }
            }
        }
    }
}
