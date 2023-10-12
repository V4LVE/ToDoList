using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Services.DataTransferObejcts;
using ToDoList.Services.Interfaces;
using ToDoList.Services.Models;

namespace ToDoList.Web.Pages
{
    public class EditModel : PageModel
    {
        private readonly IToDoItemService _toDoItemService;

        [BindProperty]
        public ToDoItemDTO EditItem { get; set; }

        public EditModel(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        public async Task<IActionResult> OnGet(Guid guid)
        {
            if (guid == Guid.Empty)
            {
                return RedirectToPage("/Error");
            }

            EditItem = await _toDoItemService.GetByIDAsync(guid);

            return Page();
        }

        public async Task<IActionResult> OnPostEditTaskAsync()
        {
            if (ModelState.IsValid)
            {
                await _toDoItemService.UpdateAsync(EditItem);
                AlertModel tempAlert = new("Task was successfully updated!", "alert alert-success");
                return RedirectToPage("/Index", tempAlert);
            }

            return Page();
        }
    }
}
