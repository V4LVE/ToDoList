using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.ObjectModel;
using ToDoList.Services.DataTransferObejcts;
using ToDoList.Services.Interfaces;

namespace ToDoList.Pages
{
    public class CompletedTasksModel : PageModel
    {
        private readonly ILogger<CompletedTasksModel> _logger;
        private readonly IToDoItemService _toDoItemService;

        public ObservableCollection<ToDoItemDTO> ToDoItemsCompleted { get; set; }

        public CompletedTasksModel(ILogger<CompletedTasksModel> logger, IToDoItemService toDoItemService)
        {
            _logger = logger;
            _toDoItemService = toDoItemService;
        }

        public async Task<IActionResult> OnGet()
        {
            ToDoItemsCompleted = await _toDoItemService.GetAllCompletedAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDelete(Guid itemGuid)
        {
            ToDoItemDTO temp = await _toDoItemService.GetByIDAsync(itemGuid);

            if (temp != null)
            {
                _toDoItemService.DeleteAsync(temp);
            }

            return RedirectToPage();
        }
    }
}