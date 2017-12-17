using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_tp3_ariel.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string DataNascimento { get; set; }
    }
}