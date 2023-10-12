using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Services.Interfaces;
using ToDoList.Services.DataTransferObejcts;
using System.Collections.ObjectModel;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using ToDoList.Services.Models;

namespace ToDoList.Pages
{
    public class IndexModel : PageModel
    {
        #region backing fields
        private readonly ILogger<IndexModel> _logger;
        private readonly IToDoItemService _toDoItemService;
        #endregion

        #region Properties
        [BindProperty(SupportsGet = true)]
        public AlertModel Alert { get; set; }
        public ObservableCollection<ToDoItemDTO> ToDoItems { get; set; }
        public ToDoItemDTO ToDoItemForm { get; set; }
        [BindProperty]
        public ToDoList.Repository.Enums.PriorityEnum PriorityForm { get; set; }
        #endregion

        public IndexModel(ILogger<IndexModel> logger, IToDoItemService toDoItemService)
        {
            
            _logger = logger;
            _toDoItemService = toDoItemService;
            //_toDoItemService.SPGetByID("8664CDE3-24FA-4553-8084-40EE9ED862CB");
        }

        public async Task<IActionResult> OnGet(AlertModel alertRes)
        {
            Alert = alertRes;
            ToDoItems = await _toDoItemService.GetAllNotCompletedAsync();
            return Page();
        }

        //Creates a new task
        public async Task<IActionResult> OnPostCreateNewTask(string description)
        {
            if (ModelState.IsValid)
            {
                ToDoItemDTO temp = new ToDoItemDTO
                {
                    ID = Guid.NewGuid(),
                    Priority = PriorityForm,
                    Description = description,
                    DateCreated = DateTime.Now,
                };

                await _toDoItemService.CreateAsync(temp);
                Alert = new AlertModel("Task was created successfully!", "alert alert-success");
                return RedirectToPage(Alert); 
            }
            ToDoItems = await _toDoItemService.GetAllNotCompletedAsync();
            Alert = new AlertModel("An error has occurred while creating your task!", "alert alert-danger");
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