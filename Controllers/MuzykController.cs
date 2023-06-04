using APBDpk2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APBDpk2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MuzykController : ControllerBase
    {
        private readonly MuzykaDbContext _context;

        public MuzykController(MuzykaDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetMuzyk(int id)
        {
            var muzyk = _context.Muzycy
                .Include(m => m.wykonawcaUtworu)
                .ThenInclude(wu => wu.utwor)
                .FirstOrDefault(m => m.IdMuzyk == id);

            if (muzyk != null)
            {
                if (muzyk.wykonawcaUtworu == null || muzyk.wykonawcaUtworu.Count == 0)
                {
                    // Jeśli muzyk istnieje, ale nie ma powiązanych utworów, zwróć pustą listę utworów
                    muzyk.wykonawcaUtworu = new List<WykonawcaUtworu>();
                }

                return Ok(muzyk);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddMuzyk(Muzyk muzyk)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (muzyk.wykonawcaUtworu != null)
                    {
                        foreach (var wu in muzyk.wykonawcaUtworu)
                        {
                            if (wu.utwor != null && wu.utwor.IdUtwor == 0)
                            {
                                _context.Utwory.Add(wu.utwor);
                            }
                        }
                    }

                    _context.Muzycy.Add(muzyk);
                    _context.SaveChanges();

                    transaction.Commit();

                    return Ok();
                }
                catch
                {
                    transaction.Rollback();
                    return StatusCode(500, "An error occurred while adding the musician.");
                }
            }
        }
    }
}

