using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo5.Dataacess.Entities
{
	[Table("Class")]
	public class Class
	{
		[Key]
		public int Id { get; set; }	
		public string Name { get; set; }
		public int ClassRoom { get; set; }
		public int Capacity { get; set; }
    }
}
