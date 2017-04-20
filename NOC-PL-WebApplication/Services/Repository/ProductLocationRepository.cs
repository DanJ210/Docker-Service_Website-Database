//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using NocWebUtilityApp.Models;
//using Microsoft.EntityFrameworkCore;

//namespace NocWebUtilityApp.Services
//{
//    public class ProductLocationRepository : IProductLocationRepository {
//        private ProductLocationContext _context;

//        public ProductLocationRepository(ProductLocationContext context) {
//            _context = context;
//        }

//        public async Task<ICollection<Product>> GetProducts() {
//            return await _context.Products
//                .Include(primaryServer => primaryServer.PrimaryProductServer)
//                .Include(secondaryServer => secondaryServer.SecondaryProductServer)
//                .ToListAsync();
//        }
//        public async Task<Product> GetProduct(int productId) {
//            return await _context.Products.SingleAsync(product => product.Id == productId);
//        }

//        public async Task<IEnumerable<Server>> GetServers() {
//            return await _context.Servers.ToListAsync();
//        }
//        public async Task<Server> GetServer(int serverId) {
//            return await _context.Servers.SingleAsync(server => server.Id == serverId);
//        }
//    }
//}
