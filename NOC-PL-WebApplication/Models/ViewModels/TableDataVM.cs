using System.Collections.Generic;

namespace NocWebUtilityApp.Models {
    public class TableDataVM {
        public int Id { get; set; }
        public ICollection<Product> TableProducts { get; set; }
        public IEnumerable<Server> TableServers { get; set; }
    }
}
