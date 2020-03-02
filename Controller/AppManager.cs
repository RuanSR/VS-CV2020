using System;
using System.Configuration;
using System.IO;

namespace Controller
{
    public static class AppManager
    {
        private static string _defaultPathBackup = @"C:\Caderno Virtual\Backup\";
        private static int[] _intervaloBackup = new int[3];
        public static string LocalBackup { get; private set; }
        public static int SelectedTimerIndex { get; private set; }

        public static void Init()
        {
            try
            {
                _intervaloBackup[0] = int.Parse(ConfigurationManager.AppSettings["Auto10"]);
                _intervaloBackup[1] = int.Parse(ConfigurationManager.AppSettings["Auto15"]);
                _intervaloBackup[2] = int.Parse(ConfigurationManager.AppSettings["Auto20"]);
                SelectedTimerIndex = int.Parse(ConfigurationManager.AppSettings["SelectedTimerIndex"]);
                LocalBackup = ConfigurationManager.AppSettings["BackupPath"];

                LoadConfiguration();
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao carregar arquivos de configuração! Detalhes: {ex.Message}");
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
        private static void AddUpdateAppSettings(string key, string value)
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
            catch (Exception)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
