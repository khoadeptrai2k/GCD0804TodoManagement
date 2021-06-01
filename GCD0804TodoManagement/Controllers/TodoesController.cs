using GCD0804TodoManagement.Models;
using GCD0804TodoManagement.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GCD0804TodoManagement.Controllers
{
	[Authorize]
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
			var userId = User.Identity.GetUserId();

			var todoesInDb = _context.Todoes
				.Include(t => t.Category)
				.Where(t => t.UserId.Equals(userId))
				.ToList();

			if (!searchString.IsNullOrWhiteSpace())
			{
				todoesInDb = _context.Todoes.Where(t => t.Description.Contains(searchString)).ToList();
			}

			return View(todoesInDb);
		}

		public ActionResult Details(int? id) // ? id can be null
		{
			if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var userId = User.Identity.GetUserId();
			var todo = _context.Todoes
				.Include(t => t.Category)
				.Where(t => t.UserId.Equals(userId))
				.SingleOrDefault(t => t.Id == id);

			if (todo == null) return HttpNotFound();

			return View(todo);
		}

		[HttpGet]
		public ActionResult Delete(int? id)
		{
			var userId = User.Identity.GetUserId();

			if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var todoInDb = _context.Todoes
				.Where(t => t.UserId.Equals(userId))
				.SingleOrDefault(t => t.Id == id);

			if (todoInDb == null) return HttpNotFound();

			_context.Todoes.Remove(todoInDb);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Create()
		{
			var viewModel = new TodoCategoriesViewModel()
			{
				Categories = _context.Categories.ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(Todo todo)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new TodoCategoriesViewModel()
				{
					Todo = todo,
					Categories = _context.Categories.ToList()
				};

				return View(viewModel);
			}

			var userId = User.Identity.GetUserId();
			var newTodo = new Todo()
			{
				Description = todo.Description,
				CategoryId = todo.CategoryId,
				DueDate = todo.DueDate,
				UserId = userId
			};

			_context.Todoes.Add(newTodo);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Edit(int? id)
		{
			if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var userId = User.Identity.GetUserId();

			var todoInDb = _context.Todoes
				.Where(t => t.UserId.Equals(userId))
				.SingleOrDefault(t => t.Id == id);

			if (todoInDb == null) return HttpNotFound();

			var viewModel = new TodoCategoriesViewModel
			{
				Todo = todoInDb,
				Categories = _context.Categories.ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Edit(Todo todo)
		{
			var userId = User.Identity.GetUserId();
			var todoInDb = _context.Todoes
				.Where(t => t.UserId.Equals(userId))
				.SingleOrDefault(t => t.Id == todo.Id);

			if (!ModelState.IsValid)
			{
				var viewModel = new TodoCategoriesViewModel
				{
					Todo = todo,
					Categories = _context.Categories.ToList()
				};
				return View(viewModel);
			}

			if (todoInDb == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			todoInDb.Description = todo.Description;
			todoInDb.CategoryId = todo.CategoryId;
			todoInDb.DueDate = todo.DueDate;

			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		public ActionResult ReportCategoryByName()
		{
			List<CategoryQuantityByName> viewModel = new List<CategoryQuantityByName>();
			var userId = User.Identity.GetUserId();
			var todoes = _context.Todoes
				.Include(t => t.Category)
				.Where(t => t.UserId.Equals(userId))
				.ToList();

			var groupByCategoryName = todoes.GroupBy(t => t.Category.Name).ToList();

			foreach (var categoryGroupName in groupByCategoryName)
			{
				var categoryQuantity = categoryGroupName.Select(t => t.Category).Count();
				viewModel.Add(new CategoryQuantityByName
				{
					CategoryName = categoryGroupName.Key,
					CategoryQuantity = categoryQuantity
				});
			}

			return View(viewModel);
		}
	}
}