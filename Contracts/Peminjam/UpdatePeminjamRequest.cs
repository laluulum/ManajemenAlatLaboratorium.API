namespace ManajemenAlatLaboratorium.API.Contracts.Peminjam;

public record UpdatePeminjamRequest(
    string Nama,
    string Alamat,
    string Email,
    string NomorHandphone,
    bool Aktif
);