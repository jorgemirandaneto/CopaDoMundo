using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CopaDoMundo.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }
        
        [Required]
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100,ErrorMessage = "Senha não pode ter menos de 6 carateres",MinimumLength =6)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Senha não confere")]
        [Display(Name = "Confirmação de senha")]
        public string ConfirmPassword { get; set; }
    }
}