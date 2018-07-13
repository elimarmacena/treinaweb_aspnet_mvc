using ERM.Musicas.Web.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERM.Musicas.Web.ViewModels.Album
{
    public class AlbumShowViewModel
    {
        public int Id { get; set; }

        [Display (Name ="Nome album")]
        public string Nome { get; set; }

        [Display(Name = "Ano album")]
        public int Ano { get; set; }

        [Display(Name = "Observacoes album")]
        public string Observacoes { get; set; }

        [Display(Name = "Email de contato")]
        [DataType(DataType.EmailAddress)]
        [EmailTreinaWeb]
        public string Email { get; set; }
    }
}