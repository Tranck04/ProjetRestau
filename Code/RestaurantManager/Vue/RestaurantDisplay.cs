using RestaurantManager.Modèle.Lieux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using RestaurantManager.Modèle.Personnes;
using RestaurantManager.Modèle.Personnes.Salle;
using RestaurantManager.Modèle.Personnes.Cuisine;

namespace RestaurantManager.Vue
{
    public partial class RestaurantDisplay : Form
    {
        private int SPRITE_SIZE = Int32.Parse(SettingsReader.ReadSettings("SpriteSize"));
        private Restaurant restaurant;

        private object[,] Map { get; } = new object[22, 9];
        
        private bool TableDisplayed { get; set; }

        public RestaurantDisplay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fonction permettant d'afficher les différents éléments composants un restaurant
        /// </summary>
        /// <param name="restaurant">Le restaurant source que l'on souhaite afficher</param>
        public void Display(Restaurant restaurant)
        {
            if (panel1.InvokeRequired)
            {
                panel1.Invoke(new MethodInvoker(delegate ()
                {
                    this.panel1.Controls.Clear();
                }));
            }
            else
            {
                this.panel1.Controls.Clear();
            }

            if (!TableDisplayed) {
                foreach (Table[][] carres in restaurant.Salle.Tables)
                {
                    foreach (Table[] rangs in carres)
                    {
                        foreach (Table table in rangs)
                        {
                            DisplayTable(table);
                        }
                    }
                }
                TableDisplayed = true;
            }
            
            foreach (Client client in restaurant.Salle.Clients)
            {
                DisplayPersonne(client);
            }

            foreach (AEmploye employe in restaurant.Salle.Employes)
            {
                DisplayPersonne(employe);
            }

            foreach (AEmploye employe in restaurant.Cuisine.Employes)
            {
                DisplayPersonne(employe);
            }
        }

        /// <summary>
        /// Affiche une table donnée sur le WinForm
        /// </summary>
        /// <param name="table">La table à afficher</param>
        private void DisplayTable(Table table)
        {
            int x = table.PosX;
            int y = table.PosY;

            Bitmap flippedChair = new Bitmap(Properties.Resources.Chaise);
            flippedChair.RotateFlip(RotateFlipType.RotateNoneFlipX);

            for (int i = 0; i < (table.Size / 2); i++)
            {
                //CreatePictureBox(Properties.Resources.Chaise, x - 1, y + i, null);
                CreatePictureBox(Properties.Resources.Table, x, y + i, table.ToString(), "table");
                //Properties.Resources.Chaise.RotateFlip(RotateFlipType.RotateNoneFlipX);
                //CreatePictureBox(flippedChair, x + 1, y + i, null);
            }
        }

        /// <summary>
        /// Affiche une personne donnée sur le WinForm
        /// </summary>
        /// <param name="personne">La personne à afficher</param>
        private void DisplayPersonne(Personne personne)
        {
            int x = personne.PosX;
            int y = personne.PosY;

            Bitmap bitmapToUse = null;
            string type = null;

            if (personne is Client)
            {
                bitmapToUse = Properties.Resources.Client;
                type = "client";
            }
            else if (personne is MaitreDHotel)
            {
                bitmapToUse = Properties.Resources.MaitreDHotel;
                type = "employe";
            }
            else if (personne is ChefDeRang)
            {
                bitmapToUse = Properties.Resources.ChefDeRang;
                type = "employe";
            }
            else if (personne is Serveur)
            {
                bitmapToUse = Properties.Resources.Serveur;
                type = "employe";
            }
            else if (personne is CommisDeSalle)
            {
                bitmapToUse = Properties.Resources.CommisDeSalle;
                type = "employe";
            }
            else if (personne is ChefDeCuisine)
            {
                bitmapToUse = Properties.Resources.ChefDeCuisine;
                type = "employe";
            }
            else if (personne is Cuisinier)
            {
                bitmapToUse = Properties.Resources.Cuisinier;
                type = "employe";
            }
            else if (personne is Plongeur)
            {
                bitmapToUse = Properties.Resources.Plongeur;
                type = "employe";
            }
            else if (personne is CommisDeCuisine)
            {
                bitmapToUse = Properties.Resources.CommisDeCuisine;
                type = "employe";
            }

            CreatePictureBox(bitmapToUse, x, y, personne.ToString(), type);
        }

        /// <summary>
        /// Crée une PictureBox et l'ajoute au WinForm
        /// </summary>
        /// <param name="bitmap">L'image à afficher</param>
        /// <param name="x">La position X de la PictureBox</param>
        /// <param name="y">La position Y de la PictureBox</param>
        /// <param name="onClickMsg">Le message à afficher dans la fenêtre d'inspection lors du clic sur une image</param>
        private void CreatePictureBox(Bitmap bitmap, int x, int y, string onClickMsg, string type)
        {
            PictureBox pictureBox = new PictureBox
            {
                Image = bitmap,
                Location = new Point(x * SPRITE_SIZE, y * SPRITE_SIZE),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Height = SPRITE_SIZE,
                Width = SPRITE_SIZE
            };

            if (onClickMsg != null)
                pictureBox.Click += (Object s, EventArgs eventArgs) => InspectionLog(onClickMsg);
            
            if (panel1.InvokeRequired)
            {
                panel1.Invoke(new MethodInvoker(delegate ()
                {
                    if (type == "table")
                    {
                        this.Controls.Add(pictureBox);
                        pictureBox.BringToFront();
                    }
                    else
                    {
                        panel1.Controls.Add(pictureBox);
                    }
                }));
            }
            else
            {
                panel1.Controls.Add(pictureBox);
            }
        }

        private void btn_Config_Click(object sender, EventArgs e)
        {
            Form formConfig = ConfigDisplay.Instance();
            formConfig.Show();
            formConfig.FormClosed += (Object s, FormClosedEventArgs f) =>
            {
                SPRITE_SIZE = Int32.Parse(SettingsReader.ReadSettings("SpriteSize"));
                TableDisplayed = false;
            };
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            this.ConsoleLog("====================" + Environment.NewLine + "Début de la simulation" + Environment.NewLine + "====================" + Environment.NewLine);
            this.btn_Start.Enabled = false;
            restaurant = Restaurant.Instance(this);
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            restaurant.Pause();
        }

        private void InspectionLog (string msg)
        {
            this.txtBox_Inspection.Text = "INSPECTION :" + Environment.NewLine + msg + Environment.NewLine;
        }

        public void ConsoleLog (string msg)
        {
            if (txtBox_Console.InvokeRequired)
            {
                txtBox_Console.Invoke(new MethodInvoker(
                    delegate ()
                    {
                        txtBox_Console.AppendText(msg + Environment.NewLine);
                    }));
            }
            else
            {
                txtBox_Console.AppendText(msg + Environment.NewLine);
            }
        }

        public void InsertInMap(object obj, int x, int y)
        {
            Map[x, y] = obj;
        }

        public object GetFromMap(int x, int y)
        {
            return Map[x, y];
        }
    }
}
