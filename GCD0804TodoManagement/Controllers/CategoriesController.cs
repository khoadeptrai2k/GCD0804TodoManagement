using GCD0804TodoManagement.Models;
using System.Linq;
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
      var categories = _context.Categories.ToList();
      return View(categories);
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
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      var category = new Category
      {
        Name = model.Name
      };

      _context.Categories.Add(category);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}