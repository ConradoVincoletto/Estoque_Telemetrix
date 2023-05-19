using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraEstrutura.Configuration
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }

        public ContextBase()
        {
        }

        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Produto> produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Produto>()
                //.HasOne(a => a.categoria);           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(GetStringConectionConfig(), ServerVersion.Parse("8.0.31-mysql"));
                base.OnConfiguring(optionsBuilder);
            }
        }

        private string GetStringConectionConfig()
        {
            string strCon = "Server=localhost;initial catalog=telemetrix;uid=root;pwd=123456";
            return strCon;
        }

        public override int SaveChanges()
        {
            //Soft-Delete
            foreach (var item in ChangeTracker.Entries()
               .Where(e => e.State == EntityState.Deleted &&
               e.Metadata.GetProperties().Any(x => x.Name == "Ativo")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["Ativo"] = true;
            }
            return base.SaveChanges();
        }
    }
}
