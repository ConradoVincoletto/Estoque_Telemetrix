using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.InterfaceCategoria;
using Domain.Interfaces.InterfaceProduto;
using InfraEstrutura.Configuration;
using Microsoft.VisualBasic;

namespace Application
{
    public class TelemetrixApplication : ITelemetrix
    {
        private readonly IProduto _iProduto;
        private readonly ICategoria _iCategoria;
        public TelemetrixApplication(IProduto iProduto)
        {
            _iProduto = iProduto;
        }        

        public Task<Produto> AtualizarProduto(Produto produto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Categoria>> ListarCategorias()
        {
            var categoria = await _iCategoria.List();

            return categoria.Where(c => c.Ativo).ToList();
        }
        public async Task<List<Produto>> ListarProdutos()
        {
            var produtos = await _iProduto.List();

            return produtos.Where(p => p.Ativo).ToList();
        }

        public async Task<bool> AdicionarCategoria(Categoria categoria)
        {
            await _iCategoria.Add(categoria);
            return true;
        }
        public async Task<bool> AdicionarProduto(Produto produto)
        {
            if (await PermiteAdicionarProduto(produto.categoria))
            {
                await _iProduto.Add(produto);
                return true;
            }
            else { return false; }

        }

        public async Task<Produto> ObterProdutoPorId(int id)
        {
            var produto = await _iProduto.GetEntityById(id);
            if (produto == null)
            {
                return new Produto();
            }
            if (produto.Ativo)
            {
                return produto;
            }
            return new Produto();
        }

        public async Task<Categoria> ObterCategoriaPorId(int Id)
        {
            var categoria = await _iCategoria.GetEntityById(Id);
            if(categoria == null)
            {
                return new Categoria();
            }
            if (categoria.Ativo)
            {
                return categoria;
            }
            return new Categoria();
        }


        private async Task<bool> PermiteAdicionarProduto(Categoria categoria)
        {
            var produtos = await _iProduto.List();
            int qtdProdutos = produtos.Count(p => p.categoria.Id == categoria.Id);
            return qtdProdutos < categoria.MaximoItens;
        }             

        public Task<Categoria> AtualizarCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}