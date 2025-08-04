using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ToDoList.Repository.Entities;

namespace ToDoList.Repository.Domain
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options) { }
        public DbSet<ToDoItem> ToDoItems { get; set; }


    }
}
