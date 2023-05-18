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
    public class RepositoryGenerics<T> : IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;
        public RepositoryGenerics()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task Add(T Objeto)
        {
            using (var data = new ContextBase(_OptionBuilder))
            {
                await data.Set<T>().AddAsync(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T Objeto)
        {
            using (var data = new ContextBase(_OptionBuilder))
            {
                data.Set<T>().Remove(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetEntityById(int Id)
        {
            using (var data = new ContextBase(_OptionBuilder))
            {
                return await data.Set<T>().FindAsync(Id);

            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new ContextBase(_OptionBuilder))
            {
                return await data.Set<T>().ToListAsync();

            }
        }

        public async Task Update(T Objeto)
        {
            using (var data = new ContextBase(_OptionBuilder))
            {
                data.Set<T>().Update(Objeto);
                await data.SaveChangesAsync();
            }
        }

        bool disposed = false;

        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                handle.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            disposed = true;
        }
    }
}
