using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERM.Musicas.Web.ViewModels.Musica
{
    public class MusicaViewModel
    {
        [Required(ErrorMessage ="Id obrigatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nome obrigatorio")]
        [MaxLength(50,ErrorMessage ="Tamanho maximo de 50 caracteres")]
        [Display(Name = "Nome musica")]
        public string Nome { get; set; }

        [Required (ErrorMessage ="selecione um album valido")]
        [Display(Name = "Album")]
        public int IdAlbum { get; set; }
    }
}