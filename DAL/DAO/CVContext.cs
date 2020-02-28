using Microsoft.EntityFrameworkCore;
using Model.Classes;
using Model.Classes.ClienteModel;

namespace DAL.DAO
{
    public class CVContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Atendente> Atendentes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotaConta>()
            .ToTable("NotaContas");

            modelBuilder.Entity<RegistroNota>()
            .ToTable("RegistroNotas");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DB.sqlite;");
        }
    }
}