using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[StringLength(50)]
		public string Name { get; set; }
		[Required]
		[StringLength(50)]
		public string Email { get; set; }
		[Required]
		[StringLength(150)]
		public string Address { get; set; }
       
    }
}
