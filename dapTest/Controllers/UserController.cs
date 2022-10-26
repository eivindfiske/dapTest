using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using dapTest.Data;

namespace dapTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruppeController : Controller
    {

        private readonly DataContext _context;
        public GruppeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        
        public async Task<ActionResult<List<Gruppe11>>> Get()
        {
            return Ok(await _context.dbGruppe.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Gruppe11>> Get(int id)
        {
            var FinnId = await _context.dbGruppe.FindAsync(id);
                if (FinnId == null)
                    return BadRequest("gruppe medlem ikke funnet");
                return Ok(FinnId);
        }

        [HttpPost]
        public async Task<ActionResult<List<Gruppe11>>> AddMember(Gruppe11 gruppe11)
        {
            _context.dbGruppe.Add(gruppe11);
            await _context.SaveChangesAsync();

            return Ok(await _context.dbGruppe.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<Gruppe11>>> oppdater (Gruppe11 request)
        {
            var gruppeEdit = await _context.dbGruppe.FindAsync(request.id);
            if (gruppeEdit == null)
                return BadRequest("gruppe medlem ikke funnet");

            gruppeEdit.id = request.id;
            gruppeEdit.navn = request.navn;
            gruppeEdit.etternavn = request.etternavn;

            await _context.SaveChangesAsync();

            return Ok(await _context.dbGruppe.ToListAsync());

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Gruppe11>>> delete(int id)
        {
            var slettgruppe = await _context.dbGruppe.FindAsync(id);
            if (slettgruppe == null)
                return BadRequest("gruppe medlem ikke funnet");
            
            _context.dbGruppe.Remove(slettgruppe);
            await _context.SaveChangesAsync();
            return Ok(await _context.dbGruppe.ToListAsync());

        }

    }
}
