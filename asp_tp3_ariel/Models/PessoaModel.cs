using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace asp_tp3_ariel.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Seu nome deve ter no máximo 10 caracteres")]
        public string Nome { get; set; }

        
        public string Sobrenome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
    }
}