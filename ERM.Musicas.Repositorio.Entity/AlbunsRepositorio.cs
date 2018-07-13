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
    public class AlbunsRepositorio : RepositorioGenericoEntity <Album, int>
    {
        public AlbunsRepositorio(MusicasDbContext contexto)
            : base (contexto)
        {
            
        }

        public override List<Album> Selecionar()
        {
            return _contexto.Set<Album>().Include(p => p.Musicas).ToList();
        }

        public override Album SelecionarPorId(int id)
        {
            return _contexto.Set<Album>().Include(p => p.Musicas).SingleOrDefault(a => a.Id == id);
        }
    }
}
