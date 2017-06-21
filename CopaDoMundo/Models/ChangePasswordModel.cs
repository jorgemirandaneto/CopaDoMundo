using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CopaDoMundo.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100,ErrorMessage ="A senha deve ter no minimo 6 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        public string NewPassword { get; set; }
        
        [Required]
        public string ConfirmPassword { get; set; }
    }
}