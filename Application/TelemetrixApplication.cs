using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.InterfaceCategoria;
using Domain.Interfaces.InterfaceProduto;
using InfraEstrutura.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Application
{
    public class TelemetrixApplication : ITelemetrix
    {
        private readonly IProduto _iProduto;
        private readonly ICategoria _iCategoria;
        public TelemetrixApplication(IProduto iProduto, ICategoria iCategoria)
        {
            _iProduto = iProduto;
            _iCategoria = iCategoria;
        }  
        

        public async Task<Produto> AtualizarProduto(Produto produto)
        {
            await _iProduto.Update(produto);
            return new Produto();
        }

        public async Task<Categoria> AtualizarCategoria(Categoria categoria)
        {
            await _iCategoria.Update(categoria);
            return new Categoria();
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
            if (await PermiteAdicionarProduto(produto.CategoriaId))
            {
                await _iProduto.Add(produto);
                return true;
            }
            else { return false; }

        }

        public async Task<Produto> ObterProdutoPorId(int id)
        {
            var produto = await _iProduto.GetProdutoById(id);
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
            var categoria = await _iCategoria.GetCategoriaById(Id);
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


        public async Task<Produto> InativarProduto(int Id)
        {
            using (var context = new ContextBase())
            {
                var produto = context.produtos.FirstOrDefault(p => p.Id == Id);

                if (produto != null)
                {
                    produto.Ativo = false;
                    await context.SaveChangesAsync();
                }
                return produto;

            }
        }

        public async Task<Categoria> InativarCategoria(int Id)
        {
            using (var context = new ContextBase())
            {
                var categoria = context.categorias.FirstOrDefault(p => p.Id == Id);

                if (categoria != null)
                {
                    categoria.Ativo = false;
                    await context.SaveChangesAsync();
                }
                return categoria;

            }
        }


        private async Task<bool> PermiteAdicionarProduto(int categoriaId)
        {
            //verificando se existe alguma categoria cadastrado
            var categorias = await _iCategoria.List();
            if(!categorias.Any()) { return false; }

            //verificando se categoria excede quantidade máxima de produtos cadastrados 
            var produtos = await _iProduto.List();
            int qtdProdutos = produtos.Count(p => p.CategoriaId == categoriaId);
            var categoria = categorias.FirstOrDefault(i => i.Id == categoriaId);
            if(categoria == null) { return false; }
            return qtdProdutos < categoria.MaximoItens;
        }             

      
    }
}