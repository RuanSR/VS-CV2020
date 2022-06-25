using System;
using System.IO;

namespace CVirtual.Utils
{
    public static class AppManager
    {
        private static readonly string _defaultPathBackup = @"C:\Caderno Virtual\VC2020";
        public static void Init()
        {
			try
			{
				LoadConfiguration();
			}
			catch (Exception)
			{
				throw new Exception("Erro ao verificar configurações!");
			}
        }
        private static void LoadConfiguration()
        {
            if (!Directory.Exists(_defaultPathBackup))
            {
                Directory.CreateDirectory(_defaultPathBackup);
            }
        }
    }
}
