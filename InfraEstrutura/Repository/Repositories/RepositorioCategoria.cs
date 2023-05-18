using Domain.Entities;
using Domain.Interfaces.InterfaceCategoria;
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
    public class RepositorioCategoria : RepositoryGenerics<Categoria>, ICategoria
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;

        public RepositorioCategoria()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
