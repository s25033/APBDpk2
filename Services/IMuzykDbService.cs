using APBDpk2.Entities;

namespace APBDpk2.Services
{
    public interface IMuzykDbService
    {
        Task<IList<Muzyk>> GetMuzycyListAsync(int id);
    }
}
