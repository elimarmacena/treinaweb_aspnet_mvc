using ERM.Comum.Entity;
using ERM.Musicas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.Musicas.AcessoDados.Entity.TypeConfiguration
{
    class AlbumTypeConfiguration : ERMEntityAbstractConfig<Album>
    {
        protected override void ConfigurarNomeTabela()
        {
            ToTable("ALB_ALBUNS");
        }

        protected override void ConfigurarCamposTabela()
        {
            Property(a => a.Id).IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("ALB_ID");

            Property(a => a.Nome).IsRequired()
                .HasMaxLength(100)
                .HasColumnName("ALB_NOME");

            Property(a => a.Ano).IsRequired()
                .HasColumnName("ALB_ANO");

            Property(a => a.Observacoes).IsOptional()
                .HasMaxLength(1000)
                .HasColumnName("ALB_OBSERVACAO");

            Property(a => a.Email).IsRequired()
                .HasColumnName("ALB_EMAIL")
                .HasMaxLength(50);

        }

        protected override void ConfigurarPrimaryKey()
        {
            HasKey(a => a.Id);
        }

        protected override void ConfigurarFK()
        {
            //HasMany(p => p.Musicas)
                //.WithRequired(p => p.Album)
                //.HasForeignKey(fk => fk.IdAlbum);
        }
    }
}
