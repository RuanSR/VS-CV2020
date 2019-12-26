using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace Business.Class
{
    public static class SysSettings
    {
        private static string _defaultPathBackup = @"C:\Caderno Virtual\Backup";
        public static int[] IntervaloBackup { get; private set; } = new int[3];
        public static int SelectedTimerIndex { get; private set; }
        public static string LocalBackup { get; private set; }
        public static bool IsModified { get; set; } = false;

        public static void Init()
        {
            try
            {
                IntervaloBackup[0] = int.Parse(ConfigurationManager.AppSettings["Auto10"]);
                IntervaloBackup[1] = int.Parse(ConfigurationManager.AppSettings["Auto15"]);
                IntervaloBackup[2] = int.Parse(ConfigurationManager.AppSettings["Auto20"]);
                SelectedTimerIndex = int.Parse(ConfigurationManager.AppSettings["SelectedTimerIndex"]);
                LocalBackup = ConfigurationManager.AppSettings["BackupPath"];

                LoadConfiguration();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao carregar arquivos de configuração! Detalhes: {ex.Message}", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("O sistema será encerrado!");
                //Application.Exit();
            }
        }
        public static void SetSelectedTimerIndex(int timerIndex)
        {
            AddUpdateAppSettings("SelectedTimerIndex", timerIndex.ToString());
        }
        public static void SetBackupPath(string value)
        {
            AddUpdateAppSettings("BackupPath", value);
        }
        private static void LoadConfiguration()
        {
            try
            {
                if (!Directory.Exists(_defaultPathBackup))
                {
                    Directory.CreateDirectory(_defaultPathBackup);
                }
                if (SelectedTimerIndex == -1)
                {
                    SelectedTimerIndex = 0;
                }

                if (LocalBackup == "null")
                {
                    LocalBackup = _defaultPathBackup;
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao definir configurações!");
            }
        }


        static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
