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
    }
}
