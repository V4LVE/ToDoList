﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Repository.Entities;
using ToDoList.Repository.Interfaces;
using ToDoList.Repository.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace ToDoList.Repository.Repositories
{
    public class ToDoItemRepository : GenericRepository<ToDoItem>, IToDoItemRepository
    {
        #region Backing fields
        private readonly ToDoListContext _dbContext;
        #endregion

        #region Constructor
        public ToDoItemRepository(ToDoListContext context) : base(context)
        {
            _dbContext = context;
        }
        #endregion

        public async Task<ObservableCollection<ToDoItem>> GetAllCompletedAsync()
        {
            ObservableCollection<ToDoItem> temp = new(await _dbContext.ToDoItems.Where(x => x.IsCompleted == true).AsNoTracking().ToListAsync());

            return temp;
        }

        public async Task<ObservableCollection<ToDoItem>> GetAllNotCompletedAsync()
        {
            ObservableCollection<ToDoItem> temp = new(await _dbContext.ToDoItems.Where(x => x.IsCompleted == false).AsNoTracking().ToListAsync());

            return temp;
        }

        public async Task<ToDoItem> GetByIDAsync(Guid id)
        {
            return await _dbContext.ToDoItems.Where(x => x.ID == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
