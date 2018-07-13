using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERM.Musicas.Web.ViewModels.Musica
{
    public class MusicaShowViewModel
    {
        
        public int Id { get; set; }

        [Display(Name ="Nome musica")]
        public string Nome { get; set; }

        [Display(Name = "Nome album")]
        public string NomeAlbum { get; set; }
    }
}