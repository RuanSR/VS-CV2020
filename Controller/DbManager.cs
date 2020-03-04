using Controller.Properties;
using System;
using System.Configuration;
using System.IO;

namespace Controller
{
    public class DbManager
    {
        private readonly string _localPath;
        private readonly string _dbName; 
        /*
         * Verificar se o Db.sqlite existe
         * * Se o Db NÃO existir:
         * CRIAR o DB, Criar as Tabelas, Inserir o Admin.
         */
        public DbManager()
        {
            _localPath = ConfigurationManager.AppSettings["LocalPath"];
            _dbName = ConfigurationManager.AppSettings["ServerName"];
        }
        public void Init()
        {
            VerificaDB();
        }
        private void VerificaDB()
        {
            try
            {
                if (!DbExist())
                {
                    //COPIAR ARQUIVO\\
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao verificar banco de dados! {e.Message}");
            }
        }
        private bool DbExist()
        {
            if (File.Exists(_localPath + _dbName))
            {
                return true;
            }
            return false;
        }
    }
}
