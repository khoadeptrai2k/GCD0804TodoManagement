using GCD0804TodoManagement.Models;
using System.Collections.Generic;

namespace GCD0804TodoManagement.ViewModels
{
	public class TodoCategoriesViewModel
	{
		public Todo Todo { get; set; }
		public IEnumerable<Category> Categories { get; set; }
	}
}