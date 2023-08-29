using ManajemenAlatLaboratorium.API.Models;

namespace ManajemenAlatLaboratorium.API.Services;

public interface IAlatService
{
    Alat? CreateAlat(Alat alat);
    IEnumerable<Alat> GetAllAlat();
    Alat? GetAlatById(int id);
    bool UpdateAlat(int id, Alat alat);
    bool DeleteAlat(int id);
}