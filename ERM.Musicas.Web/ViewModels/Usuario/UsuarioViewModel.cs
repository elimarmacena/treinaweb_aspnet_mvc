using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERM.Musicas.Web.ViewModels.Usuario
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage ="Email obrigatorio")]
        [MaxLength(100,ErrorMessage ="Email deve conter no maximo 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Senha obrigatoria")]
        [MaxLength(20,ErrorMessage ="Senha deve conter no maximo 20 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}