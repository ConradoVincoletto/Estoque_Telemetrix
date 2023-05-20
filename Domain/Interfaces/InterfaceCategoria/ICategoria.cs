using Domain.Entities;
using Domain.Interfaces.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceCategoria
{
    public interface ICategoria
    {
        Task<bool> Add(Categoria objeto);
        Task<Categoria> GetCategoriaById(int id);
        Task<List<Categoria>> List();
        Task<Categoria> Update(Categoria objeto);
        Task<Categoria> Delete(int Id);
    }
}
