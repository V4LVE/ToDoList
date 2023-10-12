using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Repository.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public List<ToDoItem>? ToDoItems { get; set; }

    }
}
