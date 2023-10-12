using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Services.Interfaces;
using ToDoList.Services.Models;
using ToDoList.Services.Services;

namespace ToDoList.Web.Pages
{
    public class IndexModel : PageModel
    {
        public string StatusMessage { get; set; }

        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPostLogin(string username, string password)
        {
            if (_userService.CheckIfValid(username,password))
            {
                AlertModel temp = new($"Welcome {username}", "alert alert-info");
                return RedirectToPage("Tasks", new { username = username });
            }
            else
            {
                StatusMessage = "Invalid username or password. Please try again.";
                return Page();
            }
            
        }
    }
}
