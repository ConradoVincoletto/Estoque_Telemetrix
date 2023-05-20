using Domain.Entities;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceProduto;
using InfraEstrutura.Configuration;
using InfraEstrutura.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraEstrutura.Repository.Repositories
{
    public class RepositorioProduto: IProduto
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;
        public RepositorioProduto()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<bool> Add(Produto objeto)
        {
            using (var data = new ContextBase(_OptionBuilder))
            {
                await data.Set<Produto>().AddAsync(objeto);
                await data.SaveChangesAsync();

            }
            return true;
        }

        public async Task<List<Produto>> List()
        {
            using (var data = new ContextBase(_OptionBuilder))
            {
                return await data.Set<Produto>().ToListAsync();

            }
        }

        public async Task<Produto> GetProdutoById(int Id)
        {
            using (var data = new ContextBase(_OptionBuilder))
            {
                return await data.Set<Produto>().FindAsync(Id);

            }
        }

        public async Task<Produto> Update(Produto objeto)
        {
            using (var data = new ContextBase(_OptionBuilder))
            {
                data.Set<Produto>().Update(objeto);
                await data.SaveChangesAsync();
                return objeto;
            }
        }      


        public async Task<Produto> Delete(int Id)
        {
            using (var context = new ContextBase())
            {
                var produto =  context.produtos.FirstOrDefault(p => p.Id == Id);

                if (produto != null)
                {
                    produto.Ativo = false;
                    await context.SaveChangesAsync();                    
                }
                return produto;               

            }
        }

    }
}
