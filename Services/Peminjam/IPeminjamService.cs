using ManajemenAlatLaboratorium.API.Models;

namespace ManajemenAlatLaboratorium.API.Services;

public interface IPeminjamService
{
    Peminjam? CreatePeminjam(Peminjam peminjam);
    IEnumerable<Peminjam> GetAllPeminjam();
    Peminjam? GetPeminjamById(int id);
    bool UpdatePeminjam(int id, Peminjam peminjam);
}