using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NOCPLWebApplication.Models {
    public class TableDataVM {
        //private ProductLocationContext _context;
        //public TableDataVM() {

        //}
        //public TableDataVM(ProductLocationContext context) {
        //    _context = context;
        //    TableProduct = _context.Products.ToList();
        //    TableServer = _context.Servers.ToList();
        //}
        public int Id { get; set; }
        public ICollection<Product> TableProducts { get; set; }
        public ICollection<Server> TableServers { get; set; }
    }
}
