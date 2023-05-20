using Domain.Entities;
using Domain.Interfaces.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceProduto
{
    public interface IProduto
    {
        Task<bool> Add(Produto objeto);
        Task<Produto> GetProdutoById(int id);
        Task<List<Produto>> List();
        Task<Produto> Update(Produto objeto);
        Task<Produto> Delete(int Id);
    }
}
