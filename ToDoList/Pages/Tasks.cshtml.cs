using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Services.Interfaces;
using ToDoList.Services.DataTransferObejcts;
using System.Collections.ObjectModel;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using ToDoList.Services.Models;
using ToDoList.Repository.Entities;

namespace ToDoList.Pages
{
    public class TasksModel : PageModel
    {
        #region backing fields
        private readonly ILogger<TasksModel> _logger;
        private readonly IToDoItemService _toDoItemService;
        private readonly IUserService _userService;
        #endregion

        #region Properties
        [BindProperty(SupportsGet = true)]
        public UserDTO UserReqested { get; set; }

        [BindProperty(SupportsGet = true)]
        public AlertModel Alert { get; set; }

        public ObservableCollection<ToDoItemDTO> ToDoItems { get; set; }

        public ToDoItemDTO ToDoItemForm { get; set; }

        [BindProperty]
        public ToDoList.Repository.Enums.PriorityEnum PriorityForm { get; set; }
        #endregion

        public TasksModel(ILogger<TasksModel> logger, IToDoItemService toDoItemService, IUserService userService)
        {
            
            _logger = logger;
            _toDoItemService = toDoItemService;
            _userService = userService;
            //_toDoItemService.SPGetByID("8664CDE3-24FA-4553-8084-40EE9ED862CB");
        }

        public async Task<IActionResult> OnGet(AlertModel alertRes, string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return RedirectToPage("/Error");
            }
            Alert = alertRes;
            UserReqested = await _userService.GetUserByUsernameAsync(username);
            ToDoItems = await _toDoItemService.GetAllNotCompletedByUserIdAsync(UserReqested.ID);
            return Page();
        }

        //Creates a new task
        public async Task<IActionResult> OnPostCreateNewTask(string description, string username)
        {
            UserDTO tempUser = await _userService.GetUserByUsernameAsync(username);

            if (ModelState.IsValid)
            {
                ToDoItemDTO temp = new ToDoItemDTO
                {
                    ID = Guid.NewGuid(),
                    UserID = tempUser.ID,
                    Priority = PriorityForm,
                    Description = description,
                    DateCreated = DateTime.Now,
                };

                await _toDoItemService.CreateAsync(temp);
                Alert = new AlertModel("Task was created successfully!", "alert alert-success");
                return RedirectToPage(Alert); 
            }
            ToDoItems = await _toDoItemService.GetAllNotCompletedByUserIdAsync(UserReqested.ID);
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