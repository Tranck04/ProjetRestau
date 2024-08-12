using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
using RestaurantManager.Vue;

namespace RestaurantManager.Modèle.Lieux
{
    public class Restaurant
    {
        private static Restaurant _instance;
        static readonly object instanceLock = new object();

        public delegate void DisplayEventHandler(Restaurant restaurantSrc);
        public static event DisplayEventHandler ObservableDisplay;
        public delegate void ConsoleEventHandler(string msg);
        public static event ConsoleEventHandler ObservableConsole;

        public Salle Salle { get; private set; }
        public Cuisine Cuisine { get; private set; }

        private Restaurant(RestaurantDisplay restaurantDisplay)
        {
            ObservableDisplay += new DisplayEventHandler(restaurantDisplay.Display);
            ObservableConsole += new ConsoleEventHandler(restaurantDisplay.ConsoleLog);
            
            Salle = new Salle(
                this, 
                int.Parse(SettingsReader.ReadSettings("nbrCarreParSalle")),
                int.Parse(SettingsReader.ReadSettings("nbrRangParCarre")),
                int.Parse(SettingsReader.ReadSettings("nbrTableParRang"))
                );

            Cuisine = Cuisine.Instance;
        }

        public void Pause ()
        {
            Salle.Pause();
        }

        public void CallDisplay()
        {
            if (ObservableDisplay != null)
            {
                ObservableDisplay(this);
            }
        }

        public void CallConsole(string msg)
        {
            if (ObservableConsole != null)
            {
                ObservableConsole(msg);
            }
        }

        public static Restaurant Instance(RestaurantDisplay restaurantDisplay)
        {
            if (_instance == null)
            {
                lock (instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new Restaurant(restaurantDisplay);
                    }
                }
            }
            return _instance;
        }
    }
}
