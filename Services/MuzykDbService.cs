using APBDpk2.Entities;
using Microsoft.EntityFrameworkCore;

namespace APBDpk2.Services
{
    public class MuzykDbService : IMuzykDbService
    {
        private readonly MuzykaDbContext _context;

        public MuzykDbService(MuzykaDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Muzyk>> GetMuzycyListAsync(int id)
        {
            var muzycy = await _context.Muzycy
                .Include(m => m.wykonawcaUtworu)
                .ThenInclude(wu => wu.utwor)
                .Where(m => m.IdMuzyk == id)
                .ToListAsync();

            return muzycy;
        }
    }
}
