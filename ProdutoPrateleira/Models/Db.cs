namespace ProdutoPrateleira.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ProdutoPrateleira.Models;

    public partial class Db : DbContext
    {
        public Db()
            : base("name=Db")
        {
        }

        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Prateleira> Prateleiras { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
