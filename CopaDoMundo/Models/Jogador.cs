using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CopaDoMundo.Models
{
    [Table("Jogadores")]
    public class Jogador
    {
        public int Id { get; set; }
        public string  Nome { get; set; }
        public string Posicao { get; set; }
        public DateTime Nascimento { get; set; }
        public double Altura { get; set; }
        public int SelecaoId { get; set; }
        [InverseProperty("Jogadores")]
        public Selecao Selecao { get; set; }
    }
}