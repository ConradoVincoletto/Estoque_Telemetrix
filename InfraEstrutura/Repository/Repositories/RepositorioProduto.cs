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
    public class RepositorioProduto: RepositoryGenerics<Produto>, IProduto
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;
        public RepositorioProduto()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task ExecutarMigracao()
        {
            throw new NotImplementedException();
        }

        Task<bool> IGenerics<Produto>.Add(Produto objeto)
        {
            throw new NotImplementedException();
        }

        Task<bool> IGenerics<Produto>.Update(Produto objeto)
        {
            throw new NotImplementedException();
        }
    }
}
