using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GCD0804TodoManagement.Models
{
	public class Category
	{
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		[DisplayName("Category Name")]
		public string Name { get; set; }
	}
}