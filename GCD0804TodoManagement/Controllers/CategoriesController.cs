using GCD0804TodoManagement.Models;
using System.Web.Mvc;

namespace GCD0804TodoManagement.Controllers
{
  [Authorize]
  public class CategoriesController : Controller
  {
    private ApplicationDbContext _context;
    public CategoriesController()
    {
      _context = new ApplicationDbContext();
    }
    // GET: Categories
    [Authorize(Roles = "user, manager")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet]
    [Authorize(Roles = "manager")]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [Authorize(Roles = "manager")]
    public ActionResult Create(Category model)
    {
      return RedirectToAction("Index");
    }
  }
}