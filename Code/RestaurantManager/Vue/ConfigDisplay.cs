using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManager.Vue
{
    public partial class ConfigDisplay : Form
    {
        private static ConfigDisplay _instance;
        static readonly object instanceLock = new object();

        private string[,] appSettings;
        private TextBox[] textBoxes;
        
        private ConfigDisplay()
        {
            InitializeComponent();

            appSettings = SettingsReader.ReadAllSettings();
            textBoxes = new TextBox[appSettings.Length / 2];

            for (int i = 0; i < (appSettings.Length) / 2; i++)
            {
                Label label = new Label()
                {
                    Text = appSettings[i, 0],
                    Location = new Point(10, 10 + 25 * i)
                };
                this.Controls.Add(label);

                TextBox textBox = new TextBox()
                {
                    Name = "textBox" + i,
                    Text = appSettings[i, 1],
                    Location = new Point(5 + label.Width + 5, 10 + 25 * i)
                };
                textBoxes[i] = textBox;
                this.Controls.Add(textBox);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < (appSettings.Length) / 2; i++)
            {
                SettingsReader.UpdateAppSettings(appSettings[i, 0], textBoxes[i].Text);
            }
            this.Close();
        }

        public static ConfigDisplay Instance()
        {
            if (_instance == null)
            {
                lock (instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigDisplay();
                    }
                }
            }
            return _instance;
        }

        private void ConfigDisplay_Closed(object sender, EventArgs e)
        {
            _instance = null;
        }
    }
}
