using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCD0804TodoManagement.Models
{
	public class Todo
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Description { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Required]
		[Display(Name = "Due Date of the Todo")]
		public DateTime DueDate { get; set; }
		[ForeignKey("Category")]
		[Required]
		public int CategoryId { get; set; }       // Forgein Key
		public Category Category { get; set; }    // Linking Object to Category model
	}
}