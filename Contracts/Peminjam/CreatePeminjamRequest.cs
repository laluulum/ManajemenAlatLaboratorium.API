namespace ManajemenAlatLaboratorium.API.Contracts.Peminjam;

public record CreatePeminjamRequest(
    string Nama,
    string Alamat,
    string Email,
    string NomorHandphone,
    bool Aktif
);