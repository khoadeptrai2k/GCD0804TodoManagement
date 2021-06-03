using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCD0804TodoManagement.Models
{
  public class Team
  {
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(255)]
    [DisplayName("Team Name")]
    [Index("Name_Index", IsUnique = true)]
    public string Name { get; set; }
  }
}