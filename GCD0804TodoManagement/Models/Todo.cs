using System;
using System.ComponentModel.DataAnnotations;

namespace GCD0804TodoManagement.Models
{
	public class Todo
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		[Display(Name = "Due Date of the Todo")]
		public DateTime DueDate { get; set; }
		[Required]
		public string Category { get; set; }
	}
}