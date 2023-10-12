﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Repository.Entities;

namespace ToDoList.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
