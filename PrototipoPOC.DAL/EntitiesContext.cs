using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoPOC.DAL
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext() : base("name=StringConexao")
        {}

        public DbSet<Pessoa> Pessoas {get; set; }
        public DbSet<Telefone> Telefones {get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        

    }
}
