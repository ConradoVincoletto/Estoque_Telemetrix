using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("TB_PRODUTO")]
    public class Produto
    {
        [Key]
        [Column("PRODUTO_ID")]        
        public int Id { get; set; }

        [Column("PRODUTO_NOME")]       
        public string Nome { get; set; }

        [Column("PRODUTO_CATEGORA")]        
        public Categoria categoria { get; set; }

        [Column("PRODUTO_QUANTIDADE")]        
        public decimal QuantidadeDisponivel { get; set; }

        [Column("PRODUTO_DATA_CRIAÇÃO")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [Column("PRODUTO_ATIVO")]
        public bool Ativo { get; set; }
    }
}
