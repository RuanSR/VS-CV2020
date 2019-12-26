using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace Business.Class
{
    public static class SysSettings
    {
        private static string _defaultPathBackup = @"C:\Caderno Virtual\Backup\";
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

        public static void CreateBackup()
        {
            try
            {
                string catalog = ConfigurationManager.AppSettings["Catalog-Test"];

                var server = new Microsoft.SqlServer.Management.Smo.Server(ConfigurationManager.AppSettings["Server-Test"]);
                var backup = new Microsoft.SqlServer.Management.Smo.Backup();
                backup.Database = catalog;
                backup.Incremental = false;
                string nomeArquivoBackup = string.Format("{0}cv2020_{1:dd.MM.yy_HH.mm.ss}.bak", _defaultPathBackup, DateTime.Now);
                backup.Devices.AddDevice(nomeArquivoBackup, Microsoft.SqlServer.Management.Smo.DeviceType.File);
                backup.SqlBackup(server);
                MessageBox.Show(string.Format("Backup '{0}' concluído com sucesso.", nomeArquivoBackup), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar backup! Detahes: {ex.Message}");
            }
        }
        //public static void RestoreBackup() 
        //{
        //    try
        //    {
        //        string server = ConfigurationManager.AppSettings["Server-Test"];
        //        string security = ConfigurationManager.AppSettings["Security"];
        //        string catalog = ConfigurationManager.AppSettings["Catalog-Test"];


        //        Server dbServer = new Server(new ServerConnection());

        //        Restore dbRestore = new Restore()
        //        {
        //            Database = catalog,
        //            Action = RestoreActionType.Database,
        //            ReplaceDatabase = true,
        //            NoRecovery = false
        //        };
        //        dbRestore.Devices.AddDevice(@"C:\Caderno Virtual\Backup\cv2020_26.12.19_17.34.59.bak", DeviceType.File);
        //        dbRestore.SqlRestore(dbServer);

        //        MessageBox.Show("OK");




        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Erro ao restaurar backup! Detahes: {ex.Message}");
        //    }
        //}




    }
}
