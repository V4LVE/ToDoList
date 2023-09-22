﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Repository.Entities;
using ToDoList.

namespace ToDoList.Repository.Domain
{
    public class ToDoListContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ALEX_PC\\SQLEXPRESS;Database=ToDoListDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
