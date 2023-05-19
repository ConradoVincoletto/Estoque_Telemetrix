using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface IGenerics<T> where T : class
    {

        Task<List<T>> List();
        Task<T> GetEntityById(int id);
        Task<bool> Add(T objeto);
        Task<bool> Update(T objeto);
        Task<bool> Delete(int Id);
        Task ExecutarMigracao();

    }
}
