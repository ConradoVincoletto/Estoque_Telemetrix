using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool ControlaEstoque { get; set; }
        public int MaximoItens { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }

    }
}
