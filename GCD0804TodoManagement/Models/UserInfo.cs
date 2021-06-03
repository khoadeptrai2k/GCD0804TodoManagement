using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCD0804TodoManagement.Models
{
	public class UserInfo
	{
		[Key]
		[ForeignKey("User")]
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }
		[Required]
		public string FullName { get; set; }
		[Required]
		[Range(1, 150, ErrorMessage = "Please enter Age value bigger than 0 and less than 150")]
		public int Age { get; set; }
	}
}