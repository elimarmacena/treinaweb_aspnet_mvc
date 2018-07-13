using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ERM.Musicas.Dominio;
using ERM.Musicas.AcessoDados.Entity.TypeConfiguration;

namespace ERM.Musicas.AcessoDados.Entity.Context
{
    public class MusicasDbContext : DbContext
    {
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Musica> Musicas { get; set; }

        public MusicasDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add( new AlbumTypeConfiguration() );
            modelBuilder.Configurations.Add( new MusicaTypeConfiguration() );
        }
    }

    
}
