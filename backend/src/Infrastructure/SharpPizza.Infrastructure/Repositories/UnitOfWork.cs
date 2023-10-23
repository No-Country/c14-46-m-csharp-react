using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpPizza.Application.Persistence;
using SharpPizza.Infrastructure.Persistence;
using System.Collections;

namespace SharpPizza.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable? _repositories;

        private readonly SharpPizzaDbContext _context;

        public UnitOfWork(SharpPizzaDbContext context)
        {
            _context = context;
        }


        public async Task<int> Complete()
        {
        
            try 
            {
                return await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new Exception("Error en transacion", e);
            }

        }

        public void Dispose()
        {
        _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories is null)
                { 
                    _repositories = new Hashtable();
                }

                var type = typeof(TEntity).Name;

                if (!_repositories.ContainsKey(type))
                {
                    var repositoryType = typeof(RepositoryBase<>);
                    var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                    _repositories.Add(type, repositoryInstance);
                }

                return (IAsyncRepository<TEntity>)_repositories[type]!;


        }
    }
}