using Microsoft.Build.Framework;

namespace hacaton.Models
{
	public class Department : BaseEntity
	{
		[Required]
        public string Name { get; set; }
        public IEnumerable<Employees>? employees { get; set; }
    }
}
