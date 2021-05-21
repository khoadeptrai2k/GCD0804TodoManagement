using GCD0804TodoManagement.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GCD0804TodoManagement.Controllers
{
	public class TodoesController : Controller
	{
		private List<Todo> _todoes = new List<Todo>();

		public TodoesController()
		{
			_todoes.Add(new Todo()
			{
				Id = 1,
				Category = "Family",
				Description = "Buy Milk",
				DueDate = DateTime.Now
			});

			_todoes.Add(new Todo()
			{
				Id = 2,
				Category = "Professional",
				Description = "Report the Progress of the Project",
				DueDate = DateTime.Now
			});

		}

		// GET: Todoes
		public ActionResult Index()
		{
			return View(_todoes);
		}

		public ActionResult Details()
		{
			return View();
		}
	}
}