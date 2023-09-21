using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Repository.Enums;

namespace ToDoList.Repository.Model
{
    public class ToDoItem
    {
        [Key]
        public Guid ID { get; set; }
        [DefaultValue(Priority.Normal)]
        public Priority Priority { get; set; }
        [MaxLength(25), Required]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateFinished { get; set; }
        [DefaultValue(false)]
        public bool IsCompleted { get; set; }
    }
}
