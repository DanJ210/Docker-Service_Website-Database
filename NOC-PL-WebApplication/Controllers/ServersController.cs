//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using NOCPLWebApplication.Models;

//namespace NOC_PL_WebApplication.Controllers
//{
//    //[Produces("application/json")]
//    //[Route("api/Servers")]
//    public class ServersController : Controller
//    {
//        private readonly ProductLocationContext _context;

//        public ServersController(ProductLocationContext context)
//        {
//            _context = context;
//        }

//        //GET: api/Servers
//       [HttpGet]
//        public IEnumerable<Server> GetServers() {
//            return _context.Servers;
//        }

//        // GET: api/Servers/5
//        [HttpPost]
//        public async Task<IActionResult> GetServerNameById(int? serverId) {
//            if (!ModelState.IsValid) {
//                return BadRequest(ModelState);
//            }
//            var server = await _context.Servers.SingleOrDefaultAsync(s => s.Id == serverId);
//            if (server == null) {
//                return NotFound();
//            }
//            return Ok(server.ServerName);
//        }





//        // Code below is only for reference. No need to review







//        // GET: api/Servers/5
//        //[HttpGet("{id}")]
//        //public async Task<IActionResult> GetServer([FromRoute] int id)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        return BadRequest(ModelState);
//        //    }

//        //    var server = await _context.Servers.SingleOrDefaultAsync(m => m.Id == id);

//        //    if (server == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    return Ok(server);
//        //}

//        // PUT: api/Servers/5
//        //[HttpPut("{id}")]
//        //public async Task<IActionResult> PutServer([FromRoute] int id, [FromBody] Server server)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        return BadRequest(ModelState);
//        //    }

//        //    if (id != server.Id)
//        //    {
//        //        return BadRequest();
//        //    }

//        //    _context.Entry(server).State = EntityState.Modified;

//        //    try
//        //    {
//        //        await _context.SaveChangesAsync();
//        //    }
//        //    catch (DbUpdateConcurrencyException)
//        //    {
//        //        if (!ServerExists(id))
//        //        {
//        //            return NotFound();
//        //        }
//        //        else
//        //        {
//        //            throw;
//        //        }
//        //    }

//        //    return NoContent();
//        //}

//        // POST: api/Servers
//        //[HttpPost]
//        //public async Task<IActionResult> PostServer([FromBody] Server server)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        return BadRequest(ModelState);
//        //    }

//        //    _context.Servers.Add(server);
//        //    await _context.SaveChangesAsync();

//        //    return CreatedAtAction("GetServer", new { id = server.Id }, server);
//        //}

//        // DELETE: api/Servers/5
//        //[HttpDelete("{id}")]
//        //public async Task<IActionResult> DeleteServer([FromRoute] int id)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        return BadRequest(ModelState);
//        //    }

//        //    var server = await _context.Servers.SingleOrDefaultAsync(m => m.Id == id);
//        //    if (server == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    _context.Servers.Remove(server);
//        //    await _context.SaveChangesAsync();

//        //    return Ok(server);
//        //}

//        private bool ServerExists(int id) {
//            return _context.Servers.Any(e => e.Id == id);
//        }


        

//        //[HttpGet("{id}")]
//        //public async Task<IActionResult> GetServerByIdNumber() {

//        //}
//    }
//}