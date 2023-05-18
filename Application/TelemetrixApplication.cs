using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.InterfaceProduto;

namespace Application
{
    public class TelemetrixApplication : ITelemetrix
    {
        private readonly IProduto _iProduto;
        public TelemetrixApplication(IProduto iProduto)
        {
            _iProduto = iProduto;
        }
        public async Task<List<Produto>>  ListarProdutos()
        {
            var produtos = await _iProduto.List();

            return produtos.Where(p => p.Ativo).ToList();
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
            var produto =  await _iProduto.GetEntityById(id);
            if(produto == null)
            {
                return new Produto();
            }
            if (produto.Ativo)
            {
                return produto;
            }
            return new Produto();
        }
        private async Task<bool> PermiteAdicionarProduto(Categoria categoria) 
        {
            var produtos = await _iProduto.List();
            int qtdProdutos = produtos.Count(p => p.categoria.Id == categoria.Id);
            return qtdProdutos < categoria.MaximoItens;
        }

        

    }
}