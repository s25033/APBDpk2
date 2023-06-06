using APBDpk2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Kontroler obsługujący operacje na encjach Muzyk i WykonawcaUtworu w kontekście bazy danych
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

        // Metoda obsługująca żądanie GET z parametrem "id"
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMuzyk(int id)
        {
            // Pobranie muzyka z bazy danych wraz z powiązanymi encjami wykonawcaUtworu i utwor
            var muzyk = _context.Muzycy
                .Include(m => m.wykonawcaUtworu)
                .ThenInclude(wu => wu.utwor)
                .FirstOrDefault(m => m.IdMuzyk == id);

            // Sprawdzenie, czy muzyk został znaleziony w bazie danych
            if (muzyk != null)
            {
                // Jeśli muzyk istnieje, ale nie ma powiązanych utworów, zwróć pustą listę utworów
                if (muzyk.wykonawcaUtworu == null || muzyk.wykonawcaUtworu.Count == 0)
                {
                    muzyk.wykonawcaUtworu = new List<WykonawcaUtworu>();
                }

                // Zwrócenie muzyka w odpowiedzi HTTP 200 OK
                return Ok(muzyk);
            }

            // Zwrócenie odpowiedzi HTTP 404 Not Found, jeśli muzyk o podanym id nie został znaleziony
            return NotFound();
        }

        // Metoda obsługująca żądanie POST
        [HttpPost]
        public async Task<IActionResult> AddMuzykAsync(Muzyk muzyk)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Dodanie nowych utworów do bazy danych, jeśli są przekazane w obiekcie muzyk
                    if (muzyk.wykonawcaUtworu != null)
                    {
                        foreach (var wu in muzyk.wykonawcaUtworu)
                        {
                            if (wu.utwor != null && wu.utwor.IdUtwor == 0)
                            {
                                _context.Utwory.Add(wu.utwor);
                            }
                            else if (wu.utwor == null)
                            {
                                // Zwrócenie odpowiedzi HTTP 400 Bad Request, jeśli przekazany utwór jest null lub ma nieprawidłowe ID
                                return BadRequest("Utwór nie został przekazany lub ma nieprawidłowe ID.");
                            }
                            else
                            {
                                var existingUtwor = await _context.Utwory.FindAsync(wu.utwor.IdUtwor);
                                if (existingUtwor == null)
                                {
                                    // Zwrócenie odpowiedzi HTTP 404 Not Found, jeśli nie znaleziono utworu o podanym ID
                                    return NotFound("Nie znaleziono utworu o podanym ID.");
                                }
                            }
                        }
                    }

                    // Dodanie muzyka do bazy danych
                    _context.Muzycy.Add(muzyk);
                    _context.SaveChanges();

                    // Zatwierdzenie transakcji
                    transaction.Commit();

                    // Zwrócenie odpowiedzi HTTP 200 OK
                    return Ok();
                }
                catch
                {
                    // Wycofanie transakcji i zwrócenie odpowiedzi HTTP 500 Internal Server Error w przypadku błędu
                    transaction.Rollback();
                    return StatusCode(500, "Pojawił się błąd przy dodawaniu Muzyka");
                }
            }
        }
    }
}
