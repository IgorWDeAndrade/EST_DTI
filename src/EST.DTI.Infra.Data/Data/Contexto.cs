using EST.DTI.Domain.Entity;
using EST.DTI.Infra.Data.EFConfiguracoes;
using Microsoft.EntityFrameworkCore;

namespace EST.DTI.Infra.Data.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        #region DB_Sets

        public DbSet<Produto> Produtos { get; set; }

        #endregion

        #region EF Configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutosMap());
        }

        #endregion
    }
}
