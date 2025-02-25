using System;
using System.ComponentModel.DataAnnotations;

namespace WebFirstRun.ViewModels;

public class UserCreateVm
{
    [Required]
    public string Username { get; set; }

    public string Password { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
}
