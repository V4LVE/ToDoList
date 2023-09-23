using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Repository.Interfaces;
using ToDoList.Repository.Domain;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Repository.Repositories
{
    public abstract class GenericRepository<E> : IGenericRepository<E> where E : class
    {
        #region Backing fields
        private readonly ToDoListContext _dbContext;
        #endregion

        #region Constructor
        protected GenericRepository(ToDoListContext context)
        {
            _dbContext = context;
        }
        #endregion

        public async Task CreateAsync(E entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(E entity)
        {
            _dbContext.Set<E>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<E>> GetAllAsync()
        {
            return await _dbContext.Set<E>().AsNoTracking().ToListAsync();
        }

        public async Task DeleteAsync(E entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
