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
        [BindProperty]
        public List<ToDoItemDTO> ToDoItems { get; set; }
        public ToDoItemDTO ToDoItem { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public ToDoList.Repository.Enums.Priority PriorityForm { get; set; }
        #endregion

    public IndexModel(ILogger<IndexModel> logger, IToDoItemService toDoItemService)
        {
            _logger = logger;
            _toDoItemService = toDoItemService;
            
        }

        public void OnGet()
        {
            ToDoItems = _toDoItemService.GetAllNotCompletedAsync().Result;
        }

        public void OnPostCreateNewTask()
        {
            ToDoItem = new ToDoItemDTO
            {
                ID = Guid.NewGuid(),
                Priority = PriorityForm,
                Description = Description,
                DateCreated = DateTime.Now,
                DateFinished = null,
                IsCompleted = false
            };

            _toDoItemService.CreateAsync(ToDoItem);

        }
    }
}