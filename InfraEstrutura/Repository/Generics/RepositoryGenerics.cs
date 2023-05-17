using InfraEstrutura.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InfraEstrutura.Repository.Generics
{
    public class RepositoryGenerics<TEntity> : IDisposable where TEntity : class
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryGenerics(DbContextOptions<ContextBase> optionsBuilder)
        {
            _OptionsBuilder = optionsBuilder;
        }

        public async Task CreateAsync(TEntity entity)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                await data.AddAsync(entity);
                await data.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<TEntity>().ToListAsync();
            }
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<TEntity>().FindAsync(id);
            }
        }

        public async Task UpdateAsync(int id, TEntity entity)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<TEntity>().Update(entity);
                await data.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<TEntity>().Where(predicate).ToListAsync();
            }
        }

        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();                
            }

            disposed = true;
        }
    }
}
