using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CopaDoMundo.Models
{
    [Table("Selecoes")]
    public class Selecao
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pais é um campo obrigatório")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Técnico é um campo obrigatório")]
        public string Tecnico { get; set; }

        public virtual List<Jogador> Jogadores { get; set; }
    }
}