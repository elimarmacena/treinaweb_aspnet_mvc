﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.Musicas.Dominio
{
    public class Album
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public string Observacoes { get; set; }
        public string Email { get; set; }

        //prop de navegacao
        public virtual List<Musica> Musicas { get; set; }

    }
}
