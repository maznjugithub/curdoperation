using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo5.Dataacess.Entities

{

	[Table("Teacher")]
	public class Teacher
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Address { get; set; }
	}
}
