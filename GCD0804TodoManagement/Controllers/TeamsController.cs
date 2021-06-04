using GCD0804TodoManagement.Models;
using GCD0804TodoManagement.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GCD0804TodoManagement.Controllers
{
  public class TeamsController : Controller
  {
    private ApplicationDbContext _context;
    private UserManager<ApplicationUser> _userManager;
    public TeamsController()
    {
      _context = new ApplicationDbContext();
      _userManager = new UserManager<ApplicationUser>(
        new UserStore<ApplicationUser>(new ApplicationDbContext()));
    }
    [Authorize(Roles = "manager")]
    // GET: Teams
    [HttpGet]
    public ActionResult Index()
    {
      var teams = _context.Teams.ToList();
      return View(teams);
    }
    [Authorize(Roles = "manager")]

    [HttpGet]
    public ActionResult Details(int id)
    {
      var users = _context.TeamsUsers
        .Where(t => t.TeamId == id)
        .Select(t => t.User)
        .ToList();

      ViewBag.TeamId = id;

      return View(users);
    }
    [Authorize(Roles = "manager")]

    [HttpGet]
    public ActionResult AddMember(int id)
    {
      var users = _context.Users.ToList();

      var usersInTeam = _context.TeamsUsers
        .Where(t => t.TeamId == id)
        .Select(t => t.User)
        .ToList();

      var usersWithUserRole = new List<ApplicationUser>();

      foreach (var user in users)
      {
        if (_userManager.GetRoles(user.Id)[0].Equals("user")
          && !usersInTeam.Contains(user)
          )
        {
          usersWithUserRole.Add(user);
        }
      }

      var viewModel = new TeamUsersViewModel
      {
        TeamId = id,
        Users = usersWithUserRole
      };

      return View(viewModel);
    }
    [Authorize(Roles = "manager")]

    [HttpPost]
    public ActionResult AddMember(TeamUser model)
    {
      var teamUser = new TeamUser
      {
        TeamId = model.TeamId,
        UserId = model.UserId
      };

      _context.TeamsUsers.Add(teamUser);
      _context.SaveChanges();

      return RedirectToAction("Index");
    }
    [Authorize(Roles = "manager")]

    [HttpGet]
    public ActionResult RemoveUser(int id, string userId)
    {
      var teamUser = _context.TeamsUsers
        .SingleOrDefault(t => t.TeamId == id && t.UserId == userId);

      if (teamUser == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      _context.TeamsUsers.Remove(teamUser);
      _context.SaveChanges();

      return RedirectToAction("Details", new { id = id });
    }

    [Authorize(Roles = "user")]
    public ActionResult Mine()
    {
      var userId = User.Identity.GetUserId();

      var teams = _context.TeamsUsers
        .Where(t => t.UserId.Equals(userId))
        .Select(t => t.Team)
        .ToList();

      return View(teams);
    }
  }
}