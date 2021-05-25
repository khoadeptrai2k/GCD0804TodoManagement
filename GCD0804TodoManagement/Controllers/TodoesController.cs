using GCD0804TodoManagement.Models;
using Microsoft.Ajax.Utilities;
using System.Linq;
using System.Net;
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
		[HttpGet]
		public ActionResult Index(string searchString)
		{
			var todoesInDb = _context.Todoes.ToList();

			if (!searchString.IsNullOrWhiteSpace())
			{
				todoesInDb = _context.Todoes.Where(t => t.Description.Contains(searchString)).ToList();
			}

			return View(todoesInDb);
		}

		public ActionResult Details(int? id)
		{
			if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var todo = _context.Todoes.SingleOrDefault(t => t.Id == id);

			if (todo == null) return HttpNotFound();

			return View(todo);
		}

		[HttpGet]
		public ActionResult Delete(int? id)
		{
			if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

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

		[HttpGet]
		public ActionResult Edit(int? id)
		{
			if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var todoInDb = _context.Todoes.SingleOrDefault(t => t.Id == id);

			if (todoInDb == null) return HttpNotFound();

			return View(todoInDb);
		}

		[HttpPost]
		public ActionResult Edit(Todo todo)
		{
			var todoInDb = _context.Todoes.SingleOrDefault(t => t.Id == todo.Id);

			if (!ModelState.IsValid)
			{
				return View(todo);
			}

			if (todoInDb == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			todoInDb.Description = todo.Description;
			todoInDb.Category = todo.Category;
			todoInDb.DueDate = todo.DueDate;

			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}