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
  }
}