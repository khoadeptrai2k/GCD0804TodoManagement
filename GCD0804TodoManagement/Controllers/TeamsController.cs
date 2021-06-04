using GCD0804TodoManagement.Models;
using System.Linq;
using System.Web.Mvc;

namespace GCD0804TodoManagement.Controllers
{
  [Authorize(Roles = "manager")]
  public class TeamsController : Controller
  {
    private ApplicationDbContext _context;
    public TeamsController()
    {
      _context = new ApplicationDbContext();
    }
    // GET: Teams
    [HttpGet]
    public ActionResult Index()
    {
      var teams = _context.Teams.ToList();
      return View(teams);
    }

    [HttpGet]
    public ActionResult Details(int id)
    {
      var users = _context.TeamsUsers
        .Where(t => t.TeamId == id)
        .Select(t => t.User)
        .ToList();

      return View(users);
    }
  }
}