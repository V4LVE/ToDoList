using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Repository.Enums;

namespace ToDoList.Services.DataTransferObejcts
{
    public class ToDoItemDTO
    {
        /// <summary>
        /// The ID of the ToDoItem.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// The priority of the ToDoItem.
        /// </summary>
        public PriorityEnum Priority { get; set; }

        /// <summary>
        /// The description of the ToDoItem.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The date the ToDoItem was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date the ToDoItem was finished.
        /// </summary>
        public DateTime? DateFinished { get; set; }

        /// <summary>
        /// The status of the ToDoItem.
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
