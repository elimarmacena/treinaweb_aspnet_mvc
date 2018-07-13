using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERM.Musicas.Web.ViewModels.Album
{
    public class AlbumViewModel
    {
        [Required (ErrorMessage ="ID obrigatorio")]
        public int Id { get; set; }

        [Required (ErrorMessage = "Nome do album obrigatorio")]
        [Display(Name = "Nome album")]
        [MaxLength (100,ErrorMessage ="Nome deve possuir no maximo 100 caracteres")]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Ano do album obrigatorio")]
        [Display(Name = "Ano album")]
        public int Ano { get; set; }

        [Display(Name = "Observacoes album")]
        [MaxLength(1000, ErrorMessage ="Oberservacao deve possuir no maximo 1000 caracteres")]
        public string Observacoes { get; set; }

        [Required(ErrorMessage ="Email obrigatorio")]
        [Display(Name = "Email de contato")]
        [MaxLength(50, ErrorMessage ="Email deve possuir no maximo 50 caracteres")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}