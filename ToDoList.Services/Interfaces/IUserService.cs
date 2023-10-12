using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Repository.Interfaces;
using ToDoList.Services.DataTransferObejcts;

namespace ToDoList.Services.Interfaces
{
    public interface IUserService : IGenericRepository<UserDTO>
    {
        public bool CheckIfValid(string username, string password);

        public Task<UserDTO> GetUserByUsernameAsync(string username);
    }
}
