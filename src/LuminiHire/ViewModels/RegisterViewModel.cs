using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LuminiHire.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Usuário")]
        public string User { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Nome do Usuário")]
        public string Name { get; set; }
    }
}
