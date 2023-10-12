using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Repository.Entities;
using ToDoList.Repository.Interfaces;
using ToDoList.Services.DataTransferObejcts;
using ToDoList.Services.Interfaces;

namespace ToDoList.Services.Services
{
    public class UserService : GenericService<UserDTO, IUserRepository, User>, IUserService
    {
        #region backing fields
        private readonly MappingService _mappingService;
        private readonly IUserRepository _userRepository;
        #endregion

        #region Constructor
        public UserService(MappingService mappingService, IUserRepository userRepository) : base(mappingService, userRepository)
        {
            _mappingService = mappingService;
            _userRepository = userRepository;
        }
        #endregion
    }
}
