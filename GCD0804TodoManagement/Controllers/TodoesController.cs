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

		[HttpGet]
		public ActionResult Delete(int? id)
		{
			if (id == null) return HttpNotFound();

			var todoInDb = _context.Todoes.SingleOrDefault(t => t.Id == id);

			if (todoInDb == null) return HttpNotFound();

			_context.Todoes.Remove(todoInDb);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Todo todo)
		{
			if (!ModelState.IsValid)
			{
				return View(todo);
			}

			var newTodo = new Todo()
			{
				Description = todo.Description,
				Category = todo.Category,
				DueDate = todo.DueDate
			};

			_context.Todoes.Add(newTodo);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		public ActionResult Edit()
		{
			return View();
		}
	}
}