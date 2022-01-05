using HalloEF.Data;
using HalloEF.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HalloEF.FullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MitarbeiterController : ControllerBase
    {
        EfContext _context = new EfContext();

        // GET: api/<MitarbeiterController>
        [HttpGet]
        public IEnumerable<Mitarbeiter> Get()
        {
            return _context.Mitarbeiter.ToList();
        }

        // GET api/<MitarbeiterController>/5
        [HttpGet("{id}")]
        public Mitarbeiter Get(int id)
        {
            return _context.Mitarbeiter.Find(id);
        }

        // POST api/<MitarbeiterController>
        [HttpPost]
        public void Post([FromBody] Mitarbeiter value)
        {
            _context.Mitarbeiter.Add(value);
            _context.SaveChanges();
        }

        // PUT api/<MitarbeiterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Mitarbeiter value)
        {
            _context.Mitarbeiter.Update(value);
            _context.SaveChanges();
        }

        // DELETE api/<MitarbeiterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Mitarbeiter.Remove(Get(id));
            _context.SaveChanges();
        }
    }
}
