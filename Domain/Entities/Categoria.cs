    using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("TB_CATEGORIA")]
    public class Categoria
    {
        [Key]
        [Column("CATEGORIA_ID")]
        public int Id { get; set; }

        [Column("CATEGORIA_NOME")]
        public string Nome { get; set; }

        [Column("CATEGORIA_CONTROLA_ESTOQUE")]
        public bool ControlaEstoque { get; set; }

        [Column("CATEGORIA_MAXIMO_ITENS")]
        public int MaximoItens { get; set; }

        [Column("CATEGORIA_DATA_CRIACAO")]
        
        public DateTime DataCriacao { get; set; }

        [Column("CATEGORIA_ATIVO")]
        public bool Ativo { get; set; }

    }
}
