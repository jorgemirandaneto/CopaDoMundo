using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CopaDoMundo.Models
{
    [Table("Jogadores")]
    public class Jogador
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo nome é obrigatório")]
        public string  Nome { get; set; }

        [Required(ErrorMessage = "Campo posição é obrigatório")]
        public string Posicao { get; set; }

        [Required(ErrorMessage = "Campo data de nascimento é obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Nascimento { get; set; }

        [Required(ErrorMessage = "Campo Altura é obrigatório")]
        public double Altura { get; set; }

        public int SelecaoId { get; set; }

        [InverseProperty("Jogadores")]
        public Selecao Selecao { get; set; }
    }
}   