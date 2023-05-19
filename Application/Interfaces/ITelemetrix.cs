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
        //Tarefas Produtos
        Task<List<Produto>> ListarProdutos();
        Task<bool> AdicionarProduto(Produto produto);
        Task<Produto> ObterProdutoPorId(int Id);
        Task<Produto> AtualizarProduto(Produto produto);
        

        //Tarefas Categorias
        Task<List<Categoria>> ListarCategorias();
        Task<bool> AdicionarCategoria(Categoria categoria);
        Task<Categoria> ObterCategoriaPorId(int Id);
        Task<Categoria> AtualizarCategoria(Categoria categoria);
        
    }
}
