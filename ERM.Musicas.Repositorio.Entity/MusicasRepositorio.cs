using ERM.Musicas.AcessoDados.Entity.Context;
using ERM.Musicas.Dominio;
using ERM.Repositorio.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ERM.Musicas.Repositorio.Entity
{
    public class MusicasRepositorio : RepositorioGenericoEntity<Musica,long>
    {
        public MusicasRepositorio(MusicasDbContext contexto)
            :base(contexto)
        {

        }

        public override List<Musica> Selecionar()
        {
            return _contexto.Set<Musica>().Include(p => p.Album).ToList();
        }

        public override Musica SelecionarPorId(long id)
        {
            return _contexto.Set<Musica>().Include(p => p.Album).SingleOrDefault(m => m.Id == id);
        }
    }
}
