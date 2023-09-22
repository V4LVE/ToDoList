using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Repository.Entities;

namespace ToDoList.Repository.Interfaces
{
    internal interface IToDoItemRepository : IGenericRepository<ToDoItem>
    {
        /// <summary>
        /// Gets all ToDoItems from the database where the status is Completed. 
        /// </summary>
        /// <returns></returns>
        Task<List<ToDoItem>> GetAllCompletedAsync();

        /// <summary>
        /// Gets all ToDoItems from the database where the status is not Completed.
        /// </summary>
        /// <returns></returns>
        Task<List<ToDoItem>> GetAllNotCompletedAsync();

        /// <summary>
        /// Get a ToDoItem by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ToDoItem> GetByIDAsync(Guid id);
    }
}
