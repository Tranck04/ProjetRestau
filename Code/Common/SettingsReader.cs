using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Common
{
    public static class SettingsReader
    {
        static SettingsReader ()
        {

        }

        public static string ReadSettings (string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Erreur lors de la lecture de App.config !\n{0}\n{1}\n{2}", ex.Message, ex.Source, ex.TargetSite));
                return "";
            }
        }

        public static string[,] ReadAllSettings ()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                string[,] keysAndValues = new string[appSettings.AllKeys.Length, 2];
                int i = 0;

                foreach (string appSetting in appSettings)
                {
                    keysAndValues[i, 0] = appSetting;
                    keysAndValues[i, 1] = appSettings[appSetting];
                    i++;
                }

                return keysAndValues;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Erreur lors de la lecture de App.config !\n{0}\n{1}\n{2}", ex.Message, ex.Source, ex.TargetSite));
                return null;
            }
        }

        public static void UpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                
                if (settings[key] == null)
                {
                    throw new Exception("Clé non trouvé dans App.config");
                }
                
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Full);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Erreur dans l'écriture de App.config !\n{0}\n{1}\n{2}", ex.Message, ex.Source, ex.TargetSite));
            }
        }
    }
}
