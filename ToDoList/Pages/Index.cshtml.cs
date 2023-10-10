using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Services.Interfaces;
using ToDoList.Services.DataTransferObejcts;
using System.Collections.ObjectModel;

namespace ToDoList.Pages
{
    public class IndexModel : PageModel
    {
        #region backing fields
        private readonly ILogger<IndexModel> _logger;
        private readonly IToDoItemService _toDoItemService;
        #endregion

        #region Properties
        public ObservableCollection<ToDoItemDTO> ToDoItems { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public ToDoList.Repository.Enums.PriorityEnum PriorityForm { get; set; }
        #endregion

        public IndexModel(ILogger<IndexModel> logger, IToDoItemService toDoItemService)
        {
            _logger = logger;
            _toDoItemService = toDoItemService;

        }

        public async Task<IActionResult> OnGet()
        {
            ToDoItems = await _toDoItemService.GetAllNotCompletedAsync();

            return Page();
        }

        //Creates a new task
        public async Task<IActionResult> OnPostCreateNewTask()
        {
            if (ModelState.IsValid)
            {
                ToDoItemDTO temp = new ToDoItemDTO
                {
                    ID = Guid.NewGuid(),
                    Priority = PriorityForm,
                    Description = Description,
                    DateCreated = DateTime.Now,
                };

                await _toDoItemService.CreateAsync(temp);
                return RedirectToPage(); 
            }
            ToDoItems = await _toDoItemService.GetAllNotCompletedAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostCompleteTaskAsync(Guid itemID)
        {
            ToDoItemDTO temp = await _toDoItemService.GetByIDAsync(itemID);
            temp.IsCompleted = true;
            temp.DateFinished = DateTime.Now;

            await _toDoItemService.UpdateAsync(temp);

            return RedirectToPage();
        }
    }
}