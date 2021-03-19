using System;
using System.Collections;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        // все репозитории будут храниться тут во вермя выполнение юнит оф ворка
        private Hashtable _repositories;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            // если репозитория еще не было, то инициализуруем хештейбл
            if (_repositories == null) _repositories = new Hashtable();

            // получаем имя дженерик типа
            var type = typeof(TEntity).Name;

            // если нет такого репозитория, то ...
            if (!_repositories.ContainsKey(type))
            {
                // .. тип для создания инстанса
                var repositoryType = typeof(GenericRepository<>);
                // создаем интсанс дженерик репозитория и передаем внутрь контекст
                var repositoryInstance = Activator.CreateInstance(
                    repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>)_repositories[type];
        }
    }
}