using Domain.Entities;
using Domain.Interfaces.Generics;
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
    public class RepositorioCategoria : ICategoria
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;

        public RepositorioCategoria()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }     
        

        public async Task<bool> Add(Categoria objeto)
        {
            using (var data = new ContextBase(_OptionBuilder))
            {
                await data.Set<Categoria>().AddAsync(objeto);
                await data.SaveChangesAsync();
                
            }
            return true;
            
        }

        public async Task<List<Categoria>> List()
        {
            using (var data = new ContextBase(_OptionBuilder))
            {
                return await data.Set<Categoria>().ToListAsync();

            }
        }

        public async Task<Categoria> GetCategoriaById(int Id)
        {
            using (var data = new ContextBase(_OptionBuilder))
            {
                return await data.Set<Categoria>().FindAsync(Id);

            }
        }

       

        public async Task<Categoria> Update(Categoria objeto)
        {
            using (var data = new ContextBase(_OptionBuilder))
            {
                data.Set<Categoria>().Update(objeto);
                await data.SaveChangesAsync();
                return objeto;
            }           
        }

        public async Task<Categoria> Delete(Categoria objeto)
        {
            using (var data = new ContextBase(_OptionBuilder))
            {
                var categoria = await data.Set<Categoria>().FindAsync(objeto.Id);
                if (categoria != null)
                {
                    data.Set<Categoria>().Remove(categoria);
                    await data.SaveChangesAsync();
                    
                }
                return objeto;
            }                       
        }

        
    }
}
