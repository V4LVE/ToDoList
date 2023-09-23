using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Services.Interfaces;
using ToDoList.Services.DataTransferObejcts;

namespace ToDoList.Pages
{
    public class IndexModel : PageModel
    {
        #region backing fields
        private readonly ILogger<IndexModel> _logger;
        private readonly IToDoItemService _toDoItemService;
        #endregion

        #region Properties
        public List<ToDoItemDTO> ToDoItems { get; set; }
        #endregion

        public IndexModel(ILogger<IndexModel> logger, IToDoItemService toDoItemService)
        {
            _logger = logger;
            _toDoItemService = toDoItemService;
            
        }

        public void OnGet()
        {
            ToDoItems = new List<ToDoItemDTO>();
        }
    }
}