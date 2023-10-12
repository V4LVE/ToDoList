using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Repository.Domain;
using ToDoList.Repository.Entities;
using ToDoList.Repository.Interfaces;

namespace ToDoList.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        #region Backing fields
        private readonly ToDoListContext _dbContext;
        #endregion

        #region Constructor
        public UserRepository(ToDoListContext context) : base(context)
        {
            _dbContext = context;
        }
        #endregion

        public bool checkIfValid(string username, string password)
        {
            User temp = _dbContext.Users.FirstOrDefault(x => x.Username == username);

            if (temp != null && temp.Username == username && temp.Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.Users.Where(x => x.Username == username).AsNoTracking().FirstOrDefaultAsync();

        }
    }
}
