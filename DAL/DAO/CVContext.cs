using Microsoft.EntityFrameworkCore;
using Model.Classes;
using Model.Classes.ClienteModel;
using System.Configuration;

namespace DAL.DAO
{
    public class CVContext : DbContext
    {
        private readonly string _localPath;
        private readonly string _dBName;
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Atendente> Atendentes { get; set; }

        public CVContext()
        {
            _localPath = ConfigurationManager.AppSettings[Properties.Resources.KeyName_LocalPath];
            _dBName = ConfigurationManager.AppSettings[Properties.Resources.KeyName_ServerName];

            //_localPath = @"C:\Caderno Virtual\CV2020";
            //_dBName = "DB.sqlite";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotaConta>()
            .ToTable("NotaContas");

            modelBuilder.Entity<RegistroNota>()
            .ToTable("RegistroNotas");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlite($"Data Source={_localPath}\\{_dBName};");
            }
            catch (System.Exception e)
            {
                throw new System.Exception($"Erro na conex�o com a base de dados! {e.Message}");
            }
        }
    }
}