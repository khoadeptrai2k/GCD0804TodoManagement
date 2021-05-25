using GCD0804TodoManagement.Models;
using System.Linq;
using System.Web.Mvc;

namespace GCD0804TodoManagement.Controllers
{
	public class TodoesController : Controller
	{
		private ApplicationDbContext _context;

		public TodoesController()
		{
			_context = new ApplicationDbContext();
		}

		// GET: Todoes
		public ActionResult Index()
		{
			var todoesInDb = _context.Todoes.ToList();
			return View(todoesInDb);
		}

		public ActionResult Details(int id)
		{
			var todo = _context.Todoes.SingleOrDefault(t => t.Id == id);

			if (todo == null) return HttpNotFound();

			return View(todo);
		}

		public ActionResult Create()
		{
			return View();
		}

		public ActionResult Edit()
		{
			return View();
		}
	}
}