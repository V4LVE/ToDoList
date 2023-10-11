using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Services.Models
{
    public class AlertModel
    {

        public string AlertMessage { get; set; }

        public string AlertType { get; set; }

        public AlertModel()
        {
            
        }

        public AlertModel(string alertMessage, string alertType)
        {
            AlertMessage = alertMessage;
            AlertType = alertType;
        }
    }
}
