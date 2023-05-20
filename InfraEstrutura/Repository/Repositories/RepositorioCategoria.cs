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
                var categoriaOriginal = await data.Set<Categoria>().FindAsync(objeto.Id);

                if (categoriaOriginal != null)
                {                    
                    categoriaOriginal.Nome = objeto.Nome;                    
                    data.Set<Categoria>().Update(categoriaOriginal);                    
                    await data.SaveChangesAsync();
                }

                return categoriaOriginal;
            }           
        }

        public async Task<Categoria> Delete(int Id)
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


    }
}
