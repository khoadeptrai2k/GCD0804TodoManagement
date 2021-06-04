using GCD0804TodoManagement.Models;
using System.Collections.Generic;

namespace GCD0804TodoManagement.ViewModels
{
  public class TeamUsersViewModel
  {
    public Team Team { get; set; }
    public string UserId { get; set; }
    public IEnumerable<ApplicationUser> Users { get; set; }
  }
}