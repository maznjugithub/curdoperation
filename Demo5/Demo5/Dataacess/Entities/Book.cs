
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo5.Dataacess.Entities
{
	[Table("Book")]
	public class Book
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string WriterName { get; set; }

	}
}
