using Microsoft.AspNetCore.Mvc;
using WebFirstRun.ViewModels;

namespace WebFirstRun.Controllers;

public class UserController : Controller
{
    // GET: UserController
    // public
    // IActionResult
    [HttpGet("/customer-user")]
    // [Route("/customer-user")]
    public IActionResult Index()
    {
        var userListVm = new UserListVm();
        userListVm.Users = new List<UserVm>
        {
            new UserVm { Id = Guid.NewGuid(), Name = "John Doe", Role = "Admin" },
            new UserVm { Id = Guid.NewGuid(), Name = "Jane Doe", Role = "User" }
        };
        return View(userListVm);
    }
    
    // Get Request: To SHow the create page
    public IActionResult Create()
    {
        return View();
    }

    // Post Request: To Create the user
    [HttpPost]
    public IActionResult Create(UserCreateVm userCreateVm)
    {
        var username = userCreateVm.Username;
        var password = userCreateVm.Password;
        var email = userCreateVm.Email;

        if(!ModelState.IsValid)
        {
            return View(userCreateVm);
        }

        if(userCreateVm.Username == "AlreadyExista")
        {
            ModelState.AddModelError("Username", "Username already exists");
        }

        // Add it to the database

        // Open the listing page
        return RedirectToAction("Index");
    }

}
