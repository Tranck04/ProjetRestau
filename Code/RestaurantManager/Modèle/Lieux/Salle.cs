using Common;
using RestaurantManager.Modèle.Personnes;
using RestaurantManager.Modèle.Personnes.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace RestaurantManager.Modèle.Lieux
{
    public class Salle
    {
        private readonly int TABLE_SIZE = int.Parse(SettingsReader.ReadSettings("TailleDesTables"));

        public Restaurant Restaurant { get; private set; }

        public Table[][][] Tables { get; private set; }
        public List<Client> Clients { get; private set; } = new List<Client>();
        public List<AEmploye> Employes { get; private set; } = new List<AEmploye>();

        public MaitreDHotel MaitreDHotel { get; set; }
        public ChefDeRang ChefDeRang { get; set; }
        public Serveur Serveur { get; set; }
        public CommisDeSalle CommisDeSalle { get; set; }
        
        private static System.Timers.Timer aTimer;
        private readonly Random random = new Random();

        private int CapaciteMax { get; set; }
        private bool PauseEnabled { get; set; }

        private FabriquePersonne fabriquePersonne;
        
        /// <summary>
        /// Génère une nouvelle salle de restaurant
        /// </summary>
        /// <param name="nbrCarre">Le nombre de carrés dans la salle</param>
        /// <param name="nbrRangParCarre">Le nombre de rangs par carré</param>
        /// <param name="nbrTableParRang">Le nombre de tables par rang</param>
        public Salle(Restaurant restaurant, int nbrCarre, int nbrRangParCarre, int nbrTableParRang)
        {
            this.Restaurant = restaurant;

            Tables = new Table[nbrCarre][][];
            for (int i = 0; i < nbrCarre; i++)
            {
                Tables[i] = new Table[nbrRangParCarre][];
                for (int j = 0; j < nbrRangParCarre; j++)
                {
                    Tables[i][j] = new Table[nbrTableParRang];
                    for (int k = 0; k < nbrTableParRang; k++)
                    {
                        Tables[i][j][k] = new Table((i * 18) + ((k + 1) * 4), j * (TABLE_SIZE / 2 + 1), TABLE_SIZE);
                    }
                }
            }
            CapaciteMax = nbrCarre * nbrRangParCarre * nbrTableParRang * 4;

            fabriquePersonne = new FabriquePersonne();

            this.CreateEmployes();

            MaitreDHotel = fabriquePersonne.CreateEmploye(Roles.MaitreDHotel) as MaitreDHotel;
            Employes.Add(MaitreDHotel);
            
            SetTimer();
        }

        public void SetTimer()
        {
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            NewClient();
        }

        /// <summary>
        /// Génère un nouveau groupe de clients
        /// </summary>
        public void NewClient ()
        {
            if (Clients.Count < this.CapaciteMax && !PauseEnabled)
            {
                int placesRestantes = this.CapaciteMax - this.Clients.Count;
                int nbrOfClients = (placesRestantes > TABLE_SIZE) ? this.random.Next(1, TABLE_SIZE) : this.random.Next(1, placesRestantes);

                List<Client> clients = new List<Client>();

                for (int i = 0; i < nbrOfClients; i++)
                {
                    Client client = fabriquePersonne.CreateClient(Caractere.Presse);
                    client.Id = this.Clients.Count;
                    this.Clients.Add(client);

                    clients.Add(client);
                }
                this.Restaurant.CallConsole(nbrOfClients + " clients sont entrés sur " + CapaciteMax + " (" + this.Clients.Count + "/" + CapaciteMax + ")");
                MaitreDHotel.AssignToTable(this, clients);
                this.Restaurant.CallDisplay();
            }
        }

        private void CreateEmployes ()
        {
            Roles[] EmploiNom = { Roles.MaitreDHotel, Roles.ChefDeRang, Roles.Serveur, Roles.CommisDeSalle };
            Thread[] Emploi = new Thread[EmploiNom.Length];
            
            for (int i = 0; i < EmploiNom.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        MaitreDHotel = fabriquePersonne.CreateEmploye(EmploiNom[i]) as MaitreDHotel;
                        Thread MaitreDHotelThread = new Thread(new ThreadStart(MaitreDHotel.Start));
                        MaitreDHotelThread.Name = EmploiNom[i].ToString();
                        break;
                    case 1:
                        ChefDeRang = fabriquePersonne.CreateEmploye(EmploiNom[i]) as ChefDeRang;
                        Thread ChefDeRangThread = new Thread(new ThreadStart(ChefDeRang.Start));
                        ChefDeRangThread.Name = EmploiNom[i].ToString();
                        break;
                    case 2:
                        Serveur = fabriquePersonne.CreateEmploye(EmploiNom[i]) as Serveur;
                        Thread ServeurThread = new Thread(new ThreadStart(Serveur.Start));
                        ServeurThread.Name = EmploiNom[i].ToString();
                        break;
                    case 3:
                        CommisDeSalle = fabriquePersonne.CreateEmploye(EmploiNom[i]) as CommisDeSalle;
                        Thread CommisDeSalleThread = new Thread(new ThreadStart(CommisDeSalle.Start));
                        CommisDeSalleThread.Name = EmploiNom[i].ToString();
                        break;
                }
            }
        }

        public void Pause()
        {
            this.PauseEnabled = !this.PauseEnabled;
        }
    }
}