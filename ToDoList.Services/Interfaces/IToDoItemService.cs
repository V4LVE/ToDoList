using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Repository.Entities;
using ToDoList.Repository.Interfaces;
using ToDoList.Services.DataTransferObejcts;

namespace ToDoList.Services.Interfaces
{
    public interface IToDoItemService : IGenericRepository<ToDoItemDTO>
    {
        /// <summary>
        /// Gets all ToDoItems from the database where the status is Completed. 
        /// </summary>
        /// <returns></returns>
        Task<List<ToDoItemDTO>> GetAllCompletedAsync();

        /// <summary>
        /// Gets all ToDoItems from the database where the status is not Completed.
        /// </summary>
        /// <returns></returns>
        Task<List<ToDoItemDTO>> GetAllNotCompletedAsync();

        /// <summary>
        /// Get a ToDoItem by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ToDoItemDTO> GetByIDAsync(Guid id);
    }
}
