using RestaurantManager.Modèle.Personnes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle.Lieux
{
    public class Table
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Size { get; set; }
        public List<Client> Clients { get; set; }

        public Table(int poxX, int posY, int size)
        {
            this.PosX = poxX;
            this.PosY = posY;
            this.Size = size;
            Clients = new List<Client>();
        }

        public void AddClient (List<Client> clients)
        {
            this.Clients.AddRange(clients);
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].PosX = (i % 2 == 0) ? this.PosX - 1 : this.PosX + 1;
                clients[i].PosY = this.PosY + (i / 2);
            }
        }
        
        public override string ToString()
        {
            string nL = Environment.NewLine;
            return "Position X : " + PosX + nL + "Position Y : " + PosY + nL + "Taille : " + Size;
        }
    }
}
