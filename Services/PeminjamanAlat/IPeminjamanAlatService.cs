using ManajemenAlatLaboratorium.API.Contracts.PeminjamanAlat;
using ManajemenAlatLaboratorium.API.Models;

namespace ManajemenAlatLaboratorium.API.Services;

public interface IPeminjamanAlatService
{
    PeminjamanAlat? CreatePeminjamanAlat(PeminjamanAlat peminjamanAlat);
    IEnumerable<PeminjamanAlat> GetAllPeminjamanAlat();
    PeminjamanAlat? GetPeminjamanAlatById(int id);
    bool UpdatePeminjamanAlat(int id, PeminjamanAlat peminjamanAlat);
    List<Alat>? GetAlatByIds(List<int> alatIds);
    Peminjam? GetPeminjamById(int id);
    bool DeletePeminjamanAlat(int id);
    bool IsPengembalianOnly(int id, UpdatePeminjamanAlatRequest request);
}