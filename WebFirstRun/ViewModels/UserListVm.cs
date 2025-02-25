using System;

namespace WebFirstRun.ViewModels;

public class UserListVm
{
    public List<UserVm> Users { get; set; } = new();
    
    public int Page { get; set; }

}

public class UserVm
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
}
