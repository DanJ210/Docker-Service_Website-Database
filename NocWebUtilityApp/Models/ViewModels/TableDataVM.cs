using System.Collections.Generic;

namespace NocWebUtilityApp.Models
{
	public class TableDataVM
	{
		public int Id { get; set; }
		public IEnumerable<Product> TableProducts { get; set; }
		public ICollection<Server> TableServers { get; set; }
	}
}
