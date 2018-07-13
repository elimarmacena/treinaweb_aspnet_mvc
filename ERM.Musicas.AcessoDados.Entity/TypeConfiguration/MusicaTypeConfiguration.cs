using ERM.Comum.Entity;
using ERM.Musicas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.Musicas.AcessoDados.Entity.TypeConfiguration
{
    class MusicaTypeConfiguration : ERMEntityAbstractConfig<Musica>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(m => m.Id)
                .HasColumnName("MUS_ID")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();
            Property(m => m.Nome)
                .HasColumnName("MUS_NOME")
                .HasMaxLength(50)
                .IsRequired();
            Property(m => m.IdAlbum)
                .HasColumnName("ALB_ID")
                .IsRequired();
        }

        protected override void ConfigurarFK()
        {
            HasRequired(m => m.Album)
                .WithMany(m => m.Musicas)
                .HasForeignKey(fk => fk.IdAlbum);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("MUS_MUSICAS");
        }

        protected override void ConfigurarPrimaryKey()
        {
            HasKey(pk => pk.Id);
        }
    }
}
