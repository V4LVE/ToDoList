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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>().Property(x => x.ID).ValueGeneratedNever();
            //modelBuilder.Entity<User>().Property(x => x.ID).ValueGeneratedNever();

            modelBuilder.Entity<ToDoItem>().HasOne(t => t.User).WithMany(u => u.ToDoItems).HasForeignKey(t => t.UserID);
                

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    ID = 1,
                    Username = "V4LVE",
                    Password = "Pwrvol901"
                });
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
