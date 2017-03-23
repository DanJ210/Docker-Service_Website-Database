using Microsoft.AspNetCore.Mvc;
using NOCPLWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOCPLWebApplication.Controllers {
    public class TableController : Controller {
        private ProductLocationContext _context;

        public TableController(ProductLocationContext context) {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index() {
            var data = _context.Products.ToList();
            //var serverData = _context.Products.ToList();
            return View(data);
        }
        
    }
}
