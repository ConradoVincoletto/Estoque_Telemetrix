using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITelemetrix
    {
        Task<List<Produto>> ListarProdutos();
        Task<bool> AdicionarProduto(Produto produto);
        Task<Produto> ObterProdutoPorId(int Id);
    }
}
