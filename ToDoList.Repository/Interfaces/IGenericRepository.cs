using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Repository.Interfaces
{
    internal interface IGenericRepository<E> where E : class
    {
        /// <summary>
        /// Adds an entity to the database
        /// </summary>
        /// <param name="entity"></param>
        Task CreateAsync(E entity);

        /// <summary>
        /// Updates an entiry in the database
        /// </summary>
        /// <param name="entity"></param>
        Task UpdateAsync(E entity);

        /// <summary>
        /// Deletes an entity from the database
        /// </summary>
        /// <param name="entity"></param>
        Task DeleteAsync(E entity);

        /// <summary>
        /// Gets an entities from the database
        /// </summary>
        /// <returns></returns>
        Task<List<E>> GetAllAsync(E entiry);
    }
}
